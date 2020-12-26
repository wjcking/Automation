
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 锯齿波信号算法块（Sawtooth）Sawtooth wave Signal2a40e
    /// </summary>
    [Serializable]
    public class PIDSawtooth : PIDBindSignalAlgorithm
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
        /// 波宽
        /// </summary>
        public const string ParamWidth = PIDAlgorithmToken.prefixParam + "Width";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmParam(ParamHigh,1.0);
            this.calcParams[ParamLow] = new PIDAlgorithmParam(ParamLow);
            this.calcParams[ParamWidth] = new PIDAlgorithmParam(ParamWidth,100.0);
        }

        /// <summary>
        ///4、功能说明
        ///以一定的波峰、波谷及波宽发出一个持续的锯齿波，波峰和波谷可以为负，但波峰必须
        ///大于波谷。
        ///5、算法说明
        ///如果 DI=1,
        ///AO = High-(Width-t)(High-Low)/Width (0≤t≤Width)
        ///AO=0 (t＜0 或 t＞Width)
        ///t —— 时间变量
        ///如果 DI=0
        ///AO = 0
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;
            double width = this.calcParams[ParamWidth].Value;
            double t = this.GetInitDT();

            //整数 0 到 最大值
            if (0 <= t && t < width)
            {
                this.calcResults[ResultAO].Value = high - (width - t) * (high - low) / width;
            }
            else if (t >= width)
            {
                this.calcResults[ResultAO].Value = low;
                this.InitTime = DateTime.MinValue;
            }
        }

        public override string AlgName
        {
            get { return "锯齿波信号算法块"; }
        }
    }
}