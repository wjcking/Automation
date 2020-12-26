
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// 连续传递函数 2 算法块（CTF2）ContinuousTransFunction203877
    /// </summary>
    public class PIDCtf2 : PIDBindAlgorithm
    {  ///<summary>
        /// 比例系数
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// 时间常数
        /// </summary>
        public const string ParamT = PIDAlgorithmToken.prefixParam + "T";
        ///<summary>
        /// 阶数
        /// </summary>
        public const string ParamN = PIDAlgorithmToken.prefixParam + "N";
        ///<summary>
        /// 输出初始值
        /// </summary>
        public const string ParamINIT = PIDAlgorithmToken.prefixParam + "INIT";
        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmVar(ParamK, false, PIDVarType.Unknown);
            this.calcParams[ParamT] = new PIDAlgorithmVar(ParamT, false, PIDVarType.Unknown);
            this.calcParams[ParamN] = new PIDAlgorithmVar(ParamN, false, PIDVarType.Unknown);
            this.calcParams[ParamINIT] = new PIDAlgorithmVar(ParamINIT, false, PIDVarType.Unknown);

            this.calcParams[ParamK].Value = 1;
            this.calcParams[ParamT].Value = 1;
            this.calcParams[ParamN].Value = 1;

            this.calcParams[InputAI] = new PIDAlgorithmVar(InputAI, true, PIDVarType.AM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, true, PIDVarType.AM);

        }
        /// <summary>
        ///
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            int t = ConvertUtil.ConvertToInt(this.calcParams[ParamT].Value);
            int n = ConvertUtil.ConvertToInt(this.calcParams[ParamN].Value);
            double init = this.calcParams[ParamINIT].Value;
            double ai = this.calcParams[InputAI].Value;

            //不满足条件则不计算
            if (k == 0 || t <= 0 || n < 1)
            {
                this.calcResults[ResultAO].Value = -1;
                return;
            }

            var dt = GetDt();
            this.calcResults[ResultAO].Value = (k / Math.Pow(t * dt + 1, n)) * ai;
        }
    }
}