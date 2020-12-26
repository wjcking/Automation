using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// 阶跃信号算法块（Step）Step Signal85772
    /// </summary>
    [Serializable]
    public class PIDStep : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// 初值
        /// </summary>
        public const string ParamInit = PIDAlgorithmToken.prefixParam + "Init";
        ///<summary>
        /// 阶跃值
        /// </summary>
        public const string ParamStep = PIDAlgorithmToken.prefixParam + "Step";
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
            this.calcParams[ParamStep] = new PIDAlgorithmParam(ParamStep, 1.0);
            this.calcParams[ParamTime] = new PIDAlgorithmParam(ParamTime);
        }

        /// <summary>
        ///4、功能说明
        ///从指定的发生时间起发出一个给定高度的阶跃信号。 
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double init = this.calcParams[ParamInit].Value;
            double step = this.calcParams[ParamStep].Value;
            var time = this.calcParams[ParamTime].Value;

            this.calcResults[ResultAO].Value = (this.GetInitDT() < time) ? init : step;
        }


        public override string AlgName
        {
            get { return "阶跃信号算法块"; }
        }
    }
}