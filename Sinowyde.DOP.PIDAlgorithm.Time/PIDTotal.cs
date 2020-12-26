using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 积算器算法块（TOTAL）Total11f2c
    /// </summary>
    [Serializable]
    public class PIDTotal : PIDBindAlgorithm
    {
        ///<summary>
        /// 工作方式
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";

        /// <summary>
        /// 计算初值
        /// </summary>
        public const string ParamInit = PIDAlgorithmToken.prefixParam + "Init";

        /// <summary>
        /// 转换系数
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";

        ///<summary>
        /// 输入值
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 统计开始/结束信号
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixInput + "SET";
        ///<summary>
        /// 积算值
        /// </summary>
        public const string ResultIV = PIDAlgorithmToken.prefixResult + "IV";
        ///<summary>
        /// 上一次积算值
        /// </summary>
        public const string ResultLV = PIDAlgorithmToken.prefixResult + "LV";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE, (int)TotalMode.Sum);
            this.calcParams[ParamInit] = new PIDAlgorithmParam(ParamInit, 0);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputSET] = new PIDAlgorithmVar(InputSET, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultIV] = new PIDAlgorithmVar(ResultIV, PIDVarDataType.AM);
            this.calcResults[ResultLV] = new PIDAlgorithmVar(ResultLV, PIDVarDataType.AM);
        }
        /// <summary>
        /// 计算次数 第一次为0
        /// </summary>
        private int count = 0;
        /// <summary>
        /// 上一次输入
        /// </summary>
        private double lastAI = 0;
        private double lastLV = 0;

        private double lastMaxAI = 0;
        private double lastMinAI = 0;
        private double lastAvg = 0;

        /// <summary>
        /// 重置参数
        /// </summary>
        protected override void ResetEnvVars()
        {
            base.ResetEnvVars();
            count = 0;
            lastAI = 0;
        }

        /// <summary>
        /// [新版本]计算公式说明：
        ///1、累加：
        ///     Y0=积算初值 + AI _0* 转换系数；
        ///     Y1=Y0 + AI_1 * 转换系数；
        ///     Y2=Y1 + AI_2 * 转换系数；
        ///2、平均：
        ///     Y0=积算初值 + AI_0 * 转换系数；
        ///     Y1=积算初值 + (AI_0 * 转换系数+AI_1 * 转换系数) / 2；
        ///     Y2=积算初值 + (AI_0 * 转换系数+AI_1 * 转换系数+AI_2 * 转换系数) / 3；
        ///3、MAX：
        ///     Y0=积算初值 + AI_0 * 转换系数；
        ///     Y1=积算初值 + MAX(AI_0 * 转换系数, AI_1 * 转换系数) ；
        ///     Y2=积算初值 + MAX(AI_0 * 转换系数, AI_1 * 转换系数, AI_2 * 转换系数) ；
        ///4、MIN 和MAX相同；
        ///5、梯形累加和：
        ///      Y0=积算初值 + AI_0 * 转换系数 * DT / 2；
        ///      Y1=Y0 + (AI_0 * 转换系数+AI_1 * 转换系数) * DT / 2；
        ///      Y2=Y1 + (AI_1 * 转换系数+AI_2 * 转换系数) * DT / 2；
        /// </summary>
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            //乘以转换系数 ai * k
            double ai = this.calcInputs[InputAI].Value * k;
            double init = this.calcParams[ParamInit].Value;
            //如果是第一次计算
           // init = count == 0 ? init : 0;
            int set = ConvertUtil.ConvertToInt(this.calcInputs[InputSET].Value);

            if (set == 0)
            {
                this.calcResults[ResultIV].Value = 0;
                this.calcResults[ResultLV].Value = 0;
                count = 0;
            }
            else
            {
                //上一次是否乘以转换系数  * k; 不乘
                this.calcResults[ResultLV].Value = lastLV;
                int mode = ConvertUtil.ConvertToInt(this.calcParams[ParamMODE].Value);
                TotalMode tm = (TotalMode)mode;
                switch (tm)
                {
                    case TotalMode.Sum:
                        this.calcResults[ResultIV].Value = init + (lastLV + ai);
                        break;
                    case TotalMode.Min:
                        lastMinAI = Math.Min(lastAI, ai);
                        this.calcResults[ResultIV].Value = init + lastMinAI;
                        break;
                    case TotalMode.Max:
                        lastMaxAI = Math.Max(lastMaxAI, ai);
                        this.calcResults[ResultIV].Value = init + lastMaxAI;
                        break;
                    case TotalMode.Avg:
                        lastAvg += ai;
                        this.calcResults[ResultIV].Value = init + lastAvg / (count + 1);
                        //this.calcResults[ResultIV].Value = init + ((lastLV * count + ai) / (count + 1));
                        break;
                    case TotalMode.StepSum:// IV(n)=IV(n-1)+(AI(n-1)+AI(n))*DT/2
                        this.calcResults[ResultIV].Value = init + (lastLV + (lastAI + ai) * GetDt() / 2);
                        break;
                }

                count++;
                lastLV = this.calcResults[ResultIV].Value;
                lastAI = ai;

            }
        }

        public override string AlgName
        {
            get { return "积算器算法块"; }
        }
    }
}