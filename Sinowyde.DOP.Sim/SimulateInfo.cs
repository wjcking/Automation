using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Sim
{
    /// <summary>
    /// 设置模拟数据参数
    /// </summary>
    public class SimulateInfo
    {
        /// <summary>
        /// 手动输出则发送一次
        /// </summary>
        public const short CType_Manual = 0;
        public SimulateInfo()
        {

        }

        /// <summary>
        /// 如果已经完成赋值操作则为true，手动赋值后则为false只发送一次数据
        /// </summary>
        public bool IsOperated { get; set; }
        public short Type { get; set; }
        public int Interval { get; set; }
        public double Step { get; set; }

        public int RangeMax { get; set; }
        public int RangeMin { get; set; }

        private double value = 0;
        public double Value
        {
            get
            {
                if (Type != CType_Manual)
                {
                    if (value > RangeMax)
                        value = RangeMin;
                    else if (value < RangeMin)
                        value = RangeMax;
                }

                switch (Type)
                {
                    case 1:
                        Random rand = new Random();
                        int num = rand.Next(RangeMin, RangeMax);
                        return num + rand.Next(0,99)  * 0.01;
                    case 2:
                        value += Step;
                        break;
                    case 3:
                        value -= Step;
                        break;
                    case CType_Manual:
                    default:
                        return value;
                }

                return value;
            }
            set { this.value = value; }
        }

        public SimulateInfo Clone()
        {
            return new SimulateInfo()
            {
                Value = this.value,
                Step = this.Step,
                Interval = this.Interval,
                IsOperated = this.IsOperated,
                Type = this.Type,
                RangeMax = this.RangeMax,
                RangeMin = this.RangeMin
            };
        }
    }
}
