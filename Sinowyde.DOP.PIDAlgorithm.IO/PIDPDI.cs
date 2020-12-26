using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 页间引用的数字量输入算法快
    /// </summary>
    [Serializable]
    public class PIDPDI : PIDPage
    {
        public PIDPDI()
            :base(true)
        {
        }
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultDI = PIDAlgorithmToken.prefixResult + "DI";

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, PIDVarDataType.DM);
        }

        protected override void InitCalcResults()
        {
            this.calcResults[ResultDI] = new PIDAlgorithmVar(ResultDI, PIDVarDataType.DM);
        }

        protected override void InternalDoCalc()
        {
            this.calcResults[ResultDI].Value = this.calcInputs[InputDI].Value;
        }

        public override string AlgName
        {
            get { return "页间引用数字量输入算法"; }
        }
    }
}
