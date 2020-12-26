using Sinowyde.DataLogic;
using Sinowyde.DataModel;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.HisData.Server.Properties;
using Sinowyde.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.HisData.Server
{
    public class HisDataService
    {
        /// <summary>
        /// 模型监测线程，监视通讯模型
        /// </summary>
        private CheckModel checkModel = null;
        /// <summary>
        /// 订阅数据线程，订阅IO采集数据
        /// </summary>
        private SubscribeThreadPool subscribe = null;
        /// <summary>
        /// 数据存储线程
        /// </summary>
        private RTSaveThread rtSave = null;

        public HisDataService()
        {
            //监测通讯模型，订阅更新事件
            checkModel = new CheckModel(DOPDataLogic.Instance(), ModelType.Communication);
            checkModel.UpdateModelEvent += checkModel_UpdateModelEvent;

            //数据订阅
            subscribe = new SubscribeThreadPool(Settings.Default.Publish, Settings.Default.Topic.Split(','));
            subscribe.EventSubscribe += subscribe_EventSubscribe;


            //保存
            rtSave = new RTSaveThread();
        }

        private void checkModel_UpdateModelEvent()
        {
            var startTime = DateTime.Now;
            LogUtil.LogInfo("==>开始更新准备字典！" + startTime);
            Console.WriteLine("==>开始更新准备字典！" + startTime);

            rtSave.Stop();

            IList<Variable> variables = DOPDataLogic.Instance().Query<Variable>(null, null, 0, 0);
            RTSaveThread.VarSpecMap.Clear();
            foreach (Variable variable in variables)
            {
                RTSaveThread.VarSpecMap.Add(variable.Number, variable);
            }

            rtSave.Start();

            var endTime = DateTime.Now;
            Console.WriteLine("==>结束更新准备字典！" + endTime + "总用时：" + (endTime - startTime).TotalSeconds + "秒");
            LogUtil.LogInfo("==>结束更新准备字典！" + endTime + "总用时：" + (endTime - startTime).TotalSeconds + "秒");
        }

        /// <summary>
        /// 获取订阅数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void subscribe_EventSubscribe(object sender, SubscribePoolEventArgs arg)
        {
            try
            {
                IList<string> messages = arg.Messages;
                foreach (string message in messages)
                {
                    rtSave.AddRTValue(RTValue.FromString(message));
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("订阅数据解析出现错误", ex);
            }
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <returns></returns>
        public bool StartService()
        {
            checkModel.Start();
            subscribe.Start();

            return true;
        }
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        public bool StopService()
        {
            checkModel.Stop();
            subscribe.Stop();
            rtSave.Stop();
            return true;
        }
    }
}
