using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{

    /// <summary>
    /// 开关算法块（ SWITCH） Switch
    /// </summary>
    [Serializable]
    public class PIDSwitch : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// Bias 输入偏置
        /// </summary>
        public const string ParamBias = PIDAlgorithmToken.prefixParam + "Bias";

        /// <summary>
        /// D 死区宽度  
        /// </summary>
        public const string ParamD = PIDAlgorithmToken.prefixParam + "D";
        /// <summary>
        /// Y 输出 Y
        /// </summary>
        public const string ParamY = PIDAlgorithmToken.prefixParam + "Y";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "开关算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamD] = new PIDAlgorithmParam(ParamD, 1.0);
            this.calcParams[ParamY] = new PIDAlgorithmParam(ParamY, 1.0);
        }
        /// <summary>
        /// 
        /// </summary>
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
        ///   当 AI≥ D＋Bias 时， AO＝Y；
        /// 当 AI≤－D＋Bias 时， AO＝－Y
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ai = calcInputs[InputAI].Value;
            double bias = calcParams[ParamBias].Value;
            double d = calcParams[ParamD].Value;
            double y = calcParams[ParamY].Value;
            if (ai >= d + bias)
                calcResults[Result].Value = y;
            else if (ai <= bias - d)
                calcResults[Result].Value = -y;
            else
                calcResults[Result].Value = 0;

        }
    }
}
