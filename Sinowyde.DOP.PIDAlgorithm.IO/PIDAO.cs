using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{

    /// <summary>
    /// 模拟量输出算法
    /// </summary>
    [Serializable]
    public class PIDAO : PIDBindAlgorithm
    {
        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputAO = PIDAlgorithmToken.prefixInput + "AO";
        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAO] = new PIDAlgorithmVar(InputAO, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.AM);
        }
        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            if (isDownload)
            {
                if (Math.Abs(this.calcInputs[InputAO].Value - this.calcResults[Result].Value) < Math.Abs(validBias))
                {
                    isDownload = false;
                    this.calcResults[Result].Value = this.calcInputs[InputAO].Value;
                }
                else
                {
                    //下载过程中
                    double dt = GetDt();
                    double bias = (dt / DelayPeriod) * (this.calcInputs[InputAO].Value - this.calcResults[Result].Value);
                    if (Math.Abs(bias) > Math.Abs(validBias))
                        validBias = bias;
                    this.calcResults[Result].Value = validBias +this.calcResults[Result].Value;
                }
            }
            else
            {
                this.calcResults[Result].Value = this.calcInputs[InputAO].Value;
            }
        }

        public override string GetBindVarNumber()
        {
            return GetBindParam(PIDAO.Result); 
        }

        public override string AlgName
        {
            get { return "模拟量输出算法"; }
        }

        /// <summary>
        /// 无扰下载周期，单位秒
        /// </summary>
        public double DelayPeriod
        {
            get;
            set;
        }

        private double validBias = 0;
        private bool isDownload = false;
        /// <summary>
        /// 无扰下载
        /// </summary>
        /// <param name="srcAlg"></param>
        public override void CloneFrom(PIDBindAlgorithm srcAlg)
        {
            base.CloneFrom(srcAlg);
            isDownload = true;
        }
    }
}
