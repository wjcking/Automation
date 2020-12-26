
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// 最大值算法块（MAX）Maximum
    /// </summary>
    [Serializable]
    public class PIDMax : PIDBindAlgorithm
    {
        #region 变量

        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";

        public const string InputAI3 = PIDAlgorithmToken.prefixInput + "AI3";
        public const string InputAI4 = PIDAlgorithmToken.prefixInput + "AI4";
        ///<summary>
        /// 模拟量输出
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        #endregion

        #region Abstract class PIDAlgorithm

        public override string AlgName
        {
            get { return "最大值算法块"; }
        }


        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI3] = new PIDAlgorithmVar(InputAI3, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI4] = new PIDAlgorithmVar(InputAI4, 0, PIDVarInputType.Init, PIDVarDataType.AM);
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
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }

        /// <summary>
        ///4、功能说明
        ///该算法完成最大值选择功能。
        ///5、算法说明
        ///AO=MAX(AI1,AI2,AI3,AI4)
        ///注意：悬空的输入不参加比较！
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double maxVal = double.MinValue;
            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI1)))
            {
                if (calcInputs[InputAI1].Value > maxVal)
                    maxVal = calcInputs[InputAI1].Value;
            }

            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI2)))
            {
                if (calcInputs[InputAI2].Value > maxVal)
                    maxVal = calcInputs[InputAI2].Value;
            }

            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI3)))
            {
                if (calcInputs[InputAI3].Value > maxVal)
                    maxVal = calcInputs[InputAI3].Value;
            }

            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI4)))
            {
                if (calcInputs[InputAI4].Value > maxVal)
                    maxVal = calcInputs[InputAI4].Value;
            }
            this.calcResults[ResultAO].Value = maxVal;
        }
        
        #endregion
    }
}