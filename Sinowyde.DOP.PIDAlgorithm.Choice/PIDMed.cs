
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// 中值选择算法块（MED）Median Value
    /// </summary>
    [Serializable]
    public class PIDMed : PIDBindAlgorithm
    {
        #region 变量

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI3 = PIDAlgorithmToken.prefixInput + "AI3";
        ///<summary>
        /// 模拟输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        #endregion

        public override string AlgName
        {
            get { return "中值选择算法块"; }
        }


        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 判断算法有效性,主要检测输入参数是否绑定变量或者数值
        /// 需要确认修改
        /// </summary>
        /// <returns></returns>
        public override bool CheckSelfValid()
        {
            bool result = base.CheckSelfValid();
            if (result)
            {
                if (string.IsNullOrEmpty(this.GetBindParam(InputAI1)))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.GetBindParam(InputAI2)))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.GetBindParam(InputAI3)))
                {
                    return false;
                }
            }
            return result;

        }

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, PIDVarDataType.AM);
            this.calcInputs[InputAI3] = new PIDAlgorithmVar(InputAI3, PIDVarDataType.AM);
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
        ///该算法完成中值选择功能。
        ///5、算法说明
        ///AO=MED(AI1,AI2,AI3)
        ///注意：如果有悬空的输入，该模块不起作用，输入为 0
        /// </summary>  
        protected override void InternalDoCalc()
        {
            var vals = from c in calcInputs.Values
                       orderby c.Value
                       select c.Value;

            this.calcResults[ResultAO].Value = vals.ToArray()[1];
        }
        #endregion
    }
}