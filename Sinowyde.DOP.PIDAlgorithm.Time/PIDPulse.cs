
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 6.9脉冲整形算法块（PULSE）8f0d8
    /// </summary>
    [Serializable]
    public class PIDPulse : PIDBindAlgorithm
    {  ///<summary>
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

        /// <summary>
        /// 初始时间标记
        /// </summary>
        protected DateTime InitTime = DateTime.MinValue;
        /// <summary>
        /// 与初始时间标记偏差
        /// </summary>
        /// <returns></returns>
        public double GetInitDT()
        {
            return (DateTime.MinValue == InitTime) ? 0 :
                (CurrentCalcTime - InitTime).TotalSeconds;
        }

        protected override void ResetEnvVars()
        {
            base.ResetEnvVars();
            this.InitTime = DateTime.MinValue;
        }
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDELAY] = new PIDAlgorithmParam(ParamDELAY);
        }
        /// <summary>
        /// 
        /// </summary>
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
            if (this.calcInputs[InputDI].ValueToBool())
            {
                if (this.InitTime == DateTime.MinValue)
                {
                    this.InitTime = DateTime.Now;
                    this.calcResults[ResultDO].Value = 1;
                }
                else 
                {
                    if (GetInitDT() <= this.calcParams[ParamDELAY].Value)
                    {
                        this.calcResults[ResultDO].Value = 1;
                    }
                    else
                    {
                        this.calcResults[ResultDO].Value = 0;
                    }
                }
                
            }
            else
            {
                this.calcResults[ResultDO].Value = 0;
                this.InitTime = DateTime.MinValue;
            }
        }

        public override string AlgName
        {
            get { return "脉冲整形算法块"; }
        }
    }
}