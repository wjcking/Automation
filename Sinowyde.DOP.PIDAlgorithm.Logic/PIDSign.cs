using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 符号判断算法块
    /// </summary>
    [Serializable]
    public class PIDSign : PIDBindAlgorithm
    {
        #region 变量

        /// <summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";

        /// <summary>
        /// 数字量输出值
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        ///4、功能说明
        ///该算法完成对模拟输入量进行符号判断功能。
        ///5、算法说明
        ///当输入值 AI≥0 时，输出 DO 为 True (即 1)；
        ///当输入值 AI＜0 时，输出 DO 为 False(即 0)。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            var ai = ConvertUtil.ConvertToDouble(calcInputs[InputAI].Value);

            calcResults[ResultDO].Value = Convert.ToDouble(ai >= 0);

        }

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, PIDVarDataType.AM);
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
        #endregion

        public override string AlgName
        {
            get { return "符号判断算法块"; }
        }
    }
}
