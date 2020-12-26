using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 数字量输出算法
    /// </summary>
    [Serializable]
    public class PIDDO : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>       
        public const string InputDO = PIDAlgorithmToken.prefixInput + "DO";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "DO";

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDO] = new PIDAlgorithmVar(InputDO, PIDVarDataType.DM);
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
            this.calcResults[Result].Value = this.calcInputs[InputDO].Value;
        }

        public override string GetBindVarNumber()
        {
            return GetBindParam(PIDDO.Result);
        }

        public override string AlgName
        {
            get { return "数字量输出算法"; }
        }
    }
}
