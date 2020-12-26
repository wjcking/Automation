using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 异或算法块
    /// </summary>
    [Serializable]
    public class PIDXor : PIDBindAlgorithm
    {
        #region

        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";

        /// <summary>
        /// 数字量输出值
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        ///4、功能说明
        ///该算法完成逻辑异或运算。
        ///5、算法说明
        ///当两个逻辑输入端不同时，输出 DO 为 True (即 1)；
        ///当两个逻辑输入端相同时，输出 DO 为 False (即 0)。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            var di1 = ConvertUtil.ConvertToBool(calcInputs[InputDI1].Value);
            var di2 = ConvertUtil.ConvertToBool(calcInputs[InputDI2].Value);

            calcResults[ResultDO].Value = Convert.ToDouble(!di1.Equals(di2));
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        protected override void InitCalcParams() { }

        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        #endregion

        public override string AlgName
        {
            get { return "异或算法块"; }
        }

    }
}
