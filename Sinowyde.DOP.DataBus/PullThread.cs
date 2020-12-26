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
    public class PullEventArgs : EventArgs
    {
        public DOPMessage Message { get; set; }
    }
    /// <summary>
    /// 响应消息处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventPullEventArgsMessage(object sender, PullEventArgs arg);
    /// <summary>
    /// 相应消息线程
    /// </summary>
    public class PullThread : ServiceThreadEx
    {
        public PullThread(int port, string topic)
            : base(5)
        {
            this.Port = port;
            this.Topic = topic;
        }
        /// <summary>
        /// 服务地址
        /// </summary>
        public int Port
        {
            get;
            set;
        }
        public string Address
        {
            get
            {
                return string.Format("tcp://*:{0}", this.Port.ToString());
            }
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
        /// 创建线程，启动socket
        /// </summary>
        private PullSocket pullSocket = null;
        protected override void InitThread()
        {
            var context = NetMQContext.Create();
            pullSocket = context.CreatePullSocket();
            pullSocket.Bind(Address);
        }
        /// <summary>
        /// 消息处理事件
        /// </summary>
        public event EventPullEventArgsMessage EventPullMessage = null;
        /// <summary>
        /// 处理接收到的消息
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {          
            try
            {
                List<string> messages = null;
                while (pullSocket.TryReceiveMultipartStrings(ref messages))
                {
                    foreach (string recmsg in messages)
                    {
                        DOPMessage message = DOPMessage.FromString(recmsg);
                        if (message != null && EventPullMessage != null)
                        {
                            EventPullMessage(this, new PullEventArgs { Message = message });
                        }
                    }                    
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("PullThread 异常", ex);
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
                pullSocket.Unbind(Address);
                pullSocket.Close();
            }
            catch
            { }
        }
    }
}
