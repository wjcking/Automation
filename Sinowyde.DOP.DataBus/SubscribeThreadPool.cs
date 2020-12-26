using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataBus
{
    /// <summary>
    /// 订阅消息参数
    /// </summary>
    public class SubscribePoolEventArgs : EventArgs
    {
        public string Topic { get; set; }
        public List<string> Messages { get; set; }
    }
    /// <summary>
    /// 订阅消息处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventSubscribePoolMessage(object sender, SubscribePoolEventArgs arg);
    /// <summary>
    /// 订阅多个主题数据，订阅数据类型相同
    /// </summary>
    public class SubscribeThreadPool
    {
        /// <summary>
        /// 线程队列
        /// </summary>
        private IDictionary<SubscribeThread, string> threadMap = new Dictionary<SubscribeThread, string>();
        public SubscribeThreadPool(string address, IList<string> topics)
        {
            foreach(string topic in topics)
            {
                topic.Trim();
                SubscribeThread thread = new SubscribeThread(address, topic);
                thread.EventSubscribe += thread_EventSubscribe;
                threadMap.Add(thread, topic.Trim());
            }
        }
        /// <summary>
        /// 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        void thread_EventSubscribe(object sender, SubscribeEventArgs arg)
        {
            if (threadMap.ContainsKey(sender as SubscribeThread))
            {
                string topic = threadMap[sender as SubscribeThread];
                if (this.EventSubscribe != null)
                    this.EventSubscribe(this, new SubscribePoolEventArgs { Messages = arg.Messages, Topic = topic });
            }
        }

        public event EventSubscribePoolMessage EventSubscribe;

        public void Start()
        {
            foreach (SubscribeThread thread in threadMap.Keys)
            {
                thread.Start();
            }
        }

        public void Stop()
        {
            foreach (SubscribeThread thread in threadMap.Keys)
            {
                thread.Stop();
            }
        }

    }
}
