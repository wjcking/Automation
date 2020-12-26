using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{

    /// <summary>
    ///幅值
    ///</summary>
    [Serializable]
    public class PIDRange : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 上限
        /// </summary>
        public const string InputUL = PIDAlgorithmToken.prefixInput + "UL";
        /// <summary>
        /// 下限
        /// </summary>
        public const string InputDL = PIDAlgorithmToken.prefixInput + "DL";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "幅值算法块"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcParams()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputUL] = new PIDAlgorithmVar(InputUL, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputDL] = new PIDAlgorithmVar(InputDL, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary> 
        ///若 AI＞UL 时， AO=UL；
        ///若 AI＜DL 时， AO=DL；
        ///其他情况， AO=AI。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ul = calcInputs[InputUL].Value;
            double dl = calcInputs[InputDL].Value;
            double ai = calcInputs[InputAI].Value;

            if (ai > ul)
            {
                this.calcResults[ResultAO].Value = ul;
                return;
            }

            if (ai < dl)
            {
                this.calcResults[ResultAO].Value = dl;
                return;
            }

            this.calcResults[ResultAO].Value = ai;
        }
    }
}
