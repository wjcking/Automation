
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 斜坡信号算法块（Ramp）Ramp Signald9b5d
    /// </summary>
    [Serializable]
    public class PIDRamp : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// 初值
        /// </summary>
        public const string ParamInit = PIDAlgorithmToken.prefixParam + "Init";
        ///<summary>
        /// 斜率值
        /// </summary>
        public const string ParamSlope = PIDAlgorithmToken.prefixParam + "Slope";
        ///<summary>
        /// 发生时间
        /// </summary>
        public const string ParamTime = PIDAlgorithmToken.prefixParam + "Time";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamInit] = new PIDAlgorithmParam(ParamInit);
            this.calcParams[ParamSlope] = new PIDAlgorithmParam(ParamSlope,1.0);
            this.calcParams[ParamTime] = new PIDAlgorithmParam(ParamTime);
        }
        /// <summary>
        ///4、功能说明
        ///从指定时刻起发出一个给定斜率的的斜坡信号。
        ///5、算法说明
        ///如果 DI=1，
        ///AO = Init , t＜Time
        ///AO = Init+Slope*(t-Time) , t≥Time
        ///t——时间变量
        ///如果 DI=0
        ///AO = 0
        ///时间变量置零。
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double init = this.calcParams[ParamInit].Value;
            double slope = this.calcParams[ParamSlope].Value;
            double time = this.calcParams[ParamTime].Value;

            this.calcResults[ResultAO].Value = this.GetInitDT() < time ? init :
                    init + slope * (this.GetInitDT() - time);
        }

        public override string AlgName
        {
            get { return "斜坡信号算法块"; }
        }

    }
}