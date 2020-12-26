using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    ///除法
    /// </summary>
    [Serializable]    
    public class PIDDiv : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";

        /// <summary>
        /// AI2输入参数
        /// </summary>
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        /// <summary>
        /// ParamK1
        /// </summary>
        public const string ParamK1 = PIDAlgorithmToken.prefixParam + "K1";
        /// <summary>
        /// ParamK2
        /// </summary>
        public const string ParamK2 = PIDAlgorithmToken.prefixParam + "K2";
        /// <summary>
        /// 偏置
        /// </summary>
        public const string ParamBias = PIDAlgorithmToken.prefixParam + "Bias";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "除法算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK1] = new PIDAlgorithmParam(ParamK1,1.0);
            this.calcParams[ParamK2] = new PIDAlgorithmParam(ParamK2, 1.0);
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 1.0, PIDVarInputType.Init, PIDVarDataType.AM); 
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 1.0, PIDVarInputType.Init, PIDVarDataType.AM); 
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);

        }
        /// <summary>
        /// AI2 初值默认为 1；
        ///   初始化 AI1， AI2， AO；
        ///   若 AI2＝0， AO=AO(n-1) 注： AO(n-1)为前一采样时刻输出。
        ///   若 AI2≠0， AO=（ AI1*k1） /（ AI2*k2） +Bias 
        /// </summary>
        /// <returns></returns> 
        protected override void InternalDoCalc()
        {
            //double ai1 = calcParams[InputAI1].Value * ConvertUtil.ConvertToDouble(calcParams[ParamK1].Value, 1);
            //double ai2 = calcParams[InputAI2].Value * ConvertUtil.ConvertToDouble(calcParams[ParamK2].Value, 1);

            double ai1 = calcInputs[InputAI1].Value * calcParams[ParamK1].Value;
            double ai2 = calcInputs[InputAI2].Value * calcParams[ParamK2].Value;

            if (ai2 != 0)
                this.calcResults[Result].Value = ai1 / ai2 + calcParams[ParamBias].Value;
            //else
            //    this.calcResults[Result] = 
        }
    }
}
