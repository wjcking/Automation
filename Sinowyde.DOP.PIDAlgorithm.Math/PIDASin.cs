using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    public enum ATrigonometricFunc : ushort
    {
        ASin = 1,
        ACos = 2,
        ATan = 3, 
    }
    /// <summary>
    /// 反三角函数算法块（ SIN） 
    /// </summary>
    [Serializable]
    public class PIDASin : PIDBindAlgorithm
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
        /// 反三角函数
        /// </summary>
        public const string ParamATrigonometricFunc = PIDAlgorithmToken.prefixParam + "ATrigonometricFunc";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "反三角函数算法块"; }
        }


        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1.0);
            this.calcParams[ParamATrigonometricFunc] = new PIDAlgorithmParam(ParamATrigonometricFunc, 1.0);
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

            int adverseTriEnumNumber = ConvertUtil.ConvertToInt(calcParams[ParamATrigonometricFunc].Value);

            if (adverseTriEnumNumber == 0)
            {
                //类型转换有问题
                calcResults[Result].Value = -1;
                return;
            }
            ATrigonometricFunc atrigoType = (ATrigonometricFunc)adverseTriEnumNumber;
            switch (atrigoType)
            {
                case ATrigonometricFunc.ASin:
                    this.calcResults[Result].Value = k * System.Math.Asin(ai) + bias;
                    break;
                case ATrigonometricFunc.ACos:
                    this.calcResults[Result].Value = k * System.Math.Acos(ai) + bias;
                    break;
                case ATrigonometricFunc.ATan:
                    this.calcResults[Result].Value = k * System.Math.Atan(ai) + bias;
                    break;
            }

        }
    }
}
