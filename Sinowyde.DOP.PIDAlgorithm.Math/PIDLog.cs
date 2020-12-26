using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    /// 对数算法块（ Log） Logarithm
    /// </summary>
    [Serializable]
    public class PIDLog : PIDBindAlgorithm
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
            get { return "对数算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamA] = new PIDAlgorithmParam(ParamA, 2.718);
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
        ///       、功能说明
        ///该算法完成自然对数和常用对数运算。
        ///5、算法说明
        ///当 AI＞0 时， •= log a ( ) + BiasAIkAO
        ///当 AI≤0 时， AO=0
        /// </summary>
        protected override void InternalDoCalc()
        {
            double ai = ConvertUtil.ConvertToDouble(calcInputs[InputAI].Value, 0);
            double k = ConvertUtil.ConvertToDouble(calcParams[ParamK].Value, 1);
            double a = ConvertUtil.ConvertToDouble(calcParams[ParamA].Value, 1);

            if (ai > 0)
                this.calcResults[Result].Value = k * System.Math.Log(ai,a) + calcParams[ParamBias].Value;
            else if (ai <=0)
                this.calcResults[Result].Value = 0;


        }
    }
}
