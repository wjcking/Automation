
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// 模拟量输出选择算法块
    /// </summary>
    [Serializable]
    public class PIDOpsel : PIDBindAlgorithm
    {

        #region 变量

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// 切换速率
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// 模拟量输出值
        /// </summary>
        public const string ResultAO1 = PIDAlgorithmToken.prefixResult + "AO1";

        ///<summary>
        /// 模拟量输出值
        /// </summary>
        public const string ResultAO2 = PIDAlgorithmToken.prefixResult + "AO2";

        /// <summary>
        /// 上一次AO1值
        /// </summary>
        private double lastResultAO1 = 0;

        /// <summary>
        /// 上一次AO2值
        /// </summary>
        private double lastResultAO2 = 0;

        #endregion

        public override string AlgName
        {
            get { return "模拟量输出选择算法块"; }
        }


        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, PIDVarDataType.AM);
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK,0);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO1] = new PIDAlgorithmVar(ResultAO1, PIDVarDataType.AM);
            this.calcResults[ResultAO2] = new PIDAlgorithmVar(ResultAO2, PIDVarDataType.AM);
        }

        /// <summary>
        ///4、功能说明
        ///该算法完成输出选择功能。在输出切换过程中，输出按指定的切换速率 K 变化。
        ///5、算法说明
        ///若 DI=True (即 1)时，AO1=AI ，AO2(n)=AO2(n-1)；
        ///若 DI=False(即 0)时，AO2=AI ，AO1(n)=AO1(n-1)。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            bool inputDIVal = this.calcInputs[InputDI].ValueToBool();
            double inputAIVal = this.calcInputs[InputAI].Value;
            double paramKVal = this.calcParams[ParamK].Value;
            if (inputDIVal)
            {
                /*
                 * AO1 -> AI
                 * */
                if (paramKVal == 0)
                {
                    this.calcResults[ResultAO1].Value = inputAIVal;
                }
                else if (lastResultAO1 > inputAIVal)
                {
                    double bias = lastResultAO1 - paramKVal;
                    this.calcResults[ResultAO1].Value = bias < inputAIVal ? inputAIVal : bias;
                }
                else
                {
                    double bias = lastResultAO1 + paramKVal;
                    this.calcResults[ResultAO1].Value = bias > inputAIVal ? inputAIVal : bias;
                }
                this.calcResults[ResultAO2].Value = lastResultAO2;
            }
            else
            {
                /*
                 * AO2 -> AI
                 * */
                if (paramKVal == 0)
                {
                    this.calcResults[ResultAO2].Value = inputAIVal;
                }
                else if (lastResultAO2 > inputAIVal)
                {
                    double bias = lastResultAO2 - paramKVal;
                    this.calcResults[ResultAO2].Value = bias < inputAIVal ? inputAIVal : bias;
                }
                else
                {
                    double bias = lastResultAO2 + paramKVal;
                    this.calcResults[ResultAO2].Value = bias > inputAIVal ? inputAIVal : bias;
                }
                this.calcResults[ResultAO1].Value = lastResultAO1;
            }

            lastResultAO1 = this.calcResults[ResultAO1].Value;
            lastResultAO2 = this.calcResults[ResultAO2].Value;
        }

        #endregion
    }
}