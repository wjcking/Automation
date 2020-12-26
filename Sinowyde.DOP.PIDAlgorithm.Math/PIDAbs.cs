using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    ///绝对值
    /// </summary>
    [Serializable]
    public class PIDAbs : PIDBindAlgorithm
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
        /// k 系数（不等于 0） 
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "绝对值算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK,1.0);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] =new PIDAlgorithmVar(InputAI,0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);
        }
        /// <summary>
        /// AO = k|AI| + Bias 
        /// </summary>
        protected override void InternalDoCalc()
        {
            double ai = calcInputs[InputAI].Value;
            double k =  calcParams[ParamK].Value ;

            this.calcResults[Result].Value = k * System.Math.Abs(ai) + calcParams[ParamBias].Value;

        }
    }
}
