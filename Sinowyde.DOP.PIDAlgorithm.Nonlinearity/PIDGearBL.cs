using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    /// <summary>
    /// 齿轮间隙算法块（ GEARBL） Gear Back lash
    /// </summary>
    public class PIDGearBL : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 间隙
        /// </summary>
        public const string ParamG = PIDAlgorithmToken.prefixParam + "G";
        /// <summary>
        /// 输出 Y
        /// </summary>
        public const string ParamY = PIDAlgorithmToken.prefixParam + "Y";

        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamG] = new PIDAlgorithmParam(ParamG, 1.0);
            this.calcParams[ParamY] = new PIDAlgorithmParam(ParamY, 1.0);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result);
        }
        /// <summary>
        /// 上一次输入值
        /// </summary>
        private double lastAI = 0;
        /// <summary>
        ///当 AI≥G 时， AO＝Y；
        ///当 AI≤－G 时， AO＝－Y；
        ///当 AO(k-1)≤AI－G，且 AI≥AI(k－1)时， AO＝AI－G；
        ///当 AO(k-1)≥AI＋G，且 AI＜AI(k－1)时， AO=AI＋G；
        ///其他： AO＝AO(k－1)。
        ///式中： AI(k－1) 前一时刻的输入值；
        ///AO(k－1) 前一时刻的输出值。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ai = calcInputs[InputAI].Value;
            double g = calcParams[ParamG].Value;
            double y = calcParams[ParamY].Value;
            double lastAO = calcResults[Result].Value;

            if (ai >= g)
                calcResults[Result].Value = y;
            else if (ai <= -g)
                calcResults[Result].Value = -y;
            else if (lastAO <= ai - g && ai >= lastAI)
                calcResults[Result].Value = ai - g;
            else if (lastAO >= ai + g && ai < lastAI)
                calcResults[Result].Value = ai + g;
            else
                calcResults[Result].Value = lastAO;

            //lastAI = this.calcInputs[InputAI].Value;
            lastAI = ai;
        }
    }
}
