using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    /// <summary>
    /// 速率
    /// </summary>
    [Serializable]
    public class PIDRatio : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string inputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 加速
        /// </summary>
        public const string inputAL = PIDAlgorithmToken.prefixInput + "AL";
        /// <summary>
        /// 减速
        /// </summary>
        public const string inputDL = PIDAlgorithmToken.prefixInput + "DL";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "速率算法块"; }
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
            this.calcInputs[inputAI] = new PIDAlgorithmVar(inputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[inputAL] = new PIDAlgorithmVar(inputAL, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[inputDL] = new PIDAlgorithmVar(inputDL, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }
        /// <summary>
        ///设 dt 为两次计算时间间隔
        ///若 (AI－AO(k－1))/dt＞AL
        ///AO＝AO(k－1)＋AI*AL；
        ///若 (AI－AO(k－1))/dt＜DL
        ///AO＝AO(k－1)—AI*Low；
        ///其他
        ///AO=AI
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ai = this.calcInputs[inputAI].Value;
            double al = this.calcInputs[inputAL].Value;
            double dl = this.calcInputs[inputDL].Value;
            double lastAO = this.calcResults[ResultAO].Value;
            double dt = GetDt();
            double divided = (ai - lastAO) / dt;

            if (divided > al)
                this.calcResults[ResultAO].Value = lastAO + ai * al;
            else if (divided < dl)
                this.calcResults[ResultAO].Value = lastAO - ai * dl;
            else
                this.calcResults[ResultAO].Value = ai;
        }

    }
}