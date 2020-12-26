
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// 数字量输出选择算法块（DOSEL）Digital Output Selection
    /// </summary>
    [Serializable]
    public class PIDDosel : PIDBindAlgorithm
    {
        #region 变量

        ///<summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// 输出选择信号
        /// </summary>
        public const string InputDC = PIDAlgorithmToken.prefixInput + "DC";
        ///<summary>
        /// 数字量输出值
        /// </summary>
        public const string ResultDO1 = PIDAlgorithmToken.prefixResult + "DO1";
        ///<summary>
        /// 数字量输出值
        /// </summary>
        public const string ResultDO2 = PIDAlgorithmToken.prefixResult + "DO2";

        /// <summary>
        /// 上一次DO1值
        /// </summary>
        private double lastResultDO1 = 0;

        /// <summary>
        /// 上一次DO2值
        /// </summary>
        private double lastResultDO2 = 0;
        #endregion

        #region Abstract class PIDAlgorithm

        public override string AlgName
        {
            get { return "数字量输出选择算法块"; }
        }


        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDC] = new PIDAlgorithmVar(InputDC, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO1] = new PIDAlgorithmVar(ResultDO1, PIDVarDataType.DM);
            this.calcResults[ResultDO2] = new PIDAlgorithmVar(ResultDO2, PIDVarDataType.DM);
        }

        /// <summary>
        ///4、功能说明
        ///该算法完成数字量输出选择功能。数字量输入 DC 起到切换开关的作用。
        ///5、算法说明
        ///若 DC=True (即 1)时，DO1=DI，DO2(n)=DO2(n-1)；
        ///若 DC=False(即 0)时，DO2=DI，DO1(n)=DO1(n-1)。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            if (calcInputs[InputDC].ValueToBool())
            {
                this.calcResults[ResultDO1].Value = calcInputs[InputDI].Value;
                this.calcResults[ResultDO2].Value = lastResultDO2;
            }
            else
            {
                this.calcResults[ResultDO1].Value = lastResultDO1;
                this.calcResults[ResultDO2].Value = calcInputs[InputDI].Value;
            }

            lastResultDO1 = this.calcResults[ResultDO1].Value;
            lastResultDO2 = this.calcResults[ResultDO2].Value;
        }

        #endregion
    }
}