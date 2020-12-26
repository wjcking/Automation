using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 非算法块
    /// </summary>
    [Serializable]
    public class PIDNot : PIDBindAlgorithm
    {
        #region 变量

        /// <summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";

        /// <summary>
        /// 数字量输出值
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// 初始化输出参数
        /// </summary>
        /// <returns></returns>
        protected override void InitCalcResults()
        {
            calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        /// 4、功能说明
        ///该算法完成逻辑非运算。
        ///5、算法说明
        ///DO=Not DI
        ///若 DI 为 True (即 1)时，则 DO 为 False (即 0)；
        ///若 DI 为 False(即 0)时，则 DO 为 True (即 1)。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            var di = ConvertUtil.ConvertToBool(calcInputs[InputDI].Value);
            calcResults[ResultDO].Value = Convert.ToDouble(!di);
        }
        #endregion

        public override string AlgName
        {
            get { return "非算法块"; }
        }

    }
}
