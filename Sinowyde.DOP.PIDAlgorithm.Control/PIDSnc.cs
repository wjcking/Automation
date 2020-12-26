using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.3基于单个神经元的自适应控制算法块
    /// </summary>
    public class PIDSnc : PIDBindAlgorithm
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

        ///<summary>
        /// M/A 站输入
        /// </summary>
        public const string ParamX = PIDAlgorithmToken.prefixParam + "X";

        ///<summary>
        /// 前馈输入
        /// </summary>
        public const string ParamFF = PIDAlgorithmToken.prefixParam + "FF";

        ///<summary>
        /// 跟踪输入
        /// </summary>
        public const string ParamTR = PIDAlgorithmToken.prefixParam + "TR";

        ///<summary>
        /// 位置反馈
        /// </summary>
        public const string ParamYP = PIDAlgorithmToken.prefixParam + "YP";

        ///<summary>
        /// 跟踪切换
        /// </summary>
        public const string ParamTS = PIDAlgorithmToken.prefixParam + "TS";

        ///<summary>
        /// 闭锁增
        /// </summary>
        public const string ParamBI = PIDAlgorithmToken.prefixParam + "BI";

        ///<summary>
        /// 闭锁减
        /// </summary>
        public const string ParamBD = PIDAlgorithmToken.prefixParam + "BD";

        ///<summary>
        /// 强制手动信号
        /// </summary>
        public const string ParamMRE = PIDAlgorithmToken.prefixParam + "MRE";

        ///<summary>
        /// M/A 站输出
        /// </summary>
        public const string ParamY = PIDAlgorithmToken.prefixParam + "Y";

        ///<summary>
        /// 设定值输出
        /// </summary>
        public const string ParamSP = PIDAlgorithmToken.prefixParam + "SP";

        ///<summary>
        /// 手操器状态(0—自动；1—手动)
        /// </summary>
        public const string ParamS = PIDAlgorithmToken.prefixParam + "S";

        ///<summary>
        /// 输出增信号
        /// </summary>
        public const string ParamINC = PIDAlgorithmToken.prefixParam + "INC";

        ///<summary>
        /// 输出减信号
        /// </summary>
        public const string ParamDEC = PIDAlgorithmToken.prefixParam + "DEC";

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
            this.calcParams[ParamX] = new PIDAlgorithmVar(ParamX, false, PIDVarDataType.Unknown);
            this.calcParams[ParamFF] = new PIDAlgorithmVar(ParamFF, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTR] = new PIDAlgorithmVar(ParamTR, false, PIDVarDataType.Unknown);
            this.calcParams[ParamYP] = new PIDAlgorithmVar(ParamYP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTS] = new PIDAlgorithmVar(ParamTS, false, PIDVarDataType.Unknown);
            this.calcParams[ParamBI] = new PIDAlgorithmVar(ParamBI, false, PIDVarDataType.Unknown);
            this.calcParams[ParamBD] = new PIDAlgorithmVar(ParamBD, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMRE] = new PIDAlgorithmVar(ParamMRE, false, PIDVarDataType.Unknown);
            this.calcParams[ParamY] = new PIDAlgorithmVar(ParamY, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSP] = new PIDAlgorithmVar(ParamSP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamS] = new PIDAlgorithmVar(ParamS, false, PIDVarDataType.Unknown);
            this.calcParams[ParamINC] = new PIDAlgorithmVar(ParamINC, false, PIDVarDataType.Unknown);
            this.calcParams[ParamDEC] = new PIDAlgorithmVar(ParamDEC, false, PIDVarDataType.Unknown);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {

        }

        /// <summary>
        ///  4、功能说明
        ///当系统发出驱动执行机构的控制信号时，模拟手动站为操作员提供了一个对该控制信号 进行人工干预的界面。
        ///模拟手动站有两种工作方式：自动、手动。
        ///自动方式： Y = (K * X + Bias) + FF
        ///YL ≤ Y ≤ YH ，FF 为前馈信号；
        ///当跟踪切换信号 TS=1 时，Y=TR(TR 为跟踪输入)； 当闭锁增 BI=1，闭锁减 BD=1 时，Y 保持不变；
        ///设定值 SP 即是由运行人员在手操面板上操作的设定值，随面板上 SP 增减按钮而增加 和减少，且 SPL≤SP≤SPH；
        ///在自动方式下，手动输出增减按钮不起作用。
        ///手动方式：输出 Y 由操作员通过手操面板上的手动增减按钮确定。 当闭锁增 BI=1，闭锁减 BD=1 时，Y 保持不变；
        ///当跟踪切换信号 TS=1 时，Y=TR(TR 为跟踪输入)，此时屏蔽闭锁增、闭锁减和手动 增减信号。SP 在此方式下也不起作用，但可增减。
        ///方式切换：
        ///•	强制手动：MRE=1 时，M/A 站切为手动方式。
        ///•	手操面板上的手动、自动按钮使 M/A 站切至手动、自动方式。 当处于自动状态的时候，S 手操器状态输出为 0，当处于手动状态的时候，S 输出为 1。 操作记录：
        ///以下操作在操作员事件记录中进行记录：SP 改变开始、SP 改变结束、输出改变开始、 输出改变结束、方式切换。
        ///M/A 站的软伺放工作方式：
        ///M/A 站的软伺放(ELECTRIC)工作方式，是指当输出 Y 与位置反馈 YP 之间有差、且 偏差大于死区时，
        ///若 Y＞YP＋DEADBAND，则输出 INC 为 1； 若 Y＜YP－DEADBAND，则输出 DEC 为 1。
        ///5、算法说明
        ///自动：Y= (K * X + Bias) + FF
        ///YL ≤ Y ≤ YH
        ///手动：Y=MANOUT
        ///Y 被限制在 YH 和 YL 之间，同时，在跟踪切换期间提供了速率变化限制。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            double bias = this.calcParams[ParamBias].Value;
            double yh = this.calcParams[ParamYH].Value;
            double yl = this.calcParams[ParamYL].Value;
            double sph = this.calcParams[ParamSPH].Value;
            double spl = this.calcParams[ParamSPL].Value;
            double turnover = this.calcParams[ParamTurnOver].Value;
            double fp = this.calcParams[ParamFP].Value;
            double manf = this.calcParams[ParamMANF].Value;
            double mode = this.calcParams[ParamMODE].Value;
            double emode = this.calcParams[ParamEMODE].Value;
            double trate = this.calcParams[ParamTRATE].Value;
            double deadband = this.calcParams[ParamDeadband].Value;
            double ontime = this.calcParams[ParamOnTime].Value;
            double offtime = this.calcParams[ParamOffTime].Value;
            double x = this.calcParams[ParamX].Value;
            double ff = this.calcParams[ParamFF].Value;
            double tr = this.calcParams[ParamTR].Value;
            double yp = this.calcParams[ParamYP].Value;
            double ts = this.calcParams[ParamTS].Value;
            double bi = this.calcParams[ParamBI].Value;
            double bd = this.calcParams[ParamBD].Value;
            double mre = this.calcParams[ParamMRE].Value;
            double y = this.calcParams[ParamY].Value;
            double sp = this.calcParams[ParamSP].Value;
            double s = this.calcParams[ParamS].Value;
            double inc = this.calcParams[ParamINC].Value;
            double dec = this.calcParams[ParamDEC].Value;

        }


    }
}