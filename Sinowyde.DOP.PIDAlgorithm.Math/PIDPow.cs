﻿using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    /// 幂函数算法块（ EXP） Exponent
    /// </summary>
    [Serializable]
    public class PIDPow : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 偏置
        /// </summary>
        public const string ParamBias = PIDAlgorithmToken.prefixParam + "Bias";
        /// <summary>
        /// 底数
        /// </summary>
        public const string ParamA = PIDAlgorithmToken.prefixParam + "A";
        /// <summary>
        /// k 系数（不等于 0） 
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "幂函数算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamA] = new PIDAlgorithmParam(ParamA, 1.0);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1.0);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);

        }


        /// <summary>
        /// AO = K * pow(a,ai) +bias
        /// </summary>
        protected override void InternalDoCalc()
        {
            double ai = ConvertUtil.ConvertToDouble(calcInputs[InputAI].Value, 0);
            double k = ConvertUtil.ConvertToDouble(calcParams[ParamK].Value, 1);
            double a = ConvertUtil.ConvertToDouble(calcParams[ParamA].Value, 1);

            this.calcResults[Result].Value = k * System.Math.Pow(ai, a) + Convert.ToDouble(calcParams[ParamBias].Value);

        }
    }
}
