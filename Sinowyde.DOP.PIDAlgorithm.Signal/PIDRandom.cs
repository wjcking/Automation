
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 随机信号算法块（Random）Random Signale9980
    /// </summary>
    [Serializable]
    public class PIDRandom : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// 信号上线
        /// </summary>
        public const string ParamHigh = PIDAlgorithmToken.prefixParam + "High";
        ///<summary>
        /// 信号下线
        /// </summary>
        public const string ParamLow = PIDAlgorithmToken.prefixParam + "Low";

        /// <summary>
        /// 随机数最大值 老的c++里面的定义
        /// </summary>
        private const int RAND_MAX = 0x7fff;
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmParam(ParamHigh,1.0);
            this.calcParams[ParamLow] = new PIDAlgorithmParam(ParamLow,-1.0);
        }

        /// <summary>
        ///4、功能说明
        ///如果 DI=1，  = randAO RAND MAX ⋅ (_/() − ) + LowLowHigh
        ///其中： ——随机数产生函数； rand()
        ///RAND _ MAX ——最大随机数值（机器内定义）；
        ///High ——信号上限； ——信号下限。 Low
        ///如果 DI=0，
        ///AO = 0
        ///</summary>  
        protected override void SignalInternalDoCalc()
        {
            int high = ConvertUtil.ConvertToInt(this.calcParams[ParamHigh].Value);
            int low = ConvertUtil.ConvertToInt(this.calcParams[ParamLow].Value);
            //Random rand = new Random();
            //this.calcResults[ResultAO].Value = rand.Next(low, high) / RAND_MAX * (high - low) + low;
            if (this.calcInputs[InputDI].ValueToBool())
            {
                Random rand = new Random();
                this.calcResults[ResultAO].Value = rand.Next(low*100, high*100) / 100.0 ;// RAND_MAX * (high - low) + low;
            }
            else
            {
                this.calcResults[ResultAO].Value = 0;
            }

        }

        public override string AlgName
        {
            get { return "随机信号算法块"; }
        }
    }
}