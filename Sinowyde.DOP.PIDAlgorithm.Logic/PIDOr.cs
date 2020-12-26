using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 或算法块
    /// </summary>
    [Serializable]
    public class PIDOr : PIDBindAlgorithm
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
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI4] = new PIDAlgorithmVar(InputDI4, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        /// 4、功能说明
        ///该算法完成逻辑或运算，最多可以连接 4 个数字量输入。
        ///5、算法说明
        ///DO=DI1 or DI2 or DI3 or DI4
        ///只要有一个数字量输入 DI(i)为 True (即 1)时，输出 DO 为 True(即 1)；否则输出 DO 为
        ///False (即 0)。
        ///悬空端 DI(i)初值默认为 False (0)
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            var di1 = this.calcInputs[InputDI1].Value;
            var di2 = this.calcInputs[InputDI2].Value;
            var di3 = this.calcInputs[InputDI3].Value;
            var di4 = this.calcInputs[InputDI4].Value;
            this.calcResults[ResultDO].Value = (di1 + di2 + di3 + di4) > 0 ? 1 : 0;

        }
        #endregion

        public override string AlgName
        {
            get { return "或算法块"; }
        }
    }
}
