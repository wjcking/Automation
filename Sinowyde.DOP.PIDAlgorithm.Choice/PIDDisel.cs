
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// 数字量输入选择算法块（DISEL）Digital Input Selection
    /// </summary>
    [Serializable]
    public class PIDDisel : PIDBindAlgorithm
    {
        #region 变量

        ///<summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        ///<summary>         
        /// 数字量输入                
        /// </summary>               
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        ///<summary>
        /// 数字量输入
        /// </summary>
        public const string InputDC = PIDAlgorithmToken.prefixInput + "DC";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        public override string AlgName
        {
            get { return "数字量输入选择算法块"; }
        }


        #region Abstract class PIDAlgorithm
        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDC] = new PIDAlgorithmVar(InputDC, 0, PIDVarInputType.Init, PIDVarDataType.DM);
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
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }
        /// <summary>
        ///4、功能说明
        ///该算法完成输入选择功能。数字量输入 DC 起到切换开关的作用。
        ///5、算法说明
        ///若 DC=True (即 1)时，DO=DI1； 若 DC=False(即 0)时，DO=DI2。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            if (calcInputs[InputDC].ValueToBool())
                this.calcResults[ResultDO].Value = this.calcInputs[InputDI1].Value;
            else
                this.calcResults[ResultDO].Value = this.calcInputs[InputDI2].Value;

        }

        #endregion
    }
}