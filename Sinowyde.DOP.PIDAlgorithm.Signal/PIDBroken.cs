
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 折线信号算法块（Broken）Broken Line Signale
    /// </summary>
    [Serializable]
    public class PIDBroken : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// 折点时间序列
        /// </summary>
        public const string ParamSTime = PIDAlgorithmToken.prefixParam + "STime";
        ///<summary>
        /// 折点输出序列
        /// </summary>
        public const string ParamSOut = PIDAlgorithmToken.prefixParam + "SOut";

        /// <summary>
        /// 最右侧斜率
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK);
            this.calcParams[ParamSTime] = new PIDAlgorithmParam(ParamSTime);
            //this.calcParams[ParamSTime].InitValues(10);
            this.calcParams[ParamSTime] = new PIDAlgorithmParam(ParamSTime, "0#0#0#0#0#0#0#0#0#0");
            //       this.calcParams[ParamSOut] = new PIDAlgorithmParam(ParamSOut);
            this.calcParams[ParamSOut] = new PIDAlgorithmParam(ParamSOut, "0#0#0#0#0#0#0#0#0#0");
            //this.calcParams[ParamSOut].InitValues(10);
        }

        /// <summary>
        /// 4、功能说明
        ///产生一个分段线性信号，折点时间序列与折点输出序列一一对应，“最右侧斜率”指最
        ///右边的折线之后的信号斜率。
        ///5、算法说明
        ///如果 DI=1，
        ///⋅= TAOtAO 00 )/( ， 0 小于 ≤ Tt 0 时；
        ///= i + i ⋅− ()( i+1 − +1 −TTAOAOTtAOAO iii )/() ， i 小于 ≤ TtT i+1时， i Λ= 8,,2,1,0
        ///= 9 + 9 )( ⋅− KTtAOAO ， 时； > Tt 9
        ///其中： t——时间变量； ——折点输出值； ——折点时间值；
        ///AOi Ti
        ///如果 DI=0， AO = 0
        ///时间变量置零。
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            var stime = this.calcParams[ParamSTime].Values;
            var sao = this.calcParams[ParamSOut].Values;
            double k = this.calcParams[ParamK].Value;
            int c = 1;
            double t = GetTotalDt();
            for (int i = 1; i < stime.Count; i++)
            {
                if (stime[i] > 0)
                    c += 1;
            }
            for (int i = 0; i < c - 1; i++)
            {
                if (0 < t && t <= stime[i])
                {
                    this.calcResults[ResultAO].Value = t * (sao[i] / stime[i]);
                    return;
                }
                else if (stime[i] < t && t <= stime[i + 1])
                {
                    this.calcResults[ResultAO].Value = sao[i] + (t - stime[i]) * (sao[i + 1] - sao[i]) / (stime[i + 1] - stime[i]);
                    return;
                }
            }

            if (t > stime[c - 1])
                this.calcResults[ResultAO].Value = sao[c - 1] + (t - stime[c - 1]) * k;

        }

        public override string AlgName
        {
            get { return "折线信号算法块"; }
        }
    }
}