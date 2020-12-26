
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.4模拟手动站算法块
    /// </summary>
    public class PIDMa : PIDBindAlgorithm
    {
        ///<summary>
        /// 输出增益
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";

        ///<summary>
        /// 输出偏置
        /// </summary>
        public const string ParamBias = PIDAlgorithmToken.prefixParam + "Bias";

        ///<summary>
        /// 输出上限
        /// </summary>
        public const string ParamYH = PIDAlgorithmToken.prefixParam + "YH";

        //--------------------------------------------------1
        ///<summary>
        /// 输出下限
        /// </summary>
        public const string ParamYL = PIDAlgorithmToken.prefixParam + "YL";

        ///<summary>
        /// 设定值上限
        /// </summary>
        public const string ParamSPH = PIDAlgorithmToken.prefixParam + "SPH";

        ///<summary>
        /// 设定值下限
        /// </summary>
        public const string ParamSPL = PIDAlgorithmToken.prefixParam + "SPL";

        ///<summary>
        /// 输出反向(0—0%~100%；1—100%~0%)
        /// </summary>
        public const string ParamTurnOver = PIDAlgorithmToken.prefixParam + "TurnOver";

        ///<summary>
        /// 初始化方式(0—手动；1—自动)
        /// </summary>
        public const string ParamFP = PIDAlgorithmToken.prefixParam + "FP";

        ///<summary>
        /// 手动禁止(0—允许手动；1—只能自动)
        /// </summary>
        public const string ParamMANF = PIDAlgorithmToken.prefixParam + "MANF";

        ///<summary>
        /// 工作方式(0—Normal；1—Electric)
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";

        ///<summary>
        /// Electric 输出方式(0—长信号；1—脉冲)
        /// </summary>
        public const string ParamEMODE = PIDAlgorithmToken.prefixParam + "EMODE";

        ///<summary>
        /// 跟踪切换时变化率
        /// </summary>
        public const string ParamTRATE = PIDAlgorithmToken.prefixParam + "TRATE";

        ///<summary>
        /// 死区
        /// </summary>
        public const string ParamDeadband = PIDAlgorithmToken.prefixParam + "Deadband";

        ///<summary>
        /// 高电平宽度
        /// </summary>
        public const string ParamOnTime = PIDAlgorithmToken.prefixParam + "OnTime";

        ///<summary>
        /// 低电平宽度
        /// </summary>
        public const string ParamOffTime = PIDAlgorithmToken.prefixParam + "OffTime";

        //--------------------------------------------------1
        ///<summary>
        /// M/A 站输入
        /// </summary>
        public const string InputX = PIDAlgorithmToken.prefixInput + "X";

        ///<summary>
        /// 前馈输入
        /// </summary>
        public const string InputFF = PIDAlgorithmToken.prefixInput + "FF";

        ///<summary>
        /// 跟踪输入
        /// </summary>
        public const string InputTR = PIDAlgorithmToken.prefixInput + "TR";

        ///<summary>
        /// 位置反馈
        /// </summary>
        public const string InputYP = PIDAlgorithmToken.prefixInput + "YP";

        ///<summary>
        /// 给定跟踪
        /// </summary>
        public const string ParamSPT = PIDAlgorithmToken.prefixParam + "SPT";

        ///<summary>
        /// 跟踪切换
        /// </summary>
        public const string InputTS = PIDAlgorithmToken.prefixInput + "TS";

        ///<summary>
        /// 闭锁增
        /// </summary>
        public const string InputBI = PIDAlgorithmToken.prefixInput + "BI";

        ///<summary>
        /// 闭锁减
        /// </summary>
        public const string InputBD = PIDAlgorithmToken.prefixInput + "BD";

        ///<summary>
        /// 强制手动信号
        /// </summary>
        public const string InputMRE = PIDAlgorithmToken.prefixInput + "MRE";

        ///<summary>
        /// 自动请求
        /// </summary>
        public const string ParamAR = PIDAlgorithmToken.prefixParam + "AR";

        ///<summary>
        /// M/A 站输出
        /// </summary>
        public const string ResultY = PIDAlgorithmToken.prefixResult + "Y";

        ///<summary>
        /// 设定值输出
        /// </summary>
        public const string ResultSP = PIDAlgorithmToken.prefixResult + "SP";

        ///<summary>
        /// 手操器状态(0—自动；1—手动)
        /// </summary>
        public const string ResultS = PIDAlgorithmToken.prefixResult + "S";

        ///<summary>
        /// 输出增信号
        /// </summary>
        public const string ResultINC = PIDAlgorithmToken.prefixResult + "INC";

        ///<summary>
        /// 输出减信号
        /// </summary>
        public const string ResultDEC = PIDAlgorithmToken.prefixResult + "DEC";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmVar(ParamK, false, PIDVarDataType.Unknown);
            this.calcParams[ParamBias] = new PIDAlgorithmVar(ParamBias, false, PIDVarDataType.Unknown);
            this.calcParams[ParamYH] = new PIDAlgorithmVar(ParamYH, false, PIDVarDataType.Unknown);
            this.calcParams[ParamYL] = new PIDAlgorithmVar(ParamYL, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSPH] = new PIDAlgorithmVar(ParamSPH, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSPL] = new PIDAlgorithmVar(ParamSPL, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTurnOver] = new PIDAlgorithmVar(ParamTurnOver, false, PIDVarDataType.Unknown);
            this.calcParams[ParamFP] = new PIDAlgorithmVar(ParamFP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMANF] = new PIDAlgorithmVar(ParamMANF, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMODE] = new PIDAlgorithmVar(ParamMODE, false, PIDVarDataType.Unknown);
            this.calcParams[ParamEMODE] = new PIDAlgorithmVar(ParamEMODE, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTRATE] = new PIDAlgorithmVar(ParamTRATE, false, PIDVarDataType.Unknown);
            this.calcParams[ParamDeadband] = new PIDAlgorithmVar(ParamDeadband, false, PIDVarDataType.Unknown);
            this.calcParams[ParamOnTime] = new PIDAlgorithmVar(ParamOnTime, false, PIDVarDataType.Unknown);
            this.calcParams[ParamOffTime] = new PIDAlgorithmVar(ParamOffTime, false, PIDVarDataType.Unknown);
            this.calcParams[InputX] = new PIDAlgorithmVar(InputX, true, PIDVarDataType.DM);
            this.calcParams[InputFF] = new PIDAlgorithmVar(InputFF, true, PIDVarDataType.DM);
            this.calcParams[InputTR] = new PIDAlgorithmVar(InputTR, true, PIDVarDataType.DM);
            this.calcParams[InputYP] = new PIDAlgorithmVar(InputYP, true, PIDVarDataType.DM);
            this.calcParams[ParamSPT] = new PIDAlgorithmVar(ParamSPT, false, PIDVarDataType.Unknown);
            this.calcParams[InputTS] = new PIDAlgorithmVar(InputTS, true, PIDVarDataType.DM);
            this.calcParams[InputBI] = new PIDAlgorithmVar(InputBI, true, PIDVarDataType.DM);
            this.calcParams[InputBD] = new PIDAlgorithmVar(InputBD, true, PIDVarDataType.DM);
            this.calcParams[InputMRE] = new PIDAlgorithmVar(InputMRE, true, PIDVarDataType.DM);
            this.calcParams[ParamAR] = new PIDAlgorithmVar(ParamAR, false, PIDVarDataType.Unknown);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultY] = new PIDAlgorithmVar(ResultY, false, PIDVarDataType.DM);
            this.calcResults[ResultSP] = new PIDAlgorithmVar(ResultSP, false, PIDVarDataType.DM);
            this.calcResults[ResultS] = new PIDAlgorithmVar(ResultS, false, PIDVarDataType.DM);
            this.calcResults[ResultINC] = new PIDAlgorithmVar(ResultINC, false, PIDVarDataType.DM);
            this.calcResults[ResultDEC] = new PIDAlgorithmVar(ResultDEC, false, PIDVarDataType.Unknown);

        }

        ///<summary>
        /// 当系统发出驱动执行机构的控制信号时，模拟手动站为操作员提供了一个对该控制信号 进行人工干预的界面。
        ///模拟手动站有两种工作方式：自动、手动。
        ///自动方式： Y = (K * X + Bias) + FF YL ≤ Y ≤ YH ，FF 为前馈信号；
        ///当跟踪切换信号 TS=1 时，Y=TR(TR 为跟踪输入)； 当闭锁增 BI=1，闭锁减 BD=1 时，Y 保持不变；
        ///设定值 SP 即是由运行人员在手操面板上操作的设定值，随面板上 SP 增减按钮而增加 和减少，且 SPL≤SP≤SPH；
        ///在自动方式下，手动输出增减按钮不起作用。
        ///手动方式：输出 Y 由操作员通过手操面板上的手动增减按钮确定。 当闭锁增 BI=1，闭锁减 BD=1 时，Y 保持不变；
        ///当跟踪切换信号 TS=1 时，Y=TR(TR 为跟踪输入)，此时屏蔽闭锁增、闭锁减和手动 增减信号。SP 在此方式下也不起作用，但可增减。
        ///方式切换：
        ///•强制手动：MRE=1 时，M/A 站切为手动方式。
        ///•手操面板上的手动、自动按钮使 M/A 站切至手动、自动方式。 当处于自动状态的时候，S 手操器状态输出为 0，当处于手动状态的时候，S 输出为 1。 操作记录：
        ///以下操作在操作员事件记录中进行记录：SP 改变开始、SP 改变结束、输出改变开始、 输出改变结束、方式切换。
        ///M A 站的软伺放工作方式：
        ///M A 站的软伺放(ELECTRIC)工作方式，是指当输出 Y 与位置反馈 YP 之间有差、且 偏差大于死区时，
        ///若 Y＞YP＋DEADBAND，则输出 INC 为 1； 若 Y＜YP－DEADBAND，则输出 DEC 为 1。
        ///5、算法说明
        ///自动：Y= (K * X + Bias) + FF
        ///YL ≤ Y ≤ YH手动：Y=MANOUT Y 被限制在 YH 和 YL 之间，同时，在跟踪切换期间提供了速率变化限制。
        ///</summary>    
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            double bias = this.calcParams[ParamBias].Value;
            double yh = this.calcParams[ParamYH].Value;
            double yl = this.calcParams[ParamYL].Value;
            double sph = this.calcParams[ParamSPH].Value;
            double spl = this.calcParams[ParamSPL].Value;
            double turnover = this.calcParams[ParamTurnOver].Value;
            bool fp = this.calcParams[ParamFP].ValueToBool();
            bool manf = this.calcParams[ParamMANF].ValueToBool();
            bool mode = this.calcParams[ParamMODE].ValueToBool();
            bool emode = this.calcParams[ParamEMODE].ValueToBool();
            double trate = this.calcParams[ParamTRATE].Value;
            double deadband = this.calcParams[ParamDeadband].Value;
            double ontime = this.calcParams[ParamOnTime].Value;
            double offtime = this.calcParams[ParamOffTime].Value;
            double dec = this.calcParams[ResultDEC].Value;
            double x = this.calcParams[InputX].Value;
            double ff = this.calcParams[InputFF].Value;
            double tr = this.calcParams[InputTR].Value;
            double yp = this.calcParams[InputYP].Value;
            double spt = this.calcParams[ParamSPT].Value;
            bool ts = this.calcParams[InputTS].ValueToBool();
            bool bi = this.calcParams[InputBI].ValueToBool();
            bool bd = this.calcParams[InputBD].ValueToBool();
            bool mre = this.calcParams[InputMRE].ValueToBool();
            double ar = this.calcParams[ParamAR].Value;

            double sp = this.calcResults[ResultSP].Value;
            //double s = this.calcResults[ResultS].Value;
            //double inc = this.calcResults[ResultINC].Value;

            if (fp)
            {
                if (spl > sp && sp <= sph)
                {
                }
                else
                    this.calcResults[ResultSP].Value = spl;
            }
            else//自动
            {
                double y = (k * x + bias) + ff;
                if (yl <= y && y <= yh)
                    calcResults[ResultY].Value = y;

                if (bi && bd)
                {
                }
            }

            if (ts)
            {
                calcResults[ResultY].Value = tr;
            }

            if (mre)
            {
                this.calcParams[ParamFP].Value = 0;
            }

            if (calcResults[ResultY].Value > yp + deadband)
                this.calcResults[ResultINC].Value = 1;
            else if (calcResults[ResultY].Value < yp - deadband)
                this.calcResults[ResultDEC].Value = 1;
        }
    }
}