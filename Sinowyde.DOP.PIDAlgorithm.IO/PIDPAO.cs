using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 页间引用的模拟量输出算法快
    /// </summary>
    [Serializable]
    public class PIDPAO : PIDPage
    {
        public PIDPAO()
            :base(false)
        {
        }
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAO = PIDAlgorithmToken.prefixInput + "AO";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAO] = new PIDAlgorithmVar(InputAO, PIDVarDataType.AM);
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
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);
        }
        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            this.calcResults[Result].Value = this.calcInputs[InputAO].Value;
        }

        public override string AlgName
        {
            get { return "页间引用模拟量输出算法"; }
        }


    }
}
