using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    /// <summary>
    /// 速率警报
    /// </summary>
    [Serializable]
    public class PIDRatioAlm : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 死区
        /// </summary>
        public const string ParamDead = PIDAlgorithmToken.prefixParam + "Dead";
        /// <summary>
        /// 上线
        /// </summary>
        public const string ParamHigh = PIDAlgorithmToken.prefixParam + "High";
        /// <summary>
        /// 下线
        /// </summary>
        public const string ParamLow = PIDAlgorithmToken.prefixParam + "Low";

        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        public const string LastAI = PIDAlgorithmToken.prefixResult + "LastAI";

        private double lastDO = 0;
        private double lastAI = 0;

        public override string AlgName
        {
            get { return "速率报警算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDead] = new PIDAlgorithmParam(ParamDead);
            this.calcParams[ParamHigh] = new PIDAlgorithmParam(ParamHigh,50.0);
            this.calcParams[ParamLow] = new PIDAlgorithmParam(ParamLow, -50.0);
            
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO,PIDVarDataType.DM);
           
        }


        /// <summary>
        /// 设 dt 为两次计算时间间隔
        /// 1） 若 (AI-AO(k-1)) 除以 dt 大于 High
        /// DO=1；
        /// 2） 若 (AI-AO(k-1))  除以 dt 小于 Low
        /// DO=1；
        /// 3） 若 DO=1
        /// 当 High-Dead 小于(AI-AO(k-1)) 除以 dt 小于 High 的时候， DO 保持不变；
        /// 当 Low 小于 (AI-AO(k-1))小于Low+Dead 的时候， DO 保持不变。
        /// 4） 其他情况，
        /// DO=0。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ai = this.calcInputs[InputAI].Value;
            double dead = this.calcParams[ParamDead].Value;
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;

            //上一次ai = AO(k-1)
            double dt = GetDt();
            dt = dt == 0 ? 1 : dt;
            double divided = (ai - lastAI) / dt;

            if (divided > high)
            {
                this.calcResults[ResultDO].Value = 1;
                lastAI = ai;
                lastDO = this.calcResults[ResultDO].Value;
                return;
            }
            if (divided < low)
            {
                this.calcResults[ResultDO].Value = 1;
                lastAI = ai;
                lastDO = this.calcResults[ResultDO].Value;
                return;
            }

            if (lastDO==1)
            {
                if ((high - dead) < divided && divided < high)
                {
                }
                else if (low < divided && divided < (low + dead))
                {
                }
                else
                    this.calcResults[ResultDO].Value = 0;
                lastAI = ai;
                lastDO = this.calcResults[ResultDO].Value;
                return;
            }

            this.calcResults[ResultDO].Value = 0;
            lastAI = ai;
            lastDO = this.calcResults[ResultDO].Value;
        }
    }
}
