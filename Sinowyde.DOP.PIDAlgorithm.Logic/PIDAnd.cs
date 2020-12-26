using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 与算法块
    /// </summary>
    [Serializable]
    public class PIDAnd : PIDBindAlgorithm
    {
        #region 变量
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        public const string InputDI3 = PIDAlgorithmToken.prefixInput + "DI3";
        public const string InputDI4 = PIDAlgorithmToken.prefixInput + "DI4";

        /// <summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI4] = new PIDAlgorithmVar(InputDI4, 1, PIDVarInputType.Init, PIDVarDataType.DM);
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
            calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            calcResults[ResultDO].Value = (calcInputs[InputDI1].Value + calcInputs[InputDI2].Value
                + calcInputs[InputDI3].Value + calcInputs[InputDI4].Value >= 4) ? 1 : 0;
        }

        #endregion

        public override string AlgName
        {
            get { return "与算法块"; }
        }
    }
}
