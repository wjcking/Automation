using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    ///<summary>
    /// 分段线性 （LINE） Linear
    /// </summary>
    [Serializable]
    public class PIDLine : PIDBindAlgorithm
    {
        ///<summary>
        /// 折点输入序列(i=1,2,...,10)
        /// </summary>
        public const string ParamSAI = PIDAlgorithmToken.prefixParam + "SAI";
        ///<summary>
        /// 折点输出序列(i=1,2,...,10)
        /// </summary>
        public const string ParamSAO = PIDAlgorithmToken.prefixParam + "SAO";
        ///<summary>
        /// 输入值
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "分段线性算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamSAI] = new PIDAlgorithmParam(ParamSAI, "1#2#3#4#5#0#0#0#0#0");
            this.calcParams[ParamSAO] = new PIDAlgorithmParam(ParamSAO, "0#1#2#3#4#0#0#0#0#0");
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
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);

        }
        /// <summary>
        ///4、功能说明
        ///表示一个分段线性函数，折点横坐标序列与折点纵坐标序列一一对应，表示输入值 AI
        ///与输出值 AO 之间对应的分段线性关系。
        ///5、算法说明 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            IList<double> sai = calcParams[ParamSAI].Values;
            IList<double> sao = calcParams[ParamSAO].Values;
            double ai = calcInputs[InputAI].Value;
            int c = 1;
            for (int i = 1; i < sai.Count; i++)
            {
                if (sai[i] > 0)
                    c += 1;
            }
            if (ai <= sai[0])
                calcResults[ResultAO].Value = sao[0];
            else if (ai > sai[c - 1])
            {
                calcResults[ResultAO].Value = sao[c - 1];
            }
            else
            {
                for (int i = 0; i < c - 1; i++)
                {
                    if (sai[i] < ai && ai <= sai[i + 1])
                    {
                        double step1 = (sao[i + 1] - sao[i]) / (sai[i + 1] - sai[i]);
                        double step2 = (ai - sai[i]);
                        calcResults[ResultAO].Value = step1 * step2 + sao[i];
                        break;
                    }
                }
            }
        }
    }
}