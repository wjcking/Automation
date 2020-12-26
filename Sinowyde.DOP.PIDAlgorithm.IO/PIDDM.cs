using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 逻辑量输出
    /// </summary>
    [Serializable]
    public class PIDDM : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>        
        public const string InputDM = PIDAlgorithmToken.prefixInput + "DI";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "DI";

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDM] = new PIDAlgorithmVar(InputDM, PIDVarDataType.DM);
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
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.DM);
        }

        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            this.calcResults[Result].Value = this.calcInputs[InputDM].Value;
        }

        public override string GetBindVarNumber()
        {
            return GetBindParam(PIDDM.Result);
        }

        public override string AlgName
        {
            get { return "逻辑量输出"; }
        }
    }
}
