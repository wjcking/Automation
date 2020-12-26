using NHibernate.Criterion;
using Sinowyde.DataLogic;
using Sinowyde.DOP.Broker.Server.Properties;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Broker.Server
{
    class BrokerService
    {
        /// <summary>
        /// 响应线程
        /// </summary>
        private PullThread pullThread = null;
        /// <summary>
        /// 发布线程
        /// </summary>
        private PublishThread publishThread = null;

        public BrokerService()
        {            
            publishThread = new PublishThread(Settings.Default.PubPort);

            pullThread = new PullThread(Settings.Default.PullPort, "ANY");
            pullThread.EventPullMessage += thread_EventPullMessage;
        }
        /// <summary>
        /// 接收相应消息处理
        /// 放到发布线程等待发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void thread_EventPullMessage(object sender, PullEventArgs arg)
        {
            Console.WriteLine(string.Format("{0}==>thread_EventResponseMessage:Content:{1}", DateTime.Now.ToLongTimeString() ,arg.Message.Content));
            publishThread.AddBuffer(arg.Message.Topic, arg.Message.Content);
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <returns></returns>
        public bool StartService()
        {
            return publishThread.Start() && pullThread.Start();
        }
        /// <summary>
        /// 结束服务
        /// </summary>
        public void StopService()
        {
            publishThread.Stop();
            pullThread.Stop();
        }
    }
}
