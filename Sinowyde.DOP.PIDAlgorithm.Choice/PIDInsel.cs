
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    ///模拟量输入选择算法块
    /// </summary>
    [Serializable]
    public class PIDInsel : PIDBindAlgorithm
    {
        #region 变量

        ///<summary>
        ///模拟量输入
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        /// <summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        ///<summary>
        /// AI1 到 AI2 的切换速率
        /// </summary>
        public const string ParamK1 = PIDAlgorithmToken.prefixParam + "K1";
        ///<summary>
        /// AI2 到 AI1 的切换速率
        /// </summary>
        public const string ParamK2 = PIDAlgorithmToken.prefixParam + "K2";
        ///<summary>
        ///数字量输入
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 上一次计算结果
        /// </summary>
        private double lastResultAO = 0;

        #endregion

        public override string AlgName
        {
            get { return "模拟量输入选择算法块"; }
        }

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK1] = new PIDAlgorithmParam(ParamK1);
            this.calcParams[ParamK2] = new PIDAlgorithmParam(ParamK2);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);

        }
        /// <summary>
        /// K1 AI1 到 AI2 的切换速率 Double
        /// K2 AI2 到 AI1 的切换速率 Double
        ///4、功能说明
        ///该算法完成输入选择功能。数字量输入 DI 起到切换开关的作用。 DI 为 1 时，输出 AI1，
        ///输出的变化率即为 K2； DI 为 0 时，输出 AI2，输出的变化率即为 K1。
        ///5、算法说明
        ///若 DI=True (即 1)时， AO=AI1；
        ///若 DI=False(即 0)时， AO=AI2。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            bool di = this.calcInputs[InputDI].ValueToBool();

            double ai1 = this.calcInputs[InputAI1].Value;
            double ai2 = this.calcInputs[InputAI2].Value;

            double k1 = this.calcParams[ParamK1].Value;
            double k2 = this.calcParams[ParamK2].Value;


            if (di)
            {
                if (k2 == 0)
                {
                    this.calcResults[ResultAO].Value = ai1;
                }
                else if (lastResultAO > ai1)
                {
                    //递减
                    double bias = lastResultAO - k2;
                    this.calcResults[ResultAO].Value = bias < ai1 ? ai1 : bias;
                }
                else
                {
                    //递增
                    double bias = lastResultAO + k2;
                    this.calcResults[ResultAO].Value = bias > ai1 ? ai1 : bias;
                }
            }
            else
            {
                if (k1 == 0)
                {
                    this.calcResults[ResultAO].Value = ai2;
                }
                else if (lastResultAO > ai2)
                {
                    //递减
                    double bias = lastResultAO - k1;
                    this.calcResults[ResultAO].Value = bias < ai2 ? ai2 : bias;
                }
                else
                {
                    //递增
                    double bias = lastResultAO + k1;
                    this.calcResults[ResultAO].Value = bias > ai2 ? ai2 : bias;
                }
            }

            lastResultAO = this.calcResults[ResultAO].Value;
        }

        #endregion
    }
}