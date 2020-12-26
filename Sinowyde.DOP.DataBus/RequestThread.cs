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
    /// 连接请求线程
    /// </summary>
    public class RequestThread : ServiceThreadEx
    {
        public RequestThread(string address, string topic)
            : base(10)
        {
            this.Address = address;
            this.Topic = topic.Trim();
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
        /// 启动连接
        /// </summary>
        private RequestSocket reqSocket = null;
        private volatile bool isConnected = false;
        protected override void InitThread()
        {
            try
            {
                var context = NetMQContext.Create();
                reqSocket = context.CreateRequestSocket();
                reqSocket.Connect(Address);
                isConnected = true;
            }
            catch
            {
                isConnected = false;
            }
        }
        /// <summary>
        /// 处理服务
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {            
            try
            {
                if (!isConnected)
                {
                    //先连接后发送请求
                    reqSocket.Connect(Address);
                    if (!isConnected)
                    {
                        return true;
                    }
                }

                IList<DOPMessage> msgs = buffer.GetData(50);
                if (msgs == null || msgs.Count == 0)
                    return true;
                else
                {
                    foreach (DOPMessage message in msgs)
                    {
                        reqSocket.SendFrame(message.ToString());
                        //等待反馈消息
                        reqSocket.ReceiveFrameString();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("RequestThread 异常", ex);
                return false;
            }
        }

        protected override void DestroyThread()
        {
            try
            {
                reqSocket.Disconnect(this.Address);
                reqSocket.Close();
            }
            catch
            { }
        }
    }
}
