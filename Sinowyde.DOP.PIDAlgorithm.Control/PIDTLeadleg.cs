using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 变时间超前滞后算法块（TLEADLEG）LEADLEG3dc13
    /// </summary>
    public class TPIDLeadleg : PIDBindAlgorithm
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

        private double LastAI = 0.0f;
        private double LastX = 0.0f;
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamT1] = new PIDAlgorithmVar(ParamT1, false, PIDVarType.Unknown);
            this.calcParams[ParamT2] = new PIDAlgorithmVar(ParamT2, false, PIDVarType.Unknown);
            this.calcParams[InputPV] = new PIDAlgorithmVar(InputPV, true, PIDVarType.DM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, false, PIDVarType.DM);

        }

        /// <summary>
        ///   4、功能说明
        ///完成超前滞后功能，改善调节品质。 超前时间常数 T1≥0，单位为秒； 
        ///滞后时间常数 T2≥0，单位为秒。
        ///5、算法说明
        ///AO = PV • 1 + T1• S
        ///1 + T 2 • s 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double t1 = this.calcParams[ParamT1].Value;
            double t2 = this.calcParams[ParamT2].Value;
            double pv = this.calcParams[InputPV].Value;
            double ao;
            double tempF = 0.0f;

            if (t1 < 0 || t2 < 0)
                return;

            var dt = GetDt();

            tempF = (float)Math.Exp(-1 / t1 * dt);
            ao = (tempF * LastX + (-t1 / t2 + 1) * (1 - tempF) * LastAI) + t1 / t2 * pv;

            LastX = tempF * LastX + (-t1 / t2 + 1) * (1 - tempF) * LastAI;
            LastAI = pv;
            this.calcResults[ResultAO].Value = ao;
            //paraLEADLEG[ID].LastAO=paraLEADLEG[ID].AOData[0];
            //paraLEADLEG[ID].AOData[0]=out;	
        }

    }
}