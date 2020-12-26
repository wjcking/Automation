using NetMQ;
using NetMQ.Sockets;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataBus
{
    /// <summary>
    /// 响应消息参数
    /// </summary>
    public class ReponseEventArgs : EventArgs
    {
        public DOPMessage Message { get; set; }
    }
    /// <summary>
    /// 响应消息处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventResponseMessage(object sender, ReponseEventArgs arg);
    /// <summary>
    /// 相应消息线程
    /// </summary>
    public class ResponseThread : ServiceThreadEx
    {
        public ResponseThread(string address, string topic)
            : base(10)
        {
            this.Address = address;
            this.Topic = topic;
        }
        /// <summary>
        /// 服务地址
        /// </summary>
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 消息主题
        /// </summary>
        public string Topic
        {
            get;
            set;
        }
        /// <summary>
        /// 消息缓存缓存
        /// </summary>
        public BufferManager<DOPMessage> buffer = new BufferManager<DOPMessage>();
        public void AddBuffer(string message)
        {
            buffer.Add(new DOPMessage { Topic = this.Topic, Content = message });
        }
        /// <summary>
        /// 携带自己主题
        /// </summary>
        /// <param name="message"></param>
        public void AddBuffer(string topic, string message)
        {
            if (string.IsNullOrEmpty(topic))
                AddBuffer(message);
            else
                buffer.Add(new DOPMessage { Topic = topic, Content = message });
        }
        /// <summary>
        /// 创建线程，启动socket
        /// </summary>
        protected ResponseSocket rspSocket = null;
        protected override void InitThread()
        {
            var context = NetMQContext.Create();
            rspSocket = context.CreateResponseSocket();
            rspSocket.Bind(Address);
        }
        /// <summary>
        /// 消息处理事件
        /// </summary>
        public event EventResponseMessage EventResponseMessage = null;
        /// <summary>
        /// 处理接收到的消息
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            try
            {
                //接收消息
                string recmsg = string.Empty;
                if (rspSocket.TryReceiveFrameString(out recmsg))
                {
                    DOPMessage message = DOPMessage.FromString(recmsg);
                    if (message != null && EventResponseMessage != null)
                    {
                        EventResponseMessage(this, new ReponseEventArgs { Message = message });
                    }
                    //发出回应消息
                    IList<DOPMessage> msgs = buffer.GetData(1);
                    if (msgs != null && msgs.Count == 1)
                    {
                        rspSocket.SendFrame(msgs[0].ToString(), false);
                    }
                    else
                    {
                        rspSocket.SendFrame(recmsg);
                    }
                    return true;
                }
                
                //发送消息
                

                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("ResponseThread 异常", ex);
                return false;
            }
        }
        /// <summary>
        /// 关闭线程，关闭socket
        /// </summary>
        protected override void DestroyThread()
        {
            try
            {
                rspSocket.Unbind(Address);
                rspSocket.Close();
            }
            catch
            { }
        }
    }
}
