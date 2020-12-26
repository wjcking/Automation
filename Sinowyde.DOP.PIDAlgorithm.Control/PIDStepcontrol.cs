    
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.10步序控制算法块
    /// </summary>
    public class PIDStepcontrol : PIDBindAlgorithm
    {
        ///<summary>
        /// 最大步数，1 小于 MAXS 小于8
        /// </summary>
        public const string ParamMAXS = PIDAlgorithmToken.prefixParam + "MAXS";

        ///<summary>
        /// 第 n 步设定时间，当步序执行时间达到该时间时， 并且相应的反 馈为 1 ，自动 转入下一步执 行。 SetTime 必须不小于 0。
        /// </summary>
        public const string ParamSetTime1 = PIDAlgorithmToken.prefixParam + "SetTime1";
        public const string ParamSetTime2 = PIDAlgorithmToken.prefixParam + "SetTime2";
        public const string ParamSetTime3 = PIDAlgorithmToken.prefixParam + "SetTime3";
        public const string ParamSetTime4 = PIDAlgorithmToken.prefixParam + "SetTime4";
        public const string ParamSetTime5 = PIDAlgorithmToken.prefixParam + "SetTime5";
        public const string ParamSetTime6 = PIDAlgorithmToken.prefixParam + "SetTime6";
        public const string ParamSetTime7 = PIDAlgorithmToken.prefixParam + "SetTime7";
        public const string ParamSetTime8 = PIDAlgorithmToken.prefixParam + "SetTime8";

        ///<summary>
        /// 第 n 步限定时间，当步序执行时间超过该时间时，
        ///相应的反馈还没有到达，步序故障信号发出，步序 逻辑被暂停．再掀启动按扭，步序重新计时执行．当 Tlimit n=0 时，该功能被废止。Tlmit 必须不小于 0。
        /// </summary>
        public const string ParamTlimit1 = PIDAlgorithmToken.prefixParam + "Tlimit1";
        public const string ParamTlimit2 = PIDAlgorithmToken.prefixParam + "Tlimit2";
        public const string ParamTlimit3 = PIDAlgorithmToken.prefixParam + "Tlimit3";
        public const string ParamTlimit4 = PIDAlgorithmToken.prefixParam + "Tlimit4";
        public const string ParamTlimit5 = PIDAlgorithmToken.prefixParam + "Tlimit5";
        public const string ParamTlimit6 = PIDAlgorithmToken.prefixParam + "Tlimit6";
        public const string ParamTlimit7 = PIDAlgorithmToken.prefixParam + "Tlimit7";
        public const string ParamTlimit8 = PIDAlgorithmToken.prefixParam + "Tlimit8";

        ///<summary>
        /// 预置步，当 0小于Tmode小于MAXS 时，按启动按钮，从
        ///预置步开始执行。
        /// </summary>
        public const string InputTmode = PIDAlgorithmToken.prefixInput + "Tmode";

        ///<summary>
        /// 按位禁止步。最低 8 位 b0-b7 对应 Step1-Step8，
        ///为 1 时禁止或跳过对应的步。
        /// </summary>
        public const string InputBitDis = PIDAlgorithmToken.prefixInput + "BitDis";

        ///<summary>
        /// 步序逻辑启动信号
        /// </summary>
        public const string InputStart = PIDAlgorithmToken.prefixInput + "Start";

        ///<summary>
        /// 步序暂停信号，步序逻辑被暂停，再按启动按钮，
        ///步序从断点开始重新执行。
        /// </summary>
        public const string InputStop = PIDAlgorithmToken.prefixInput + "Stop";

        ///<summary>
        /// 步序延时，为 1 时停留在当前步。
        /// </summary>
        public const string InputDelay = PIDAlgorithmToken.prefixInput + "Delay";

        ///<summary>
        /// 第 n 步动作完成，第 n 步动作反馈信号或第 n+1 步 动作允许信号。
        /// </summary>
        public const string InputFB1 = PIDAlgorithmToken.prefixInput + "FB1";
        public const string InputFB2 = PIDAlgorithmToken.prefixInput + "FB2";
        public const string InputFB3 = PIDAlgorithmToken.prefixInput + "FB3";
        public const string InputFB4 = PIDAlgorithmToken.prefixInput + "FB4";
        public const string InputFB5 = PIDAlgorithmToken.prefixInput + "FB5";
        public const string InputFB6 = PIDAlgorithmToken.prefixInput + "FB6";
        public const string InputFB7 = PIDAlgorithmToken.prefixInput + "FB7";
        public const string InputFB8 = PIDAlgorithmToken.prefixInput + "FB8";
                                     
        ///<summary>
        /// 复位，步序逻辑结束。
        /// </summary>
        public const string InputRst = PIDAlgorithmToken.prefixInput + "Rst";

        ///<summary>
        /// 单步方式，启动后只执行一步。
        /// </summary>
        public const string InputDStep = PIDAlgorithmToken.prefixInput + "DStep";

        ///<summary>
        /// 跳步，跳过当前步执行下一步，如果当前步为最大 步，则步序逻辑结束。
        /// </summary>
        public const string InputJStep = PIDAlgorithmToken.prefixInput + "JStep";

        ///<summary>
        /// 当前步，输出正在执行的步序号
        /// </summary>
        public const string ResultStep = PIDAlgorithmToken.prefixResult + "Step";

        ///<summary>
        /// 步序进行时间，输出正在进行的步序已进行的时间。
        /// </summary>
        public const string ResultTrun = PIDAlgorithmToken.prefixResult + "Trun";

        ///<summary>
        /// 步序剩余时间，输出正在进行的步序还剩余的时间。
        /// </summary>
        public const string ResultTrst = PIDAlgorithmToken.prefixResult + "Trst";

        ///<summary>
        /// 步序进行，步序逻辑正在进行时，输出 1。
        /// </summary>
        public const string ResultRun = PIDAlgorithmToken.prefixResult + "Run";

        ///<summary>
        /// 当任意步序超时或者步序被暂停，输出 1。
        /// </summary>
        public const string ResultFail = PIDAlgorithmToken.prefixResult + "Fail";

        ///<summary>
        /// 步序完成，当步序成功完成设定的最大步序或者第8 步时，输出 1。
        /// </summary>
        public const string ResultEnd = PIDAlgorithmToken.prefixResult + "End";

        ///<summary>
        /// 第 n 步指令，第 n 步指令有效时为 1。
        /// </summary>
        public const string ResultSTEP1  = PIDAlgorithmToken.prefixResult + "STEP1";
        public const string ResultSTEP2  = PIDAlgorithmToken.prefixResult + "STEP2";
        public const string ResultSTEP3  = PIDAlgorithmToken.prefixResult + "STEP3";
        public const string ResultSTEP4  = PIDAlgorithmToken.prefixResult + "STEP4";
        public const string ResultSTEP5  = PIDAlgorithmToken.prefixResult + "STEP5";
        public const string ResultSTEP6  = PIDAlgorithmToken.prefixResult + "STEP6";
        public const string ResultSTEP7 =  PIDAlgorithmToken.prefixResult + "STEP7";
        public const string ResultSTEP8  = PIDAlgorithmToken.prefixResult + "STEP8";


        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMAXS] = new PIDAlgorithmVar(ParamMAXS, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime1] = new PIDAlgorithmVar(ParamSetTime1, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime2] = new PIDAlgorithmVar(ParamSetTime2, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime3] = new PIDAlgorithmVar(ParamSetTime3, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime4] = new PIDAlgorithmVar(ParamSetTime4, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime5] = new PIDAlgorithmVar(ParamSetTime5, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime6] = new PIDAlgorithmVar(ParamSetTime6, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime7] = new PIDAlgorithmVar(ParamSetTime7, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime8] = new PIDAlgorithmVar(ParamSetTime8, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit1] = new PIDAlgorithmVar(ParamTlimit1, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit2] = new PIDAlgorithmVar(ParamTlimit2, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit3] = new PIDAlgorithmVar(ParamTlimit3, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit4] = new PIDAlgorithmVar(ParamTlimit4, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit5] = new PIDAlgorithmVar(ParamTlimit5, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit6] = new PIDAlgorithmVar(ParamTlimit6, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit7] = new PIDAlgorithmVar(ParamTlimit7, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit8] = new PIDAlgorithmVar(ParamTlimit8, false, PIDVarDataType.Unknown);
            this.calcParams[InputTmode] = new PIDAlgorithmVar(InputTmode, true, PIDVarDataType.DM);
            this.calcParams[InputBitDis] = new PIDAlgorithmVar(InputBitDis, true, PIDVarDataType.DM);
            this.calcParams[InputStart] = new PIDAlgorithmVar(InputStart, true, PIDVarDataType.DM);
            this.calcParams[InputStop] = new PIDAlgorithmVar(InputStop, true, PIDVarDataType.DM);
            this.calcParams[InputDelay] = new PIDAlgorithmVar(InputDelay, true, PIDVarDataType.DM);
            this.calcParams[InputFB1] = new PIDAlgorithmVar(InputFB1, true, PIDVarDataType.DM);
            this.calcParams[InputFB2] = new PIDAlgorithmVar(InputFB2, true, PIDVarDataType.DM);
            this.calcParams[InputFB3] = new PIDAlgorithmVar(InputFB3, true, PIDVarDataType.DM);
            this.calcParams[InputFB4] = new PIDAlgorithmVar(InputFB4, true, PIDVarDataType.DM);
            this.calcParams[InputFB5] = new PIDAlgorithmVar(InputFB5, true, PIDVarDataType.DM);
            this.calcParams[InputFB6] = new PIDAlgorithmVar(InputFB6, true, PIDVarDataType.DM);
            this.calcParams[InputFB7] = new PIDAlgorithmVar(InputFB7, true, PIDVarDataType.DM);
            this.calcParams[InputFB8] = new PIDAlgorithmVar(InputFB8, true, PIDVarDataType.DM);
            this.calcParams[InputRst] = new PIDAlgorithmVar(InputRst, true, PIDVarDataType.DM);
            this.calcParams[InputDStep] = new PIDAlgorithmVar(InputDStep, true, PIDVarDataType.DM);
            this.calcParams[InputJStep] = new PIDAlgorithmVar(InputJStep, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultStep] = new PIDAlgorithmVar(ResultStep, false, PIDVarDataType.DM);
            this.calcResults[ResultTrun] = new PIDAlgorithmVar(ResultTrun, false, PIDVarDataType.DM);
            this.calcResults[ResultTrst] = new PIDAlgorithmVar(ResultTrst, false, PIDVarDataType.DM);
            this.calcResults[ResultRun] = new PIDAlgorithmVar(ResultRun, false, PIDVarDataType.DM);
            this.calcResults[ResultFail] = new PIDAlgorithmVar(ResultFail, false, PIDVarDataType.DM);
            this.calcResults[ResultEnd] = new PIDAlgorithmVar(ResultEnd, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP1] = new PIDAlgorithmVar(ResultSTEP1, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP2] = new PIDAlgorithmVar(ResultSTEP2, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP3] = new PIDAlgorithmVar(ResultSTEP3, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP4] = new PIDAlgorithmVar(ResultSTEP4, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP5] = new PIDAlgorithmVar(ResultSTEP5, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP6] = new PIDAlgorithmVar(ResultSTEP6, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP7] = new PIDAlgorithmVar(ResultSTEP7, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP8] = new PIDAlgorithmVar(ResultSTEP8, false, PIDVarDataType.DM);

        } 
           
 
        /// <summary>
        /// 4、功能说明
        ///步序逻辑算法提供了子组级顺控逻辑的标准实现方法。 步序逻辑算法可接受上级顺控逻辑或运行人员的启动指令，并将相应设备置为顺控方式。
        ///步序的执行即是条件触发的，同时，又是时基的。当前步的操作成功(反馈信号到达／ 反馈信号到达，达到设定时间)后，程序自动进行下一步。如出现故障并经一定的时间延迟 仍未消失或达到步序设定时间操作仍未完成，步序逻辑被终止。当顺控逻辑启动后，运行人 员可以在任意时刻人工终止程序，或选择跳步、置步。跳步和置步操作在满足设备安全条件 下才被执行。
        ///每个步序逻辑算法可完成不超过８步的设备自动步序逻辑操作。通过级联多个步序逻辑 运算可实现更复杂的顺序控制逻辑。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double maxs = this.calcParams[ParamMAXS].Value;
            double settime1 = this.calcParams[ParamSetTime1].Value;
            double settime2 = this.calcParams[ParamSetTime2].Value;
            double settime3 = this.calcParams[ParamSetTime3].Value;
            double settime4 = this.calcParams[ParamSetTime4].Value;
            double settime5 = this.calcParams[ParamSetTime5].Value;
            double settime6 = this.calcParams[ParamSetTime6].Value;
            double settime7 = this.calcParams[ParamSetTime7].Value;
            double settime8 = this.calcParams[ParamSetTime8].Value;
            double tlimit1 = this.calcParams[ParamTlimit1].Value;
            double tlimit2 = this.calcParams[ParamTlimit2].Value;
            double tlimit3 = this.calcParams[ParamTlimit3].Value;
            double tlimit4 = this.calcParams[ParamTlimit4].Value;
            double tlimit5 = this.calcParams[ParamTlimit5].Value;
            double tlimit6 = this.calcParams[ParamTlimit6].Value;
            double tlimit7 = this.calcParams[ParamTlimit7].Value;
            double tlimit8 = this.calcParams[ParamTlimit8].Value;
            double tmode = this.calcParams[InputTmode].Value;
            double bitdis = this.calcParams[InputBitDis].Value;
            double start = this.calcParams[InputStart].Value;
            double stop = this.calcParams[InputStop].Value;
            double delay = this.calcParams[InputDelay].Value;
            double fb1 = this.calcParams[InputFB1].Value;
            double fb2 = this.calcParams[InputFB2].Value;
            double fb3 = this.calcParams[InputFB3].Value;
            double fb4 = this.calcParams[InputFB4].Value;
            double fb5 = this.calcParams[InputFB5].Value;
            double fb6 = this.calcParams[InputFB6].Value;
            double fb7 = this.calcParams[InputFB7].Value;
            double fb8 = this.calcParams[InputFB8].Value;
            double rst = this.calcParams[InputRst].Value;
            double dstep = this.calcParams[InputDStep].Value;
            double jstep = this.calcParams[InputJStep].Value;
            //double step = this.calcResults[ResultStep].Value;
            //double trun = this.calcResults[ResultTrun].Value;
            //double trst = this.calcResults[ResultTrst].Value;
            //double run = this.calcResults[ResultRun].Value;
            //double fail = this.calcResults[ResultFail].Value;
            //double end = this.calcResults[ResultEnd].Value;
            //double step1 = this.calcResults[ResultSTEP1].Value;
            //double step2 = this.calcResults[ResultSTEP2].Value;
            //double step3 = this.calcResults[ResultSTEP3].Value;
            //double step4 = this.calcResults[ResultSTEP4].Value;
            //double step5 = this.calcResults[ResultSTEP5].Value;
            //double step6 = this.calcResults[ResultSTEP6].Value;
            //double step7 = this.calcResults[ResultSTEP7].Value;
            //double step8 = this.calcResults[ResultSTEP8].Value;
        }
    }
}