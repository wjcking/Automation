
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 6.7延时开算法块（DelayOn）aa6d6
    /// </summary>
    [Serializable]
    public class PIDDelayon : PIDBindTimerAlgorithm
    {
        ///<summary>
        /// 延时时间
        /// </summary>
        public const string ParamDELAY = PIDAlgorithmToken.prefixParam + "DELAY";
        ///<summary>
        /// 使能端
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        private double lastDI = 0;
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDELAY] = new PIDAlgorithmParam(ParamDELAY);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary> 
        ///4、 功能说明
        ///设定延时时间输出数字量从 0 到 1
        ///5、算法说明
        ///可以设定非整数秒时间
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double di = this.calcInputs[InputDI].Value;
            this.calcResults[ResultDO].Value = di;
            this.lastDI = di;
        }
        /// <summary>
        /// 设置周期
        /// </summary>
        protected override void SetTimerPeriod()
        {
            double di = this.calcInputs[InputDI].Value;
            if (this.FirstCalcTime == DateTime.MinValue)
            {
                this.period = 0;
            }
            else
            {
                if (lastDI == 0 && di == 1)
                {
                    this.period = this.calcParams[ParamDELAY].Value*1000;
                }
                else
                {
                    this.period = 0;
                }
            }            
        }

        public override string AlgName
        {
            get { return "延时开算法块"; }
        }

    }
}