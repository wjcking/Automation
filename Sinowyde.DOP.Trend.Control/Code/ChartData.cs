using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.DataModel;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;

namespace Sinowyde.DOP.Trend.Control
{
    public enum DataState
    {
        Add,
        Modify,
        Delete
    }

    public class ChartData
    {
        private static object _lock = new object();

        public ChartData()
        {
            this.variable = new Variable();
        }

        #region 内部使用

        private Variable variable = new Variable();
        private double minValue = 0;
        private double maxValue = 100;
        private Color color = Color.Black;
        private string lineType = "Solid";

        private List<RTValueEx> rtValueExList = new List<RTValueEx>();
        /// <summary>
        /// 缓存当前点的2小时内的数据
        /// </summary>
        public List<RTValueEx> RTValueExList { get { return rtValueExList; } }

        public bool AddRTValue(RTValueEx item)
        {
            bool result = true;
            if (rtValueExList == null)
                rtValueExList = new List<RTValueEx>();

            if (rtValueExList.Count > 0)
            {
                lock (_lock)
                {
                    RTValueEx lastEntity = rtValueExList.Last();
                    DateTime t1 = Convert.ToDateTime(lastEntity.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    DateTime t2 = Convert.ToDateTime(item.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    //DateTime t3 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //Console.WriteLine(string.Format("Add -> last:{0},item:{1},now:{2}", t1, t2, t3));
                    //if (t1.Ticks != t2.Ticks && t2.AddSeconds(ChartConfig.LastValueDate).Ticks < t3.Ticks)
                    if (t1.Ticks != t2.Ticks &&  t1.AddSeconds(ChartConfig.LastValueDate).Ticks <= t2.Ticks)
                    {
                        rtValueExList.Add(item);
                    }
                    else { result = false; }
                }
            }
            else
            {
                rtValueExList.Add(item);
            }

            #region
            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //int lastCount = this.rtValueExList.Count;
            int count = rtValueExList.RemoveAll(o => Convert.ToDateTime(o.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")).AddHours(2).Ticks < Convert.ToDateTime(strNow).Ticks);
            //Console.WriteLine(string.Format("Delete(2小时) -> 原Count:{0},删Count:{1}", lastCount, count));
            #endregion

            return result;
        }
        /// <summary>
        /// 缓存ChartConfig.realTimeCurveRange中设置的数据
        /// </summary>
        public List<RTValueEx> CurrentRTValueExList
        {
            get
            {
                if (rtValueExList.Count <= 0)
                    return new List<RTValueEx>();

                DateTime date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                switch (ChartConfig.RealTimeCurveRange)
                {
                    case "5分钟":
                        date = date.AddMinutes(-5);
                        break;
                    case "10分钟":
                        date = date.AddMinutes(-10);
                        break;
                    case "15分钟":
                        date = date.AddMinutes(-15);
                        break;
                    case "30分钟":
                        date = date.AddMinutes(-30);
                        break;
                    case "1小时":
                        date = date.AddHours(-1);
                        break;
                    case "2小时":
                        date = date.AddHours(-2);
                        break;
                    default:
                        date = date.AddMinutes(-2);
                        break;
                }
                return rtValueExList.Where(o => Convert.ToDateTime(o.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")).Ticks >= date.Ticks).ToList();
            }
        }

        #endregion

        #region 对外公开属性

        /// <summary>
        /// 变量
        /// </summary>
        public Variable Variable
        {
            get { return variable; }
            set { variable = value; }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        public double MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        /// <summary>
        /// 颜色【默认 Black】
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// 线型
        /// </summary>
        public string LineType
        {
            get { return lineType; }
            set { lineType = value; }
        }

        #endregion
    }

    public class RTValueEx : RTValue
    {
        public string DatePeriod
        {
            get { return base.Timestamp.ToString("HH:mm:ss"); }
        }

        public static RTValueEx ToRTValueEx(RTValue item)
        {
            RTValueEx _this = new RTValueEx();
            _this.ID = item.ID;
            _this.Quality = item.Quality;
            _this.Timestamp = item.Timestamp;
            _this.Value = item.Value;
            _this.VarNumber = item.VarNumber;
            return _this;
        }
    }
}
