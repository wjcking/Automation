using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 页间引用的模拟量输入算法快
    /// </summary>
    [Serializable]
    public class PIDPAI : PIDPage
    {
        public PIDPAI()
            :base(true)
        {
        }

        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultAI = PIDAlgorithmToken.prefixResult + "AI";


        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, PIDVarDataType.AM);
        }

        protected override void InitCalcResults()
        {
            this.calcResults[ResultAI] = new PIDAlgorithmVar(ResultAI, PIDVarDataType.AM);
        }

        protected override void InternalDoCalc()
        {
            this.calcResults[ResultAI].Value = this.calcInputs[InputAI].Value;
        }

        public override string AlgName
        {
            get { return "页间引用模拟量输入算法"; }
        }
    }
}
