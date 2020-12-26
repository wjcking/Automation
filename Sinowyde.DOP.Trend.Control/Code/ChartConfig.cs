using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Trend.Control
{
    public static class ChartConfig
    {
        private static int maxVariableCount = 8;

        private static int pollingPeriod = 1000;

        private static string realTimeCurveRange = "1小时";
       

        private static int lastValueDate = 1;

        /// <summary>
        /// 报表最大变量个数
        /// 默认：8
        /// </summary>
        public static int MaxVariableCount
        {
            get { return maxVariableCount; }
            set { maxVariableCount = value; }
        }

        /// <summary>
        /// 刷新周期
        /// </summary>
        public static int PollingPeriod
        {
            get { return pollingPeriod; }
            set { pollingPeriod = value; }
        }
        
        /// <summary>
        /// 实时曲线范围
        /// </summary>
        public static string RealTimeCurveRange
        {
            get { return realTimeCurveRange; }
            set { realTimeCurveRange = value; }
        }


        /// <summary>
        /// 距上一次数据的时间间隔(秒)
        /// </summary>
        public static int LastValueDate 
        {
            get { return lastValueDate; }
            set { lastValueDate = value; }
        }

        static ChartConfig()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["MaxVariableCount"] != null)
            {
                string val = System.Configuration.ConfigurationManager.ConnectionStrings["MaxVariableCount"].ConnectionString;
                if (!int.TryParse(val, out maxVariableCount))
                {
                    maxVariableCount = 8;
                }
            }
        }

    }
}
