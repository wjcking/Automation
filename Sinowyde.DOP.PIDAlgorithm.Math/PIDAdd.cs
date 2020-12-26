using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    /// 加法算法
    /// </summary>
    [Serializable]
    public class PIDAdd : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        public const string InputAI3 = PIDAlgorithmToken.prefixInput + "AI3";
        public const string InputAI4 = PIDAlgorithmToken.prefixInput + "AI4";
        /// <summary>
        /// 系数
        /// </summary>
        public const string ParamK1 = PIDAlgorithmToken.prefixParam + "K1";
        public const string ParamK2 = PIDAlgorithmToken.prefixParam + "K2";
        public const string ParamK3 = PIDAlgorithmToken.prefixParam + "K3";
        public const string ParamK4 = PIDAlgorithmToken.prefixParam + "K4";

        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "加法算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK1] = new PIDAlgorithmParam(ParamK1, 1.0);
            this.calcParams[ParamK2] = new PIDAlgorithmParam(ParamK2, 1.0);
            this.calcParams[ParamK3] = new PIDAlgorithmParam(ParamK3, 1.0);
            this.calcParams[ParamK4] = new PIDAlgorithmParam(ParamK4, 1.0);
        }
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI3] = new PIDAlgorithmVar(InputAI3, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI4] = new PIDAlgorithmVar(InputAI4, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);
        }

        /// <summary>
        /// 计算，如何设置结果输出 AO=AI1*k1+AI2*k2+ AI3*k3+ AI4*k4。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ai1 = calcInputs[InputAI1].Value * calcParams[ParamK1].Value;
            double ai2 = calcInputs[InputAI2].Value * calcParams[ParamK2].Value;
            double ai3 = calcInputs[InputAI3].Value * calcParams[ParamK3].Value;
            double ai4 = calcInputs[InputAI4].Value * calcParams[ParamK4].Value;

            this.calcResults[Result].Value = ai1 + ai2 + ai3 + ai4;
        }
    }
}
