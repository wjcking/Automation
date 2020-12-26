using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 超前滞后算法块（LEADLEG）
    /// </summary>
    [Serializable]
    public class PIDLeadleg : PIDBindAlgorithm
    {
        ///<summary>
        /// 超前时间常数
        /// </summary>
        public const string ParamT1 = PIDAlgorithmToken.prefixParam + "T1";

        ///<summary>
        /// 滞后时间常数
        /// </summary>
        public const string ParamT2 = PIDAlgorithmToken.prefixParam + "T2";

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixInput + "PV";

        ///<summary>
        /// 模拟量输出
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        private double LastAI = 1.0f;
        private double LastX = 1.0f;
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamT1] = new PIDAlgorithmParam(ParamT1);
            this.calcParams[ParamT2] = new PIDAlgorithmParam(ParamT2, 1);
        }
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputPV] = new PIDAlgorithmVar(InputPV, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }

        /// <summary>
        ///4、功能说明
        ///完成超前滞后功能，改善调节品质。 超前时间常数 T1≥0，单位为秒； 
        ///滞后时间常数 T2≥0，单位为秒。
        ///5、算法说明
        ///AO = PV • 1 + T1• S
        ///1 + T 2 • s 
        ///
        /// 2016/4/1 添加条件：当输入为0时输出为0； 当t2=0时，直接输出
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double t1 = this.calcParams[ParamT1].Value;
            double t2 = this.calcParams[ParamT2].Value;
            double pv = this.calcInputs[InputPV].Value;
            //
            if (pv == 0)
            {
                this.calcResults[ResultAO].Value = 0;
                return;
            }
            else
            {
               // pv = pv == 0 ? 1 : pv;
                if (t2 == 0)
                {
                    this.calcResults[ResultAO].Value = pv;
                    return;
                }
                else
                {
                    var dt = GetDt();

                    dt = dt == 0 ? 1 : dt;

                    double exped = Math.Exp(-1 / t2 * dt);
                    double ao = (exped * LastX + (-t1 / t2 + 1) * (1 - exped) * pv) + t1 / t2 * pv;

                    LastX = exped * LastX + (-t1 / t2 + 1) * (1 - exped) * LastAI;
                    LastAI = pv;
                    this.calcResults[ResultAO].Value = ao;
                }
            }
        }

        public override string AlgName
        {
            get { return "超前滞后算法块"; }
        }
    }
}