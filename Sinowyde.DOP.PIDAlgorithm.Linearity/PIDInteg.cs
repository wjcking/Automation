
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// 积分算法块（INTEG）
    /// </summary>
    [Serializable]
    public class PIDInteg : PIDBindAlgorithm
    {  ///<summary>
        /// 常系数
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        private double lastAI = 0;
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
        }
        /// <summary>
        /// 初始化输入参数 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }
        /// <summary>
        ///4、功能说明
        ///该模块对模拟量输入求积分，积分速率为 K。
        ///5、算法说明
        ///AO = K ? AI
        ///s 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            double ai = this.calcInputs[InputAI].Value;

            if (GetDt() > 0)
            {
                this.calcResults[ResultAO].Value += GetDt() * k * (ai + lastAI) / 2;
            }
            lastAI = ai;
        }

        public override string AlgName
        {
            get { return "积分算法块"; }
        }
    }
}