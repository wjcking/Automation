
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 多段方波信号算法块（MSquare）Multi-Square Signal
    /// </summary>
    [Serializable]
    public class PIDMsquare : PIDBindSignalAlgorithm
    {  ///<summary>
        /// 折点时间序列
        /// </summary>
        public const string ParamSTime = PIDAlgorithmToken.prefixParam + "STime";
        ///<summary>
        /// 折点输出序列
        /// </summary>
        public const string ParamSOut = PIDAlgorithmToken.prefixParam + "SOut";
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamSTime] = new PIDAlgorithmParam(ParamSTime, "2#5#11#20#50#0#0#0#0#0");
            this.calcParams[ParamSOut] = new PIDAlgorithmParam(ParamSOut, "1#2#0.5#4#0#0#0#0#0#0");
        }

        /// <summary>
        ///4、功能说明
        ///产生一个频率和时间可变的方波信号，相邻的折点时间之间的输出值是对应的折点输
        ///出，时间超过最大折点时间后，输出值总是等于最右侧的折点输出值。
        ///5、算法说明
        ///如果 DI=1，
        ///AO = 0 ，
        ///0 小于 小于 Tt 0 时；
        ///= AOAO i ， i 小于≤ TtT i+1时， i = Λ 8,,2,1,0 ；
        ///= AOAO 9 ， ； ≥ Tt 9
        ///其中： ——时间变量； ——折点输出值； ——折点时间值； t
        ///AOi Ti
        ///如果 DI=0,
        ///AO = 0 
        ///时间变量置零。
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            var stime = this.calcParams[ParamSTime].Values;
            var sout = this.calcParams[ParamSOut].Values;
            double t = GetTotalDt();
            int c = 1;
            for (int i = 1; i < stime.Count; i++)
            {
                if (stime[i] > 0)
                    c += 1;
            }
            for (int i = 0; i < c - 1; i++)
            {
                if (0 < t && t < stime[0])
                {
                    this.calcResults[ResultAO].Value = 0;
                    return;
                }
                else if (stime[i] <= t && t < stime[i + 1])
                {
                    this.calcResults[ResultAO].Value = sout[i];
                    return;
                }
            }

            if (t >= stime[c-1])
                this.calcResults[ResultAO].Value = sout[c-1];
        }

        public override string AlgName
        {
            get { return "多段方波信号算法块"; }
        }
    }
}