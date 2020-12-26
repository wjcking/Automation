using NetMQ;
using NetMQ.Sockets;
using Sinowyde.Log;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataBus
{
    /// <summary>
    /// 订阅消息参数
    /// </summary>
    public class SubscribeEventArgs : EventArgs
    {
        public List<string> Messages { get; set; }
    }
    /// <summary>
    /// 订阅消息处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventSubscribeMessage(object sender, SubscribeEventArgs arg);
    /// <summary>
    /// 订阅消息线程
    /// </summary>
    public class SubscribeThread : ServiceThreadEx
    {
        public SubscribeThread(string address, string topic)
            : base(5)
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
        /// 订阅主题
        /// </summary>
        public string Topic
        {
            get;
            set;
        }
        /// <summary>
        /// 初始化线程，订阅消息主题
        /// </summary>
        public event EventSubscribeMessage EventSubscribe;
        private SubscriberSocket subSocket = null;
        private volatile bool isConnected = false;
        protected override void InitThread()
        {
            try
            {
                var context = NetMQContext.Create();
                subSocket = context.CreateSubscriberSocket();
                subSocket.Connect(Address);
                subSocket.Subscribe(Topic);
                isConnected = true;
            }
            catch(Exception ex)
            {
                isConnected = false;
                LogUtil.LogFatal("初始化socket失败", ex);
            }
        }
        /// <summary>
        /// 如果没有成功连接，先连接，然后再接受数据
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            try
            {
                if (!isConnected)
                {
                    subSocket.Connect(Address);
                    subSocket.Subscribe(Topic);
                    if (!isConnected)
                    {
                        Thread.Sleep(5 * 1000);
                        return true;
                    }
                }
                List<string> messages = null;
                while (subSocket.TryReceiveMultipartStrings(ref messages))
                {
                    if (EventSubscribe != null)
                    {
                        SubscribeEventArgs arg = new SubscribeEventArgs { Messages = new List<string>() };
                        for (int i = 0; i < messages.Count; i++)
                        {
                            if (i % 2 == 1)
                            {
                                arg.Messages.Add(messages[i]);
                            }
                        }
                        EventSubscribe(this, arg);
                    }
                }                
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("SubsriberThread 异常", ex);
                return false;
            }
        }
        /// <summary>
        /// 关闭线程，释放socket
        /// </summary>
        protected override void DestroyThread()
        {
            try
            {
                subSocket.Disconnect(this.Address);
                subSocket.Close();
            }
            catch
            { }
        }
    }
}
