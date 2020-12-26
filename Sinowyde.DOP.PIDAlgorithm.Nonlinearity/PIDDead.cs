using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    /// <summary>
    /// 死区算法
    /// </summary>
    [Serializable]
    public class PIDDead : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入模拟量
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        /// <summary>
        /// 斜率
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";

        /// <summary>
        /// 死区
        /// </summary>
        public const string ParamD1 = PIDAlgorithmToken.prefixParam + "D1";
        public const string ParamD2 = PIDAlgorithmToken.prefixParam + "D2";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "死区算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1.0);
            this.calcParams[ParamD1] = new PIDAlgorithmParam(ParamD1, -1.0);
            this.calcParams[ParamD2] = new PIDAlgorithmParam(ParamD2, 1.0);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);

        }
        /// <summary>
        /// 当 AI＜D1 时， AO=k*(AI－D1)；
        ///当 D1≤AI1≤D2 时， AO=0；
        ///当 AI＞D2 时， AO=k*(AI－D2)
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double ai = calcInputs[InputAI].Value;
            double k = calcParams[ParamK].Value;
            double d1 = calcParams[ParamD1].Value;
            double d2 = calcParams[ParamD2].Value;

            if (ai < d1)
                calcResults[Result].Value = k * (ai - d1);
            else if (d1 <= ai && ai <= d2)
                calcResults[Result].Value = 0;
            else if (ai > d2)
                calcResults[Result].Value = k * (ai - d2); ;

        }
    }
}
