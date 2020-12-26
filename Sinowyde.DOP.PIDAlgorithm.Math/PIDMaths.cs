using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    ///  数学多项式算法块（ MATHS） Maths
    /// </summary>
    [Serializable]
    public class PIDMaths : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// k 系数 
        /// </summary>
        public const string ParamK0 = PIDAlgorithmToken.prefixParam + "K0";
        public const string ParamK1 = PIDAlgorithmToken.prefixParam + "K1";
        public const string ParamK2 = PIDAlgorithmToken.prefixParam + "K2";
        public const string ParamK3 = PIDAlgorithmToken.prefixParam + "K3";
        public const string ParamK4 = PIDAlgorithmToken.prefixParam + "K4";
        public const string ParamK5 = PIDAlgorithmToken.prefixParam + "K5";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 用于迭代计算和判断个数
        /// </summary>
        private const string KPrefix = PIDAlgorithmToken.prefixParam + "K";
        private const ushort KCount = 6;

        public override string AlgName
        {
            get { return "数学多项式算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK0] = new PIDAlgorithmParam(ParamK0);
            this.calcParams[ParamK1] = new PIDAlgorithmParam(ParamK1);
            this.calcParams[ParamK2] = new PIDAlgorithmParam(ParamK2);
            this.calcParams[ParamK3] = new PIDAlgorithmParam(ParamK3);
            this.calcParams[ParamK4] = new PIDAlgorithmParam(ParamK4);
            this.calcParams[ParamK5] = new PIDAlgorithmParam(ParamK5);
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
        /// AO=k0+
        /// k1*AI+
        /// k2*(AI)2+
        /// k3*(AI)3+
        /// k4*(AI)4+
        /// k5*(AI)5
        /// </summary>
        protected override void InternalDoCalc()
        {
            double ai = ConvertUtil.ConvertToDouble(calcInputs[InputAI].Value);
            //初始值=k0
            double val = ConvertUtil.ConvertToDouble(calcParams[ParamK0].Value);
            double k = 0.0f;
            double pow = 0.0f;
            for (int i = 1; i < KCount; i++)
            {
                k = calcParams[KPrefix + i.ToString()].Value;
                pow =  System.Math.Pow(ai, i);
                val += k * pow;
            }
            calcResults[Result].Value = val;
        }
    }
}
