using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.Alarm.Server.Tasks;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DataLogic;
using Sinowyde.Log;
using Sinowyde.Util;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.Alarm.Server.Properties;
using Sinowyde.DataModel;

namespace Sinowyde.DOP.Alarm.Server
{
    public class AlarmService
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
        /// 报警处理线程，计算报警并入库
        /// </summary>
        private AlarmTask alarmTask = null;

        public AlarmService()
        {
            //监测通讯模型，订阅更新事件
            checkModel = new CheckModel(DOPDataLogic.Instance(), ModelType.Communication);
            checkModel.UpdateModelEvent += checkModel_UpdateModelEvent;

            subscribe = new SubscribeThreadPool(Settings.Default.Publish, Settings.Default.Topic.Split(','));
            subscribe.EventSubscribe += subscribe_EventSubscribe;

            alarmTask = new AlarmTask();
        }

        private void checkModel_UpdateModelEvent()
        {
            var startTime = DateTime.Now;
            LogUtil.LogInfo("==>开始更新准备字典！" + startTime);
            Console.WriteLine("==>开始更新准备字典！" + startTime);

            UpdateDataMemCacheAlarmRule();

            var endTime = DateTime.Now;
            Console.WriteLine("==>结束更新准备字典！" + endTime + "总用时：" + (endTime - startTime).TotalSeconds + "秒");
            LogUtil.LogInfo("==>结束更新准备字典！" + endTime + "总用时：" + (endTime - startTime).TotalSeconds + "秒");
        }

        private void subscribe_EventSubscribe(object sender, SubscribePoolEventArgs arg)
        {
            IList<string> messages = arg.Messages;
            foreach (string message in messages)
            {
                alarmTask.AddRTValue(RTValue.FromString(message));
            }
        }

        private void AddRulesToMap(DataMemCache<string, IList<AlarmRule>> map, AlarmRule rule)
        {
            var rules = map.Get(rule.Variable.Number);
            if (null != rules)
            {
                rules.Add(rule);
            }
            else
            {
                rules = new List<AlarmRule>();
                rules.Add(rule);
                map.Add(rule.Variable.Number, rules);
            }
        }

        private void UpdateDataMemCacheAlarmRule()
        {
            //初始化报警规则
            AlarmTask.AlarmRuleMap.Clear();
            var alarmRules = DOPDataLogic.Instance().Query<AlarmRule>(null, null, 0, 0);
            foreach (var rule in alarmRules)
            {
                AddRulesToMap(AlarmTask.AlarmRuleMap, rule);
            }
        }

        public bool StartService()
        {
            checkModel.Start();
            subscribe.Start();
            alarmTask.Start();
            return true;
        }

        public bool StopService()
        {
            checkModel.Stop();
            subscribe.Stop();
            alarmTask.Stop();
            return true;
        }
    }
}
