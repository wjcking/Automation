using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{

    /// <summary>
    /// 幅值报警
    /// </summary>
    [Serializable]
    public class PIDRangeAlm : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string inputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 上限
        /// </summary>
        public const string paramHigh = PIDAlgorithmToken.prefixParam + "High";
        /// <summary>
        /// 下限
        /// </summary>
        public const string paramLow = PIDAlgorithmToken.prefixParam + "Low";
        /// <summary>
        /// 死区
        /// </summary>
        public const string paramDead = PIDAlgorithmToken.prefixParam + "Dead";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string resultDO = PIDAlgorithmToken.prefixResult + "DO";

        public override string AlgName
        {
            get { return "幅值报警算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[paramHigh] = new PIDAlgorithmParam(paramHigh,50.0);
            this.calcParams[paramLow] = new PIDAlgorithmParam(paramLow, -50.0);
            this.calcParams[paramDead] = new PIDAlgorithmParam(paramDead);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[inputAI] = new PIDAlgorithmVar(inputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[resultDO] = new PIDAlgorithmVar(resultDO, PIDVarDataType.DM);

        }
        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double dead = this.calcParams[paramDead].Value;
            double high = this.calcParams[paramHigh].Value;
            double low = this.calcParams[paramLow].Value;
            double ai = this.calcInputs[inputAI].Value;

            if (ai > high || ai < low)
            {
                this.calcResults[resultDO].Value = 1;
            }
            else
            {
                if ((ai > high - dead && ai < high) || (ai > low && ai < low + dead))
                {
                    if (this.calcResults.ContainsKey(resultDO))
                        return;
                }

                this.calcResults[resultDO].Value = 0;
            }
        }
    }
}
