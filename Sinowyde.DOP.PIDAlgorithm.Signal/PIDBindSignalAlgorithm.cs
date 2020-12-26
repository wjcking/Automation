using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    [Serializable]
    public abstract class PIDBindSignalAlgorithm : PIDBindAlgorithm
    {
        ///<summary>
        /// 触发信号
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始时间标记
        /// </summary>
        protected DateTime InitTime = DateTime.MinValue;
        /// <summary>
        /// 计算次数
        /// </summary>
        protected int inc = 0;
        /// <summary>
        /// 与初始时间标记偏差
        /// </summary>
        /// <returns></returns>
        public double GetInitDT()
        {
            return (DateTime.MinValue == InitTime) ? 0 :
                (CurrentCalcTime - InitTime).TotalSeconds; 
        }

        protected override void ResetEnvVars()
        {
            base.ResetEnvVars();
            this.InitTime = DateTime.MinValue;           
        }
        /// <summary>
        /// 输入量DI
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1.0, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }

        protected override void InternalDoCalc()
        {
            if (this.calcInputs[InputDI].ValueToBool())
            {
                if (this.GetInitDT() == 0)
                {
                    this.InitTime = this.CurrentCalcTime;
                }
                SignalInternalDoCalc();
            }
            else
            {
                this.calcResults[ResultAO].Value = 0;
                this.InitTime = DateTime.MinValue;
                this.inc = 0;
            }
        }

        protected abstract void SignalInternalDoCalc();
    }
}
