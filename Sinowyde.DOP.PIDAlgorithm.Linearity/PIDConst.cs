
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// 常系数算法块（CONST） 
    /// </summary>
    [Serializable]
    public class PIDConst : PIDBindAlgorithm
    {  ///<summary>
        /// 常系数值
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// 输入值
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

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
        ///该模块进行比率运算。
        ///5、算法说明
        ///AO=K*AI 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            this.calcResults[ResultAO].Value = this.calcParams[ParamK].Value * this.calcInputs[InputAI].Value;
        }

        public override string AlgName
        {
            get { return "常系数算法块"; }
        }
    }
}