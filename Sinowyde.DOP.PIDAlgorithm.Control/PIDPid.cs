using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.1PID控制算法块
    /// </summary>
    public class PIDPid : PIDBindAlgorithm
    {
        ///<summary>
        /// 比例带
        /// </summary>
        public const string ParamB = PIDAlgorithmToken.prefixParam + "B";

        ///<summary>
        /// 积分时间 =0 时表示无积分 
        /// </summary>
        public const string ParamTI = PIDAlgorithmToken.prefixParam + "TI";

        ///<summary>
        /// 微分时间 =0 时表示无微分 
        /// </summary>
        public const string ParamTD = PIDAlgorithmToken.prefixParam + "TD";

        ///<summary>
        /// 微分增益
        /// </summary>
        public const string ParamKD = PIDAlgorithmToken.prefixParam + "KD";

        ///<summary>
        /// PV 增益
        /// </summary>
        public const string ParamPVGain = PIDAlgorithmToken.prefixParam + "PVGain";

        ///<summary>
        /// PV 偏置
        /// </summary>
        public const string ParamPVBias = PIDAlgorithmToken.prefixParam + "PVBias";

        ///<summary>
        /// SP 增益
        /// </summary>
        public const string ParamSPGain = PIDAlgorithmToken.prefixParam + "SPGain";

        ///<summary>
        /// SP 偏置
        /// </summary>
        public const string ParamSPBiao = PIDAlgorithmToken.prefixParam + "SPBiao";

        ///<summary>
        /// 输出方式(增量式，位置式)
        /// </summary>
        public const string ParamOutMode = PIDAlgorithmToken.prefixParam + "OutMode";

        ///<summary>
        /// 动作方向(正作用，反作用)
        /// </summary>
        public const string ParamDirect = PIDAlgorithmToken.prefixParam + "Direct";

        ///<summary>
        /// 输出量程上限
        /// </summary>
        public const string ParamHighRange = PIDAlgorithmToken.prefixParam + "HighRange";

        ///<summary>
        /// 输出量程下限
        /// </summary>
        public const string ParamLowRange = PIDAlgorithmToken.prefixParam + "LowRange";

        ///<summary>
        /// 输出上限
        /// </summary>
        public const string ParamHighLmt = PIDAlgorithmToken.prefixParam + "HighLmt";

        ///<summary>
        /// 输出下限
        /// </summary>
        public const string ParamLowLmt = PIDAlgorithmToken.prefixParam + "LowLmt";

        ///<summary>
        /// 偏差报警限
        /// </summary>
        public const string ParamErrALM = PIDAlgorithmToken.prefixParam + "ErrALM";

        ///<summary>
        /// 输出变化率
        /// </summary>
        public const string ParamOutRate = PIDAlgorithmToken.prefixParam + "OutRate";

        ///<summary>
        /// 过程变量
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixInput + "PV";

        ///<summary>
        /// 设定值
        /// </summary>
        public const string InputSP = PIDAlgorithmToken.prefixInput + "SP";

        ///<summary>
        /// 前馈值
        /// </summary>
        public const string InputFF = PIDAlgorithmToken.prefixInput + "FF";

        ///<summary>
        /// 跟踪值
        /// </summary>
        public const string InputTR = PIDAlgorithmToken.prefixInput + "TR";

        ///<summary>
        /// KKP 比例增益
        /// </summary>
        public const string InputKKP = PIDAlgorithmToken.prefixInput + "KKP";

        ///<summary>
        /// KTI 积分增益
        /// </summary>
        public const string InputKTI = PIDAlgorithmToken.prefixInput + "KTI";

        ///<summary>
        /// KTD 微分增益
        /// </summary>
        public const string InputKTD = PIDAlgorithmToken.prefixInput + "KTD";

        ///<summary>
        /// PID 死区
        /// </summary>
        public const string InputPIDDB = PIDAlgorithmToken.prefixInput + "PIDDB";

        ///<summary>
        /// 跟踪方式 0—自动；1—跟踪 
        /// </summary>
        public const string InputSTR = PIDAlgorithmToken.prefixInput + "STR";

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
            this.calcParams[ParamB] = new PIDAlgorithmVar(ParamB, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamTI] = new PIDAlgorithmVar(ParamTI, false, PIDVarDataType.AM);
            this.calcParams[ParamTD] = new PIDAlgorithmVar(ParamTD, false, PIDVarDataType.AM);
            this.calcParams[ParamKD] = new PIDAlgorithmVar(ParamKD, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamPVGain] = new PIDAlgorithmVar(ParamPVGain, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamPVBias] = new PIDAlgorithmVar(ParamPVBias, false, PIDVarDataType.AM);
            this.calcParams[ParamSPGain] = new PIDAlgorithmVar(ParamSPGain, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamSPBiao] = new PIDAlgorithmVar(ParamSPBiao, false, PIDVarDataType.AM);
            this.calcParams[ParamOutMode] = new PIDAlgorithmVar(ParamOutMode, false, PIDVarDataType.AM);
            this.calcParams[ParamDirect] = new PIDAlgorithmVar(ParamDirect, false, PIDVarDataType.AM);
            this.calcParams[ParamHighRange] = new PIDAlgorithmVar(ParamHighRange, false, PIDVarDataType.AM) { Value = 100 };
            this.calcParams[ParamLowRange] = new PIDAlgorithmVar(ParamLowRange, false, PIDVarDataType.AM);
            this.calcParams[ParamHighLmt] = new PIDAlgorithmVar(ParamHighLmt, false, PIDVarDataType.AM) { Value = 100 };
            this.calcParams[ParamLowLmt] = new PIDAlgorithmVar(ParamLowLmt, false, PIDVarDataType.AM);
            this.calcParams[ParamErrALM] = new PIDAlgorithmVar(ParamErrALM, false, PIDVarDataType.AM) { Value = 20 };
            this.calcParams[ParamOutRate] = new PIDAlgorithmVar(ParamOutRate, false, PIDVarDataType.AM) { Value = 5 };

            this.calcParams[InputPV] = new PIDAlgorithmVar(InputPV, true, PIDVarDataType.AM);
            this.calcParams[InputSP] = new PIDAlgorithmVar(InputSP, true, PIDVarDataType.AM);
            this.calcParams[InputFF] = new PIDAlgorithmVar(InputFF, true, PIDVarDataType.AM);
            this.calcParams[InputTR] = new PIDAlgorithmVar(InputTR, true, PIDVarDataType.AM);
            this.calcParams[InputKKP] = new PIDAlgorithmVar(InputKKP, true, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[InputKTI] = new PIDAlgorithmVar(InputKTI, true, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[InputKTD] = new PIDAlgorithmVar(InputKTD, true, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[InputPIDDB] = new PIDAlgorithmVar(InputPIDDB, true, PIDVarDataType.AM);
            this.calcParams[InputSTR] = new PIDAlgorithmVar(InputSTR, true, PIDVarDataType.DM) { Value = 1 };//0-自动;1-跟踪
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, true, PIDVarDataType.AM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, true, PIDVarDataType.DM);
        }

        /// <summary>
        ///4、功能说明
        ///本算法块能完成常规 PID 控制算法。有多种工作状态，手动、自动、跟踪，这些状态 间的切换是无扰的。具有前馈、反馈输入端，可以进行变比例带调节，抗积分饱和，积分项 平衡，绝对值和偏差报警。
        ///PV 增益和 PV 偏置：对过程变量 PV 进行标度变换，使 PV 处于 0~100%范围内。 
        ///SP 增益和 SP 偏置：对设定值 SP 进行标度变换，使 SP 处于 0~100%范围内。
        ///5、算法说明 
        ///在自动时，Y(s)＝ 在跟踪时，Y(s) = TR(s)
        ///然后，将 Y 限制在 HighRange 和 LowRange 之间。 本功能块具有输出速率限制的功能，输出 Y 的变化率被限制在输出变化率 OutRate 以内。 当发生偏差报警时，DO 输出为 1；当偏差报警解除后，DO 输出为 0。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double b = this.calcParams[ParamB].Value;
            double ti = this.calcParams[ParamTI].Value;
            double td = this.calcParams[ParamTD].Value;
            double kd = this.calcParams[ParamKD].Value;
            double pvgain = this.calcParams[ParamPVGain].Value;
            double pvbias = this.calcParams[ParamPVBias].Value;
            double spgain = this.calcParams[ParamSPGain].Value;
            double spbiao = this.calcParams[ParamSPBiao].Value;
            double outmode = this.calcParams[ParamOutMode].Value;
            double direct = this.calcParams[ParamDirect].Value;
            double highRange = this.calcParams[ParamHighRange].Value;
            double lowRange = this.calcParams[ParamLowRange].Value;
            double highlmt = this.calcParams[ParamHighLmt].Value;
            double lowlmt = this.calcParams[ParamLowLmt].Value;
            double erralm = this.calcParams[ParamErrALM].Value;
            double outRate = this.calcParams[ParamOutRate].Value;
            double pv = this.calcParams[InputPV].Value;
            double sp = this.calcParams[InputSP].Value;
            double ff = this.calcParams[InputFF].Value;
            double tr = this.calcParams[InputTR].Value;
            double kkp = this.calcParams[InputKKP].Value;
            double kti = this.calcParams[InputKTI].Value;
            double ktd = this.calcParams[InputKTD].Value;
            double piddb = this.calcParams[InputPIDDB].Value;

            var s = GetDt();
            double y = 0;
            if (ConvertUtil.ConvertToInt(calcParams[InputSTR].Value).Equals(0))//自动
            {
                y = kkp / b + kti / (ti * s) + (kd * ktd * td * s) / (td * s + 1);
            }
            else//手动
            {
                y = tr * s;
            }



            if (y < lowRange)
                y = lowRange;

            if (y > highRange)
                y = highRange;

            //y的变化率
            if (y <= outRate)
            {

            }

        }
    }
}