using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 数字量输入算法
    /// </summary>
    [Serializable]
    public class PIDDI : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "DI";

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, PIDVarDataType.AM);
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
        ///4、功能说明
        ///从指定的 DI 点获得数字输入量。
        ///5、算法说明
        ///指定的 DI 点，必须是已经在系统数据库中定义的点。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            this.calcResults[Result].Value = this.calcInputs[InputDI].Value;
        }

        public override string GetBindVarNumber()
        {
            return GetBindParam(PIDDI.InputDI); 
        }

        public override string AlgName
        {
            get { return "数字量输入算法"; }
        }
    }
}
