using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 8 输入平衡算法块（8IB）8 INPUT BALANCEd6d91
    /// </summary>
    public class PID8ib : PIDBindAlgorithm
    {
        ///<summary>
        /// 模拟量输出高限
        /// </summary>
        public const string ParamHigh = PIDAlgorithmToken.prefixParam + "High";

        ///<summary>
        /// 模拟量输出低限
        /// </summary>
        public const string ParamLow = PIDAlgorithmToken.prefixParam + "Low";

        ///<summary>
        /// 输出值选择
        /// </summary>
        public const string ParamSout = PIDAlgorithmToken.prefixParam + "Sout";

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";

        ///<summary>
        /// 1~8 路跟踪信号
        /// </summary>
        public const string InputTR1 = PIDAlgorithmToken.prefixInput + "TR1";
        public const string InputTR2 = PIDAlgorithmToken.prefixInput + "TR2";
        public const string InputTR3 = PIDAlgorithmToken.prefixInput + "TR3";
        public const string InputTR4 = PIDAlgorithmToken.prefixInput + "TR4";
        public const string InputTR5 = PIDAlgorithmToken.prefixInput + "TR5";
        public const string InputTR6 = PIDAlgorithmToken.prefixInput + "TR6";
        public const string InputTR7 = PIDAlgorithmToken.prefixInput + "TR7";
        public const string InputTR8 = PIDAlgorithmToken.prefixInput + "TR8";

        ///<summary>
        /// 1~8 路跟踪开关
        /// </summary>
        public const string InputTS1 = PIDAlgorithmToken.prefixInput + "TS1";
        public const string InputTS2 = PIDAlgorithmToken.prefixInput + "TS2";
        public const string InputTS3 = PIDAlgorithmToken.prefixInput + "TS3";
        public const string InputTS4 = PIDAlgorithmToken.prefixInput + "TS4";
        public const string InputTS5 = PIDAlgorithmToken.prefixInput + "TS5";
        public const string InputTS6 = PIDAlgorithmToken.prefixInput + "TS6";
        public const string InputTS7 = PIDAlgorithmToken.prefixInput + "TS7";
        public const string InputTS8 = PIDAlgorithmToken.prefixInput + "TS8";

        ///<summary>
        /// 模拟量输出
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        ///<summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmVar(ParamHigh, false, PIDVarDataType.Unknown);
            this.calcParams[ParamLow] = new PIDAlgorithmVar(ParamLow, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSout] = new PIDAlgorithmVar(ParamSout, false, PIDVarDataType.Unknown);
            this.calcParams[InputAI] = new PIDAlgorithmVar(InputAI, true, PIDVarDataType.DM);
            this.calcParams[InputTR1] = new PIDAlgorithmVar(InputTR1, true, PIDVarDataType.DM);
            this.calcParams[InputTR2] = new PIDAlgorithmVar(InputTR2, true, PIDVarDataType.DM);
            this.calcParams[InputTR3] = new PIDAlgorithmVar(InputTR3, true, PIDVarDataType.DM);
            this.calcParams[InputTR4] = new PIDAlgorithmVar(InputTR4, true, PIDVarDataType.DM);
            this.calcParams[InputTR5] = new PIDAlgorithmVar(InputTR5, true, PIDVarDataType.DM);
            this.calcParams[InputTR6] = new PIDAlgorithmVar(InputTR6, true, PIDVarDataType.DM);
            this.calcParams[InputTR7] = new PIDAlgorithmVar(InputTR7, true, PIDVarDataType.DM);
            this.calcParams[InputTR8] = new PIDAlgorithmVar(InputTR8, true, PIDVarDataType.DM);
            this.calcParams[InputTS1] = new PIDAlgorithmVar(InputTS1, true, PIDVarDataType.DM);
            this.calcParams[InputTS2] = new PIDAlgorithmVar(InputTS2, true, PIDVarDataType.DM);
            this.calcParams[InputTS3] = new PIDAlgorithmVar(InputTS3, true, PIDVarDataType.DM);
            this.calcParams[InputTS4] = new PIDAlgorithmVar(InputTS4, true, PIDVarDataType.DM);
            this.calcParams[InputTS5] = new PIDAlgorithmVar(InputTS5, true, PIDVarDataType.DM);
            this.calcParams[InputTS6] = new PIDAlgorithmVar(InputTS6, true, PIDVarDataType.DM);
            this.calcParams[InputTS7] = new PIDAlgorithmVar(InputTS7, true, PIDVarDataType.DM);
            this.calcParams[InputTS8] = new PIDAlgorithmVar(InputTS8, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, false, PIDVarDataType.DM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, false, PIDVarDataType.DM);

        }

        /// <summary>
        ///4、功能说明
        ///反馈跟踪值及其对应的跟踪开关最多可达 8 对，实际跟踪点的对数为所有 8 对中输入不 为 NULL 的测点(跟踪开关及跟踪值中任何一个为空点时)的总数，记为 N。
        ///在 N 个有效跟踪信号 TR 中，若其跟踪开关 TS 为 1，则为手动点；TS 为 0，则为自动 点。设自动点的个数为 K(N≥K≥0)，
        ///若 K＞0，平衡器的输出 Y 为：所有手动点跟踪值之和
        ///输出，	开出DO＝0
        ///其中：AI为输入信号， TR为跟踪信号值， TS为跟踪开关
        ///若 K＝0，即所有信号都处于跟踪状态，此时输出 AO =N
        ///∑TR(i) 
        ///i=1	为跟踪输出，数字量N
        ///输出 DO＝1。
        ///模拟量输出 AO 如果大于输出上限或者小于输出下限，本算法块就相应的进行限幅。 输出值选择 Sout 可设置为：所有输入均值、最大值或最小值。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;
            double sout = this.calcParams[ParamSout].Value;
            double ai = this.calcParams[InputAI].Value;
            double tr1 = this.calcParams[InputTR1].Value;
            double tr2 = this.calcParams[InputTR2].Value;
            double tr3 = this.calcParams[InputTR3].Value;
            double tr4 = this.calcParams[InputTR4].Value;
            double tr5 = this.calcParams[InputTR5].Value;
            double tr6 = this.calcParams[InputTR6].Value;
            double tr7 = this.calcParams[InputTR7].Value;
            double tr8 = this.calcParams[InputTR8].Value;
            double ts1 = this.calcParams[InputTS1].Value;
            double ts2 = this.calcParams[InputTS2].Value;
            double ts3 = this.calcParams[InputTS3].Value;
            double ts4 = this.calcParams[InputTS4].Value;
            double ts5 = this.calcParams[InputTS5].Value;
            double ts6 = this.calcParams[InputTS6].Value;
            double ts7 = this.calcParams[InputTS7].Value;
            double ts8 = this.calcParams[InputTS8].Value;
            //double ao =  this.calcResults[ResultAO].Value;
            //double do =  this.calcResults[ResultDO].Value;

        }

    }
}