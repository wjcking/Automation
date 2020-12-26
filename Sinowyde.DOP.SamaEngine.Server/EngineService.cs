using Sinowyde.DataLogic;
using Sinowyde.DataModel;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.SamaEngine.Server.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Log;
using Sinowyde.DOP.PIDAlgorithm.DB;

namespace Sinowyde.DOP.SamaEngine.Server
{
    class EngineService
    {
        /// <summary>
        /// 订阅实时数据线程
        /// </summary>
        private SubscribeThreadPool subThreadPool = null;

        /// <summary>
        /// 接收命令线程
        /// </summary>
        private SubscribeThread subThread = null;

        /// <summary>
        /// 推送数据
        /// </summary>
        private PushThread pushThread = null;

        /// <summary>
        /// sama算法管理
        /// </summary>
        public SamaManager DocRunTime = null;

        /// <summary>
        /// 备用算法管理
        /// </summary>
        public SamaManager DocRunTimeStandBy = null;

        public EngineService()
        {
            //清空启动状态
            PIDDataLogic.Instance().ClearAlgRunState();

            //初始化运行时
            InitDocRunTime(ref this.DocRunTime);

            //订阅实时数据
            subThreadPool = new SubscribeThreadPool(Settings.Default.PubAddress, Settings.Default.PubTopic.Split(','));
            subThreadPool.EventSubscribe += subThreadPool_EventSubscribe;

            //接收参数设置命令
            subThread = new SubscribeThread(Settings.Default.PubAddress, PIDAlgTopic.PIDCommand);
            subThread.EventSubscribe += subThread_EventSubscribe;

            //发送数据线程
            pushThread = new PushThread(Settings.Default.PullAddress, "");
        }

        private void subThread_EventSubscribe(object sender, SubscribeEventArgs arg)
        {
            try
            {
                foreach (string message in arg.Messages)
                {
                    Console.WriteLine(DateTime.Now.ToLongDateString() + " " + message);
                    PIDCommmandMsg msg = PIDCommmandMsg.FromString(message);
                    LogUtilEx.LogInfo("收到命令： " + msg.CommandType + " " + msg.Guid);
                    switch (msg.CommandType)
                    {
                        case PIDCommandType.RunDebug:
                            //不需要做任何处理
                            break;
                        case PIDCommandType.OfflineDebug:
                            if (DocRunTime != null)
                                DocRunTime.SetOfflineDebug(msg.Guid, msg.TakeEffect);
                            break;
                        case PIDCommandType.Reset:
                           //未做处理
                            break;
                        case PIDCommandType.ForceValue:
                            if (DocRunTime != null)
                                DocRunTime.SetAlgValue(msg);
                            break;
                        case PIDCommandType.KeepValue:
                            if (DocRunTime != null)
                                DocRunTime.KeepAlgValue(msg);
                            break;
                        case PIDCommandType.Download:
                            EnableStandBy();
                            break;
                        case PIDCommandType.GetDebugSet:
                            if (DocRunTime != null)
                            {
                                //从数据库取
                            }
                            break;
                        default:
                            break;
                    }
                    //发出返回消息
                    this.pushThread.AddBuffer(PIDAlgTopic.PIDReCommand, message);
                    LogUtilEx.LogInfo("返回确认命令" + msg.CommandType + " " + msg.Guid);
                }
            }
            catch (Exception ex)
            {
                LogUtilEx.LogFatal("SAMA命令出错", ex);
            }
        }
        /// <summary>
        /// sama引发数据变更，解析，构建缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void subThreadPool_EventSubscribe(object sender, SubscribePoolEventArgs arg)
        {
            IList<string> messages = arg.Messages;            
            List<RTValue> values = new List<RTValue>();
            foreach (string message in messages)
            {
                values.Add(RTValue.FromString(message));
            }
            DocRunTime.AddRTValue(values);
        }

        /// <summary>
        /// 更新模型
        /// 重启启动sama线程
        /// </summary>
        private void InitDocRunTime(ref SamaManager docRunTime)
        {
            LogUtilEx.LogInfo("==>开始更新准备字典！" + DateTime.Now);
            if (docRunTime != null)
                docRunTime.StopSama();
            docRunTime = new SamaManager();
            docRunTime.CreateDocManager();
            docRunTime.eventUpdateValue += docRunTime_eventUpdateValue;            
            LogUtilEx.LogInfo("==>结束更新准备字典！" + DateTime.Now);
        }

        /// <summary>
        /// 启动备用
        /// </summary>
        private void EnableStandBy()
        {
            //初始化备用
            InitDocRunTime(ref this.DocRunTimeStandBy);
            //加载数据
            this.DocRunTimeStandBy.CloneFrom(this.DocRunTime);

            this.DocRunTime.StopSama();

            this.DocRunTime = this.DocRunTimeStandBy;

            //启动新sama
            this.DocRunTime.StartSama();

            this.DocRunTimeStandBy = null;
        }

        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void docRunTime_eventUpdateValue(object sender, UpdateRTValueArg arg)
        {
            pushThread.AddBuffer(arg.Topic, arg.Value.ToString());
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <returns></returns>
        public bool StartService()
        {
            DocRunTime.StartSama();
            pushThread.Start();
            subThreadPool.Start();
            subThread.Start();
            return true;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        public bool StopService()
        {
            DocRunTime.StopSama();
            subThreadPool.Stop();
            pushThread.Stop();
            subThread.Stop();
            return true;
        }
    }
}
