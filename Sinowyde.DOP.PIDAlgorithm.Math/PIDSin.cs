using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    public enum TrigonometricFunc : ushort
    {
        Sin =1,
        Cos = 2,
        Tan = 3
    }


    /// <summary>
    /// 三角函数算法块（ SIN） Sine
    /// </summary>
    [Serializable]
    public class PIDSin : PIDBindAlgorithm
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
        ///  三角函数
        /// </summary>
        public const string ParamTrigonometricFunc = PIDAlgorithmToken.prefixParam + "TrigonometricFunc";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "三角函数算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1.0);
            this.calcParams[ParamTrigonometricFunc] = new PIDAlgorithmParam(ParamTrigonometricFunc, 1.0);
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
        /// 当 AI＞0 时， •= log a ( ) + BiasAIkAO
        /// 当 AI≤0 时， AO=0
        /// </summary>
        protected override void InternalDoCalc()
        {
            double ai = ConvertUtil.ConvertToDouble(calcInputs[InputAI].Value);
            double k = ConvertUtil.ConvertToDouble(calcParams[ParamK].Value, 1);
            double bias = Convert.ToDouble(calcParams[ParamBias].Value);

            int triEnumNumber = ConvertUtil.ConvertToInt(calcParams[ParamTrigonometricFunc].Value);

            if (triEnumNumber == 0)
            {
                //类型转换有问题
                calcResults[Result].Value = -1;
                return;
            }
            TrigonometricFunc trigoType = (TrigonometricFunc)triEnumNumber;
            switch (trigoType)
            {
                case TrigonometricFunc.Sin:
                    this.calcResults[Result].Value = k * System.Math.Sin(ai) + bias;
                    break;
                case TrigonometricFunc.Cos:
                    this.calcResults[Result].Value = k * System.Math.Cos(ai) + bias;
                    break;
                case TrigonometricFunc.Tan:
                    this.calcResults[Result].Value = k * System.Math.Tan(ai) + bias;
                    break;
            }

        }
    }
}
