
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 方波信号算法块（Square）Square wave 
    /// </summary>
    [Serializable]
    public class PIDSquare : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// 波峰
        /// </summary>
        public const string ParamHigh = PIDAlgorithmToken.prefixParam + "High";
        ///<summary>
        /// 波谷
        /// </summary>
        public const string ParamLow = PIDAlgorithmToken.prefixParam + "Low";
        ///<summary>
        /// 方波宽度
        /// </summary>
        public const string ParamWidth = PIDAlgorithmToken.prefixParam + "Width";
        
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmParam(ParamHigh,1.0);
            this.calcParams[ParamLow] = new PIDAlgorithmParam(ParamLow);
            this.calcParams[ParamWidth] = new PIDAlgorithmParam(ParamWidth,1.0);
        }
        /// <summary>
        ///4、功能说明
        ///以一定的波峰、波谷及波宽发出一个持续的方波，波峰和波谷可以为负，但波峰必须大于波谷。
        ///5、算法说明
        ///如果 DI=1，
        ///AO = High 2*i*Width ≤ t ＜ (2*i+1)*Width (i=0,1,2, …..)
        ///AO = Low (2*i+1)*Width ≤ t ＜ (2*i+2)*Width (i=0,1,2, …..)
        ///如果 DI=0，
        ///AO = 0
        /// </summary>
        protected override void SignalInternalDoCalc()
        {          
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;
            double width = this.calcParams[ParamWidth].Value;

            double t = this.GetInitDT();
            while (true)
            {
                //整数 0 到 最大值
                if (2 * inc * width <= t && t < (2 * inc + 1) * width)
                {
                    this.calcResults[ResultAO].Value = high;
                    break;
                }
                else if ((2 * inc + 1) * width <= t && t < (2 * inc + 2) * width)
                {
                    this.calcResults[ResultAO].Value = low;
                    break;
                }
                else
                {
                    if (inc == int.MaxValue)
                    {
                        inc = 0;
                        this.InitTime = DateTime.MinValue;
                    }
                    else
                    {
                        inc++;
                    }
                }
            }
        }

        public override string AlgName
        {
            get { return "方波信号算法块"; }
        }
    }
}