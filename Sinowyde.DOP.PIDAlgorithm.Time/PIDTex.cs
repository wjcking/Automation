
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 定时器优化算法块（TEX）Timer3765d
    /// </summary>
    public class PIDTex : PIDBindAlgorithm
    {

        /// <summary>
        ///  计时时间（单位：秒）
        /// </summary>
        public const string ParamEndTime = PIDAlgorithmToken.prefixParam + "EndTime";
        /// <summary>
        /// 工作方式 Int
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";
        /// <summary>
        /// 输入定时值  
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixParam + "PV";
        /// <summary>
        /// 开始工作信号 Bool
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixParam + "SET";
        /// <summary>
        /// 复位信号 RESET Bool
        /// </summary>
        public const string InputRS = PIDAlgorithmToken.prefixParam + "RS";
        /// <summary>
        /// 当前定时时间值 Double
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixParam + "AO";
        /// <summary>
        /// 定时器脉冲输出 Bool
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixParam + "DO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamEndTime] = new PIDAlgorithmParam(ParamEndTime);
            this.calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputPV] = new PIDAlgorithmVar(InputPV,  PIDVarDataType.DM);
            this.calcInputs[InputSET] = new PIDAlgorithmVar(InputSET, PIDVarDataType.DM);
            this.calcInputs[InputRS] = new PIDAlgorithmVar(InputRS, PIDVarDataType.DM);
        }

        protected override bool IsValidParam(string param, object value)
        {
            return false;
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }
        /// <summary>
        ///4、功能说明
        ///完成定时器，单脉冲发生器，滞后置位，滞后复位，滞后复位保持等功能。
        ///5、算法说明
        ///同定时器算法块
        /// </summary>  
        protected override void InternalDoCalc()
        {
            //本算法块儿同 PidT
        }
    }
}