using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.15  设备驱动算法块（DV）DEVICE 　51497
    /// </summary>
    public class PIDDv : PIDBindAlgorithm
    {

        ///<summary>
        /// 输出信号模式，该参数定义了输出Out1、Out2信号的形式。
        ///0—输出指令为定长单脉冲。当相应反馈为真时或STOP信号有效时，信号Reset
        ///1—输出指令为脉冲列。当相应反馈为真时或STOP信号有效时，信号Reset
        ///2—输出指令为长信号，当相应反馈为真时或STOP信号有效时，信号Reset
        ///3—输出指令为长信号。当反方向指令有效时，信号Reset。此方式无操作失败
        ///4—输出指令同0，反馈为真时，信号不Reset
        ///5—输出指令同1，反馈为真时，信号不Reset
        ///6—输出指令同2，反馈为真时，信号不Reset
        ///7—输出指令同3，反馈为真时，信号不Reset
        ///8—输出指令同0，反馈为真时，也能发出信号
        ///9—输出指令同1，反馈为真时，也能发出信号
        ///10—输出指令同2，反馈为真时，也能发出信号
        ///11—输出指令同 3，反馈为真时，也能发出信号
        /// </summary>
        public const string ParamOutM = PIDAlgorithmToken.prefixParam + "OutM";

        ///<summary>
        /// 输出信号定时，该参数定义了输出 Out1、Out2 信号的有效长度(单位为秒)。仅当
        ///输出指令为定长单脉冲和脉冲列时有效。
        /// </summary>
        public const string ParamSetT = PIDAlgorithmToken.prefixParam + "SetT";

        ///<summary>
        /// 输出信号定时，该参数定义了输出 Out1、Out2 信号的占空比(单位为秒)。仅当输
        ///出指令为脉冲列时有效。每个脉冲长度为 SetT，其中 ResT 时间内为 0。当 ResT/为 0 时，ResT=SetT/2
        /// </summary>
        public const string ParamRseT = PIDAlgorithmToken.prefixParam + "RseT";

        ///<summary>
        /// 设备缺省模式，该参数定义了设备从上电、就地、故障或保护、联锁等方式回复后
        ///的缺省模式。0—设备缺省模式为手动模式，1—设备缺省模式为自动模式
        /// </summary>
        public const string ParamMod0 = PIDAlgorithmToken.prefixParam + "Mod0";

        ///<summary>
        /// STOP指令允许及开关指令是否在Stop状态时有效。
        ///0 — 不执行STOP指令  1 — 执行STOP指令
        ///2 — 不执行STOP指令，且当设备处于停止状态时，才能发开关指令
        ///3 — 执行STOP指令，且当设备处于停止状态时，才能发开关指令
        ///4 –  不执行STOP指令，当有反方向指令时，认作STOP指令。
        ///5 - 执行 STOP 指令，当有反方向指令时，认作 STOP 指令。
        /// </summary>
        public const string ParamSTP = PIDAlgorithmToken.prefixParam + "STP";

        ///<summary>
        /// 手动优先级，该参数定义了CRT/键盘的手动指令是否能直接将设备切换到手动模式。
        ///0 — 手动OPEN/CLOSE/STOP指令不能将设备切换到手动模式，但输出指令有效。
        ///1  — 手动OPEN/CLOSE/STOP指令不但能将设备切换到手动模式，且输出指令有 效。
        ///其它 — 手动 OPEN/CLOSE/STOP 指令不能将设备切换到手动模式，且输出指令 无效。
        /// </summary>
        public const string ParamMP = PIDAlgorithmToken.prefixParam + "MP";

        ///<summary>
        /// 故障闭锁定义参数，定义了设备故障信号、跳闸、操作失败是否闭锁输出指令
        /// 0  — 任一信号将闭锁输出指令。
        /// 1  — 任一信号将不闭锁输出指令。
        /// </summary>
        public const string ParamFLB = PIDAlgorithmToken.prefixParam + "FLB";

        ///<summary>
        /// 跳闸置位定义参数，定义了跳闸(保护)输入信号ToTP所关联的输出指令或指定跳闸判断的反馈信号：
        ///0  — 跳闸信号对应的输出为Out2，或当无指令输出而FB2变化时为跳闸(Trip输出)
        ///1  — 跳闸信号对应的输出为Out1，或当无指令输出而FB1变化时为跳闸(Trip输出)
        ///2 — 当无指令输出而FB1或FB2变化时为跳闸(Trip输出)
        /// </summary>
        public const string ParamTout = PIDAlgorithmToken.prefixParam + "Tout";

        ///<summary>
        /// 设备行程时间。当指令发出后，经Tover时间后相应反馈不为1时，操作失败。Tover>=SetT.。
        /// </summary>
        public const string ParamTover = PIDAlgorithmToken.prefixParam + "Tover";

        //--------------------------------------------------1


        ///<summary>
        /// 超驰(联锁)开指令。只要该超驰指令为 1 时，无论设备处于手动或自动模式，允
        ///许条件是否满足，都将输出指令 Out1，闭锁与其相反的其它指令，并将设备切到 缺省模式。
        ///当该指令保持为 1 时，顺控及手动的反方向指令无效。但是可以进行手 自动模式切换。
        /// </summary>
        public const string InputOvr1 = PIDAlgorithmToken.prefixInput + "Ovr1";

        ///<summary>
        /// 注：Ovr1,Ovr2 指令，或操作失败信号 OPFL 出现之后，只切一次缺省方式，而非闭锁为缺省方式。
        /// </summary>
        public const string InputOvr2 = PIDAlgorithmToken.prefixInput + "Ovr2";

        ///<summary>
        /// 该允许信号为 1 时，顺控及手动的开指令 Out1 才有效
        /// </summary>
        public const string InputS1p = PIDAlgorithmToken.prefixInput + "S1p";

        ///<summary>
        /// 该允许信号为 1 时，顺控及手动的关指令 Out2 才有效
        /// </summary>
        public const string InputS2p = PIDAlgorithmToken.prefixInput + "S2p";

        ///<summary>
        /// 强制手动，当该信号由为 1 时，且无就地、保护及联锁条件时，算法为强制手动方式
        /// </summary>
        public const string InputToM = PIDAlgorithmToken.prefixParam + "ToM";

        ///<summary>
        /// 自动请求，当自动请求由 0 变为 1 并且强制手动不为 1 时，算法切为自动方式
        /// </summary>
        public const string InputReqA = PIDAlgorithmToken.prefixInput + "ReqA";

        ///<summary>
        /// 当设备处于自动(顺控)状态，并满足对应的允许条件时，该信号将作用于相对应
        ///的输出Out1,Out2,或Out3。(电平作用内部处理) 注：在故障 ACK 后，如处于自动状态，将继续自动输出。
        /// </summary>
        public const string InputDmd1 = PIDAlgorithmToken.prefixInput + "Dmd1";
        public const string InputDmd2 = PIDAlgorithmToken.prefixInput + "Dmd2";
        public const string InputDmd3 = PIDAlgorithmToken.prefixInput + "Dmd3";

        ///<summary>
        /// 与输出 Out1，Out2 相对应的设备运行状态反馈信号
        /// </summary>
        public const string InputFB1 = PIDAlgorithmToken.prefixInput + "FB1";

        public const string InputFB2 = PIDAlgorithmToken.prefixInput + "FB2";
        ///<summary>
        /// 设备处于就地状态。优先级最高，设备输出均被禁止，并切到缺省模式，任何输入均无效。
        /// </summary>
        public const string InputFB3 = PIDAlgorithmToken.prefixInput + "FB3";

        ///<summary>
        /// 跳闸(保护)输入信号。当该信号为1时，由参数Tout指定的输出值；任何反方向 输出均被禁止，并将设备切到缺省模式。优先级仅次于就地。
        /// </summary>
        public const string InputToTP = PIDAlgorithmToken.prefixInput + "ToTP";

        //--------------------------------------------------1
        ///<summary>
        /// 开指令输出
        /// </summary>
        public const string ResultOut1 = PIDAlgorithmToken.prefixResult + "Out1";

        ///<summary>
        /// 关指令输出
        /// </summary>
        public const string ResultOut2 = PIDAlgorithmToken.prefixResult + "Out2";

        ///<summary>
        /// 停指令输出
        /// </summary>
        public const string ResultOut3 = PIDAlgorithmToken.prefixResult + "Out3";

        ///<summary>
        /// 手动指示，当算法为手动方式时输出为 1，此时输出除就地或者超驰外，由 ToOpen，ToClose，ToStop 决定。
        /// </summary>
        public const string ResultM = PIDAlgorithmToken.prefixResult + "M";

        ///<summary>
        /// 自动指示，当算法为自动方式时输出为 1，此时除就地或超驰外，由 Dmd1，Dmd2，Dmd3 决定。
        /// </summary>
        public const string ResultA = PIDAlgorithmToken.prefixResult + "A";

        ///<summary>
        /// 设备状态，当 FB1 为 1 时置 1，当 FB2 为 1 时置 0。
        /// </summary>
        public const string ResultStat = PIDAlgorithmToken.prefixResult + "Stat";

        ///<summary>
        /// 设备故障，当 FB1、FB2 同为 1 时置 1，否则为 0。
        /// </summary>
        public const string ResultFL = PIDAlgorithmToken.prefixResult + "FL";

        ///<summary>
        /// 跳闸显示，当无任何指令发出且设备并不处于就地，而指定的设备运行状态反馈信号
        ///(通常为 FB2)却发生变化时，该信号置 1，此时顺控及手动操作均被禁止；揿下 CRT/ 键盘的确认键即复位为 0。
        /// </summary>
        public const string ResultTrip = PIDAlgorithmToken.prefixResult + "Trip";

        ///<summary>
        /// 操作失败，当输出指令(脉宽由参数 SetT 定义)发出后，延时一段时间(设备行程时间，
        ///由参数 Tover 定义，Tover>=SetT。如 Tover小于SetT，则 Tover=SetT;如为脉冲列输出，
        ///且 Tover=0 时，Tover=5)仍未收到对应的反馈信号，即认为操作失败。该信号置 1。 此时顺控及手动操作均被禁止；揿下 CRT/键盘的确认键即复位为 0。
        /// </summary>
        public const string ResultOpFL = PIDAlgorithmToken.prefixResult + "OpFL";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamOutM] = new PIDAlgorithmVar(ParamOutM, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetT] = new PIDAlgorithmVar(ParamSetT, false, PIDVarDataType.Unknown);
            this.calcParams[ParamRseT] = new PIDAlgorithmVar(ParamRseT, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMod0] = new PIDAlgorithmVar(ParamMod0, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSTP] = new PIDAlgorithmVar(ParamSTP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMP] = new PIDAlgorithmVar(ParamMP, false, PIDVarDataType.Unknown);
            this.calcParams[ParamFLB] = new PIDAlgorithmVar(ParamFLB, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTout] = new PIDAlgorithmVar(ParamTout, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTover] = new PIDAlgorithmVar(ParamTover, false, PIDVarDataType.Unknown);
            this.calcParams[InputOvr1] = new PIDAlgorithmVar(InputOvr1, true, PIDVarDataType.DM);
            this.calcParams[InputOvr2] = new PIDAlgorithmVar(InputOvr2, true, PIDVarDataType.DM);
            this.calcParams[InputS1p] = new PIDAlgorithmVar(InputS1p, true, PIDVarDataType.DM);
            this.calcParams[InputS2p] = new PIDAlgorithmVar(InputS2p, true, PIDVarDataType.DM);
            this.calcParams[InputToM] = new PIDAlgorithmVar(InputToM, false, PIDVarDataType.Unknown);
            this.calcParams[InputReqA] = new PIDAlgorithmVar(InputReqA, true, PIDVarDataType.DM);
            this.calcParams[InputDmd1] = new PIDAlgorithmVar(InputDmd1, true, PIDVarDataType.DM);
            this.calcParams[InputDmd2] = new PIDAlgorithmVar(InputDmd2, true, PIDVarDataType.DM);
            this.calcParams[InputDmd3] = new PIDAlgorithmVar(InputDmd3, true, PIDVarDataType.DM);
            this.calcParams[InputFB1] = new PIDAlgorithmVar(InputFB1, true, PIDVarDataType.DM);
            this.calcParams[InputFB2] = new PIDAlgorithmVar(InputFB2, true, PIDVarDataType.DM);
            this.calcParams[InputFB3] = new PIDAlgorithmVar(InputFB3, true, PIDVarDataType.DM);
            this.calcParams[InputToTP] = new PIDAlgorithmVar(InputToTP, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultOut1] = new PIDAlgorithmVar(ResultOut1, false, PIDVarDataType.DM);
            this.calcResults[ResultOut2] = new PIDAlgorithmVar(ResultOut2, false, PIDVarDataType.DM);
            this.calcResults[ResultOut3] = new PIDAlgorithmVar(ResultOut3, false, PIDVarDataType.DM);
            this.calcResults[ResultM] = new PIDAlgorithmVar(ResultM, false, PIDVarDataType.DM);
            this.calcResults[ResultA] = new PIDAlgorithmVar(ResultA, false, PIDVarDataType.DM);
            this.calcResults[ResultStat] = new PIDAlgorithmVar(ResultStat, false, PIDVarDataType.DM);
            this.calcResults[ResultFL] = new PIDAlgorithmVar(ResultFL, false, PIDVarDataType.DM);
            this.calcResults[ResultTrip] = new PIDAlgorithmVar(ResultTrip, false, PIDVarDataType.DM);
            this.calcResults[ResultOpFL] = new PIDAlgorithmVar(ResultOpFL, false, PIDVarDataType.DM);

        }

        /// <summary>
        ///4、功能说明
        ///工作方式有三种：0—自动、1—PV1、2—PV2、3—PV3。 自动时输出方式有三种：0—平均值、1—最大值、2—最小值、3—中间值、4—PV1、5
        ///—PV2、6—PV3。
        ///?	当工作方式在自动时：
        ///1)   如果三个输入点都是坏点，则输出为坏点，输出保持不变。变送器报警信号 ALM
        ///为真，变送器切手动信号 MRE 为真。
        ///2)   如果三个输入中有两个是坏点，则输出等于另一个好点的值。变送器报警信号 ALM
        ///为真。
        ///3)   如果三个输入中有一个是坏点，则按二变送器整合算法块的原理工作。
        ///4)   如果三个输入都是好点，并且处于自动工作状态下
        ///a. 如果三者偏差中两两越限，即均超过 Range，则输出为安全值 SaftV，变送器报警 信号 ALM 为真，变送器切手动信号 MRE 为真。
        ///b. 如果三者偏差中某个输入(假设为 A 路)与另两路之间(假设为 B 路和 C 路)偏 差都越限(超过 Range)，而这两路之间偏差不越限，则输出取这两路(即前面假 设的 B 路和 C 路)的平均值。
        ///c. 如果三者之间的偏差都没有超过 Range，那么根据指定的方式输出。
        ///?	当在工作方式中指定了 PV1 或者 PV2 或者 PV3 为输出时： 只有当指定的输入为好点时，本算法块才会按照用户的指定输出，否则自动切换到自动
        ///工作状态。 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double outm =  this.calcParams[ParamOutM].Value;
            double sett =  this.calcParams[ParamSetT].Value;
            double rset =  this.calcParams[ParamRseT].Value;
            double mod0 =  this.calcParams[ParamMod0].Value;
            double stp =  this.calcParams[ParamSTP].Value;
            double mp =  this.calcParams[ParamMP].Value;
            double flb =  this.calcParams[ParamFLB].Value;
            double tout =  this.calcParams[ParamTout].Value;
            double tover =  this.calcParams[ParamTover].Value;
            double ovr1 =  this.calcParams[InputOvr1].Value;
            double ovr2 =  this.calcParams[InputOvr2].Value;
            double s1p =  this.calcParams[InputS1p].Value;
            double s2p =  this.calcParams[InputS2p].Value;
            double tom =  this.calcParams[InputToM].Value;
            double reqa =  this.calcParams[InputReqA].Value;
            double dmd1 =  this.calcParams[InputDmd1].Value;
            double fb1 =  this.calcParams[InputFB1].Value;
            double fb3 =  this.calcParams[InputFB3].Value;
            double totp =  this.calcParams[InputToTP].Value;
            //double out1 =  this.calcResults[ResultOut1].Value;
            //double out2 =  this.calcResults[ResultOut2].Value;
            //double out3 =  this.calcResults[ResultOut3].Value;
            //double m =  this.calcResults[ResultM].Value;
            //double a =  this.calcResults[ResultA].Value;
            //double stat =  this.calcResults[ResultStat].Value;
            //double fl =  this.calcResults[ResultFL].Value;
            //double trip =  this.calcResults[ResultTrip].Value;
            //double opfl =  this.calcResults[ResultOpFL].Value;

        }
        
    }
}