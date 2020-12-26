
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// 连续传递函数 1 算法块（CTF1）ContinuousTransFunction15034c
    /// </summary>
    public class PIDCtf1 : PIDBindAlgorithm
    {  ///<summary>
        /// 比例系数
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// 分子系数序列
        /// </summary>
        public const string ParamA = PIDAlgorithmToken.prefixParam + "A";
        ///<summary>
        /// 分母系数序列
        /// </summary>
        public const string ParamB = PIDAlgorithmToken.prefixParam + "B";
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
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
            this.calcParams[ParamA] = new PIDAlgorithmParam(ParamA);
            this.calcParams[ParamB] = new PIDAlgorithmParam(ParamB);
            this.calcParams[ParamINIT] = new PIDAlgorithmParam(ParamINIT);
        }
        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0);
        }`
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO);
        }
        /// <summary>
        ///连续传递函数算法快
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            IList<double> b = this.calcParams[ParamB].Values;
            IList<double> a = this.calcParams[ParamA].Values;
            double init = this.calcParams[ParamINIT].Value;
            double ai = this.calcParams[InputAI].Value;
            //double ao = ;
       
            //不符连续传递函数算法快
            if (a.Count == 0 || k == 0 || a.Count < b.Count)
            {
                this.calcResults[ResultAO].Value = -1;
                return;
            }
            
            double denominator =0;//分母
            double numerator =0;//分子
            var s = GetDt();//s这里以后还须调整

            for (int i = b.Count-1; i > 0; i--)
            {
                denominator += b[i] * Math.Pow(s, i);
            }

            for (int i = a.Count-1; i > 0; i--)
            {
                numerator += a[i] * Math.Pow(s, i);
            }

            this.calcParams[InputAI].Value = k * (denominator / numerator) * ai;
        }
    }
}