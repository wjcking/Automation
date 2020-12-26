using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.HisData.Server
{    
    public class RTSaveThread : ServiceThread
    {
        /// <summary>
        /// 变量缓存
        /// </summary>
        public static DataMemCache<string, Variable> VarSpecMap =
            new DataMemCache<string, Variable>();//变量规格列表

        public static DataMemCache<string, RTValue> VarTimeMap =
            new DataMemCache<string, RTValue>();//变量存储时间

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


        public RTSaveThread()
            : base(100, 60 * 1000)
        {
        }

        /// <summary>
        /// 周期计算报警数据并存储
        /// 每轮处理50个数据
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            try
            {
                var rtValueList = valueBuffer.GetAllData();
                foreach (var rtValue in rtValueList)
                {
                    Variable variable = VarSpecMap.Get(rtValue.VarNumber);
                    if (variable == null)
                        continue;
                    RTValue value = VarTimeMap.Get(rtValue.VarNumber);
                    //第一获取数据存储
                    if (value == null)
                    {
                        DOPDataLogic.Instance().Insert(rtValue);
                        VarTimeMap.Add(rtValue.VarNumber, rtValue);
                        Console.Write(string.Format("{0}{1}", rtValue.VarNumber, rtValue.Timestamp));
                        continue;
                    }
                    else
                    {
                        //超过最长存储周期，保存
                        if((rtValue.Timestamp - value.Timestamp).Milliseconds > variable.MaxPeriod)
                        {
                            DOPDataLogic.Instance().Insert(rtValue);
                            VarTimeMap.Add(rtValue.VarNumber, rtValue);
                            Console.Write(string.Format("{0}{1}", rtValue.VarNumber, rtValue.Timestamp));
                            continue;
                        }
                        //变化率超过限值，保存
                        if(!variable.IsCompressed ||
                            (Math.Abs(rtValue.Value - value.Value)/value.Value >= (double)(variable.CompressRatio)))
                        {
                            DOPDataLogic.Instance().Insert(rtValue);
                            VarTimeMap.Add(rtValue.VarNumber, rtValue);
                            Console.Write(string.Format("{0}{1}", rtValue.VarNumber, rtValue.Timestamp));
                            continue;
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("写入实时数据失败", ex);//失败数据直接扔掉
                return false;
            }

            return true;
        }
    }
}
