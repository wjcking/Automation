using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 数值量输出
    /// </summary>
    [Serializable]
    public class PIDAM : PIDBindAlgorithm
    {
        /// <summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        
        /// <summary>
        /// 输出值
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AI";

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
        protected override void InitCalcParams() 
        {

        }


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
            this.calcResults[Result].Value = this.calcInputs[InputAI].Value;
        }

        public override string GetBindVarNumber()
        {
            return GetBindParam(PIDAM.Result); 
        }

        public override string AlgName
        {
            get { return "数值量输出"; }
        }
    }
}
