using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DataLogic;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Driver;
using Sinowyde.Util;
using Sinowyde.RTModel;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.IO.Server.Properties;
using Sinowyde.DataModel;
using System.IO.Ports;
namespace Sinowyde.DOP.IO.Server
{
    public class IOService
    {
        #region 变量定义
        //周期监测模型是否发生变更，如果变更则重新加载模型
        private CheckModel checkModel = null;
        /// <summary>
        /// 订阅数据线程
        /// </summary>
        private SubscribeThread subThread = null;
        /// <summary>
        /// 通道管理
        /// </summary>
        private IList<IOChannelWrapper> comChannels = null;

        #endregion
        public IOService()
        {
            //检查模型更新
            checkModel = new CheckModel(DOPDataLogic.Instance(), ModelType.Communication);
            checkModel.UpdateModelEvent += checkModel_UpdateModelEvent;

            //启动订阅线程
            subThread = new SubscribeThread(Settings.Default.Publish, IOTopic.IOWrite);
            subThread.EventSubscribe += subThread_EventSubscribe;    
      
            comChannels = new List<IOChannelWrapper>();
        }

        /// <summary>
        /// 订阅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        void subThread_EventSubscribe(object sender, SubscribeEventArgs arg)
        {
            //解析数据
            IList<string> messages = arg.Messages;
            IList<RTValue> values = new List<RTValue>();
            foreach (string message in messages)
            {
                values.Add(RTValue.FromString(message)); 
            }
            //输出数据报文
            foreach (IOChannelWrapper channel in comChannels)
            {
                channel.WriteCommand(values);
            }
        }

        /// <summary>
        /// 更新模型事件
        /// </summary>
        private void checkModel_UpdateModelEvent()
        {
            StopCommunication();
            UpdateModel();
            StartCommunication();
        }

        /// <summary>
        ///　更新模型数据，重新进行采集操作
        /// </summary>
        private void UpdateModel()
        {
            comChannels.Clear();
            IList<IOChannel> channelList = DOPDataLogic.Instance().GetChannelByIOSever(Settings.Default.IOServerName);
            if (channelList == null || channelList.Count == 0)
                return;
            //分析通道
            foreach (IOChannel ioChannel in channelList)
            {
                ioChannel.IOUnits = DOPDataLogic.Instance().GetIOUnitByChannelID(ioChannel.ID);
                if (ioChannel.IOUnits == null)
                    continue;
                foreach (IOUnit unit in ioChannel.IOUnits)
                {
                    unit.Variables = DOPDataLogic.Instance().GetByIOUnitID(unit.ID);
                }
                comChannels.Add(new IOChannelWrapper(ioChannel));
            }
        }

        /// <summary>
        /// 启动通讯
        /// </summary>
        private void StartCommunication()
        {
            Log.LogUtil.LogInfo("[IOService]启动通讯");
            Console.WriteLine("[IOService]启动通讯");
            foreach (IOChannelWrapper channel in this.comChannels)
            {
                channel.Open();
            }
        }

        /// <summary>
        /// 停止通讯
        /// </summary>
        private void StopCommunication()
        {
            Log.LogUtil.LogInfo("[IOService]停止通讯");
            Console.WriteLine("[IOService]停止通讯");
            foreach (IOChannelWrapper channel in this.comChannels)
            {
                channel.Close();
            }
        }

        /// <summary>
        /// 启动采集程序
        /// </summary>
        public bool StartService()
        {
            checkModel.Start();
            subThread.Start();
            StartCommunication();
            return true;
        }

        /// <summary>
        /// 停止采集程序
        /// </summary>
        public bool StopService()
        {
            StopCommunication();            
            subThread.Stop();
            checkModel.Stop();            
            return true;
        }
    }
}
