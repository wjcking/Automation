using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    ///开方
    /// </summary>
    [Serializable]
    public class PIDSqrt : PIDBindAlgorithm
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
        ///Zero 零点切除值（不等于 0） 
        /// </summary> 
        public const string ParamZero = PIDAlgorithmToken.prefixParam + "Zero";
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
            get { return "开方算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamZero] = new PIDAlgorithmParam(ParamZero,0.001);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK,1.0);
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
        /// 设置零点切除值 Zero，目的是实现小信号切除。
        ///若 AI＞Zero 则 += BiasAIkAO ；
        ///否则 AO=0
        /// </summary>
        protected override void InternalDoCalc()
        {
            double ai = calcInputs[InputAI].Value;
            double k = calcParams[ParamK].Value;
            double zero = calcParams[ParamZero].Value;
            if (ai > zero)
                this.calcResults[Result].Value = k * System.Math.Sqrt(ai) + Convert.ToDouble(calcParams[ParamBias].Value);
            else
                this.calcResults[Result].Value = 0;
        }
    }
}
