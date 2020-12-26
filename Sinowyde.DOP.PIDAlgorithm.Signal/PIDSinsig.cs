
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 正弦信号算法块（SinSig）Sin Signald56a5
    /// </summary>
    [Serializable]
    public class PIDSinsig : PIDBindSignalAlgorithm
    { 
        ///<summary>
        /// 发生时间
        /// </summary>
        public const string ParamTime = PIDAlgorithmToken.prefixParam + "Time";
        ///<summary>
        /// 幅值
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// 频率
        /// </summary>
        public const string ParamFreq = PIDAlgorithmToken.prefixParam + "Freq";
        ///<summary>
        /// 相角
        /// </summary>
        public const string ParamRad = PIDAlgorithmToken.prefixParam + "Rad";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamTime] = new PIDAlgorithmParam(ParamTime);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK,1.0);
            this.calcParams[ParamFreq] = new PIDAlgorithmParam(ParamFreq,1.0);
            this.calcParams[ParamRad] = new PIDAlgorithmParam(ParamRad);
        }
       
        /// <summary>
        ///4、功能说明
        ///从指定时刻起发出一个给定斜率的的斜坡信号。
        ///5、算法说明 如果 DI=1，
        ///AO = Init ,	t＜Time
        ///AO = Init+Slope*(t-Time) ,	t≥Time
        ///t——时间变量
        ///如果 DI=0
        ///AO = 0
        ///时间变量置零。
        ///正弦信号算法块（SinSig）Sin Signal
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            double freq = this.calcParams[ParamFreq].Value;
            double time = this.calcParams[ParamTime].Value;
            double rad = this.calcParams[ParamRad].Value;

            this.calcResults[ResultAO].Value = this.GetInitDT() < time ? 0 : k * Math.Sin(freq * this.GetInitDT() + rad);

        }

        public override string AlgName
        {
            get { return "正弦信号算法块"; }
        }
    }
}