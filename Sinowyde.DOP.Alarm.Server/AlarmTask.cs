using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.Util;
using NHibernate.Criterion;

namespace Sinowyde.DOP.Alarm.Server.Tasks
{
    /// <summary>
    /// 报警服务
    /// </summary>
    public class AlarmTask : ServiceTask
    {
        /// <summary>
        /// 报警规则缓存
        /// </summary>
        public static DataMemCache<string, IList<AlarmRule>> AlarmRuleMap = new DataMemCache<string, IList<AlarmRule>>();

        /// <summary>
        /// 历史报警缓存
        /// key = VarNumber|Type|Level
        /// </summary>
        private static DataMemCache<string, DateTime> rtAlarmMap = new DataMemCache<string, DateTime>();

        /// <summary>
        /// 历史事件缓存
        /// key = VarNumber|Type|Level
        /// </summary>
        private static DataMemCache<string, DateTime> rtEventMap = new DataMemCache<string, DateTime>();

        /// <summary>
        /// 采集数据缓存
        /// </summary>
        private BufferManager<RTValue> valueBuffer = new BufferManager<RTValue>();

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="value"></param>
        public void AddRTValue(RTValue value)
        {
            if (value != null)
                valueBuffer.Add(value);
        }

        public AlarmTask()
            : base(100, 60 * 1000)
        {

        }

        /// <summary>
        /// 周期计算报警数据并存储
        /// 每轮全部处理
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            try
            {
                var rtValueList = valueBuffer.GetAllData();
                foreach (var rtValue in rtValueList)
                {
                    Console.WriteLine(string.Format("==>AlarmTaskDoWork() valueBuffer.Data.Count:{0} {1}",
                                                    rtValueList.Count, rtValue.Timestamp));
                    CalcAlarmEvent(rtValue);
                }
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("AlarmTask写入事件失败:", ex); //失败数据直接扔掉
                Console.WriteLine("AlarmTask写入事件失败:" + ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 计算报警事件
        /// </summary>
        /// <param name="rtValue"></param>
        private void CalcAlarmEvent(RTValue rtValue)
        {
            var alarmRuleList = AlarmRuleMap.Get(rtValue.VarNumber);
            if (null == alarmRuleList)
                return;

            foreach (var rule in alarmRuleList)
            {
                if (rule.RecordAsEvent)//记录事件
                    CalcEvent(rule, rtValue);
                else //记录报警
                    CalcAlarm(rule, rtValue);
            }
        }

        private void CalcAlarm(AlarmRule rule, RTValue rtValue)
        {
            var key = string.Format("{0}|{1}|{2}", rtValue.VarNumber, rule.AlarmType, rule.AlarmLevel);
            var lastTimestamp = rtAlarmMap.Get(key);
            if ((rtValue.Timestamp - lastTimestamp).TotalSeconds >= rule.TimeSpan)
            {
                var value = ConvertUtil.ConvertToDouble(rtValue.Value);
                switch (rule.AlarmType)
                {
                    case AlarmType.Low_Limit:
                        if (value <= rule.LimitValue)
                        {
                            DOPDataLogic.Instance().Insert(NewRtAlarm(rule, rtValue));
                            rtAlarmMap.Add(key, rtValue.Timestamp);
                            Console.WriteLine(string.Format("VarNumber:{0},RTimestamp:{1},处理完成间差{2}", rtValue.VarNumber, rtValue.Timestamp, (DateTime.Now - rtValue.Timestamp).TotalMilliseconds));
                        }
                        break;
                    case AlarmType.High_Limit:
                        if (value >= rule.LimitValue)
                        {
                            DOPDataLogic.Instance().Insert(NewRtAlarm(rule, rtValue));
                            rtAlarmMap.Add(key, rtValue.Timestamp);
                            Console.WriteLine(string.Format("VarNumber:{0},RTimestamp:{1},处理完成间差{2}", rtValue.VarNumber, rtValue.Timestamp, (DateTime.Now - rtValue.Timestamp).TotalMilliseconds));
                        }
                        break;
                    case AlarmType.Status:
                        if (value == rule.LimitValue)//float  0,1 状态量 可以判等
                        {
                            DOPDataLogic.Instance().Insert(NewRtAlarm(rule, rtValue));
                            rtAlarmMap.Add(key, rtValue.Timestamp);
                            Console.WriteLine(string.Format("VarNumber:{0},RTimestamp:{1},处理完成间差{2}", rtValue.VarNumber, rtValue.Timestamp, (DateTime.Now - rtValue.Timestamp).TotalMilliseconds));
                        }
                        break;
                    case AlarmType.Change:
                        break;
                }
            }
        }

        private void CalcEvent(AlarmRule rule, RTValue rtValue)
        {
            var key = string.Format("{0}|{1}|{2}", rtValue.VarNumber, rule.AlarmType, rule.AlarmLevel);
            var lastTimestamp = rtEventMap.Get(key);
            if ((rtValue.Timestamp - lastTimestamp).TotalSeconds >= rule.TimeSpan)
            {
                var value = ConvertUtil.ConvertToDouble(rtValue.Value);
                switch (rule.AlarmType)
                {
                    case AlarmType.Low_Limit:
                        if (value <= rule.LimitValue)
                        {
                            DOPDataLogic.Instance().Insert(NewRtEvent(rule, rtValue));
                            rtEventMap.Add(key, rtValue.Timestamp);
                            Console.WriteLine(string.Format("VarNumber:{0},RTimestamp:{1},处理完成间差{2}", rtValue.VarNumber, rtValue.Timestamp, (DateTime.Now - rtValue.Timestamp).TotalMilliseconds));
                        }
                        break;
                    case AlarmType.High_Limit:
                        if (value >= rule.LimitValue)
                        {
                            DOPDataLogic.Instance().Insert(NewRtEvent(rule, rtValue));
                            rtEventMap.Add(key, rtValue.Timestamp);
                            Console.WriteLine(string.Format("VarNumber:{0},RTimestamp:{1},处理完成间差{2}", rtValue.VarNumber, rtValue.Timestamp, (DateTime.Now - rtValue.Timestamp).TotalMilliseconds));
                        }
                        break;
                    case AlarmType.Status:
                        if (value == rule.LimitValue)//float  0,1 状态量 可以判等
                        {
                            DOPDataLogic.Instance().Insert(NewRtEvent(rule, rtValue));
                            rtEventMap.Add(key, rtValue.Timestamp);
                            Console.WriteLine(string.Format("VarNumber:{0},RTimestamp:{1},处理完成间差{2}", rtValue.VarNumber, rtValue.Timestamp, (DateTime.Now - rtValue.Timestamp).TotalMilliseconds));
                        }
                        break;
                    case AlarmType.Change:
                        break;
                }
            }
        }

        private static RTAlarm NewRtAlarm(AlarmRule alarmRule, RTValue rtValue)
        {
            return new RTAlarm
              {
                  VarNumber = rtValue.VarNumber,
                  Timestamp = rtValue.Timestamp,
                  Value = ConvertUtil.ConvertToFloat(rtValue.Value),
                  Level = alarmRule.AlarmLevel,
                  Type = alarmRule.AlarmType,
              };
        }

        private RTEvent NewRtEvent(AlarmRule alarmRule, RTValue rtValue)
        {
            return new RTEvent
              {
                  VarNumber = rtValue.VarNumber,
                  Timestamp = rtValue.Timestamp,
                  Value = ConvertUtil.ConvertToFloat(rtValue.Value),
                  Level = alarmRule.AlarmLevel,
                  Type = alarmRule.AlarmType,
                  EventType = alarmRule.EventType
              };
        }
    }
}
