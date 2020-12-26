using NetMQ;
using NetMQ.Sockets;
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
    /// 订阅发布线程
    /// </summary>
    public class PublishThread : ServiceThreadEx
    {
        public PublishThread(int port)
            : base(10)
        {
            this.Port = port;
        }

        /// <summary>
        /// 线程地址
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
        /// 消息缓存缓存
        /// </summary>
        public BufferManager<DOPMessage> buffer = new BufferManager<DOPMessage>();
        public void AddBuffer(string topic, string message)
        {
            buffer.Add(new DOPMessage { Topic = topic, Content = message });
        }
        /// <summary>
        /// 创建处理线程
        /// </summary>
        private PublisherSocket pubSocket = null;
        protected override void InitThread()
        {
            var context = NetMQContext.Create();
            pubSocket = context.CreatePublisherSocket();
            pubSocket.Options.SendHighWatermark = 1000;
            pubSocket.Bind(Address);
        }

        /// <summary>
        /// 循环获取队列消息，发布消息给订阅者
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            try
            {
                IList<DOPMessage> msgs = buffer.GetAllData();
                foreach (DOPMessage msg in msgs)
                {
                    pubSocket.SendMoreFrame(msg.Topic).SendFrame(msg.Content);
                }
                return true;
            }
            catch(Exception ex)
            {
                Log.LogUtil.LogFatal("PublishThread 异常", ex);
                return false;
            }
        }
        /// <summary>
        /// 关闭socket
        /// </summary>
        protected override void DestroyThread()
        {
            try
            {
                pubSocket.Unbind(Address);
                pubSocket.Close();
            }
            catch
            { }
        }
    }
}
