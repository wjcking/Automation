using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.14  三变送器整合算法块（3SI）TRANS35f57a
    /// </summary>
    public class PID3si : PIDBindAlgorithm
    {

        ///<summary>
        /// 工作方式选择
        /// </summary>
        public const string ParamMode = PIDAlgorithmToken.prefixParam + "Mode";

        ///<summary>
        /// 输出方式选择
        /// </summary>
        public const string ParamOutMode = PIDAlgorithmToken.prefixParam + "OutMode";

        ///<summary>
        /// 报警偏差
        /// </summary>
        public const string ParamRange = PIDAlgorithmToken.prefixParam + "Range";

        ///<summary>
        /// 偏差报警死区
        /// </summary>
        public const string ParamDead = PIDAlgorithmToken.prefixParam + "Dead";

        ///<summary>
        /// 输出安全值
        /// </summary>
        public const string ParamSaftV = PIDAlgorithmToken.prefixParam + "SaftV";

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputPV1 = PIDAlgorithmToken.prefixInput + "PV1";

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputPV2 = PIDAlgorithmToken.prefixInput + "PV2";

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputPV3 = PIDAlgorithmToken.prefixInput + "PV3";

        ///<summary>
        /// 模拟量输出
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        ///<summary>
        /// 变送器报警信号
        /// </summary>
        public const string ResultALM = PIDAlgorithmToken.prefixResult + "ALM";

        ///<summary>
        /// 变送器故障切手动信号
        /// </summary>
        public const string ResultMRE = PIDAlgorithmToken.prefixResult + "MRE";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMode] = new PIDAlgorithmVar(ParamMode, false, PIDVarDataType.Unknown);
            this.calcParams[ParamOutMode] = new PIDAlgorithmVar(ParamOutMode, false, PIDVarDataType.Unknown);
            this.calcParams[ParamRange] = new PIDAlgorithmVar(ParamRange, false, PIDVarDataType.Unknown);
            this.calcParams[ParamDead] = new PIDAlgorithmVar(ParamDead, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSaftV] = new PIDAlgorithmVar(ParamSaftV, false, PIDVarDataType.Unknown);
            this.calcParams[InputPV1] = new PIDAlgorithmVar(InputPV1, true, PIDVarDataType.DM);
            this.calcParams[InputPV2] = new PIDAlgorithmVar(InputPV2, true, PIDVarDataType.DM);
            this.calcParams[InputPV3] = new PIDAlgorithmVar(InputPV3, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, false, PIDVarDataType.DM);
            this.calcResults[ResultALM] = new PIDAlgorithmVar(ResultALM, false, PIDVarDataType.DM);
            this.calcResults[ResultMRE] = new PIDAlgorithmVar(ResultMRE, false, PIDVarDataType.DM);

        }

        ///<summary>
        ///4、功能说明 
        ///工作方式有三种：0—自动、1—PV1、2—PV2、3—PV3。 自动时输出方式有三种：0—平均值、1—最大值、2—最小值、3—中间值、4—PV1、5
        ///—PV2、6—PV3。
        ///•	当工作方式在自动时：
        ///1)   如果三个输入点都是坏点，则输出为坏点，输出保持不变。变送器报警信号 ALM
        ///为真，变送器切手动信号 MRE 为真。
        ///2)   如果三个输入中有两个是坏点，则输出等于另一个好点的值。变送器报警信号 ALM
        ///为真。
        ///3)   如果三个输入中有一个是坏点，则按二变送器整合算法块的原理工作。
        ///4)   如果三个输入都是好点，并且处于自动工作状态下
        ///a. 如果三者偏差中两两越限，即均超过 Range，则输出为安全值 SaftV，变送器报警 信号 ALM 为真，变送器切手动信号 MRE 为真。
        ///b. 如果三者偏差中某个输入(假设为 A 路)与另两路之间(假设为 B 路和 C 路)偏 差都越限(超过 Range)，而这两路之间偏差不越限，则输出取这两路(即前面假 设的 B 路和 C 路)的平均值。
        ///c. 如果三者之间的偏差都没有超过 Range，那么根据指定的方式输出。
        ///•	当在工作方式中指定了 PV1 或者 PV2 或者 PV3 为输出时： 
        ///只有当指定的输入为好点时，本算法块才会按照用户的指定输出，否则自动切换到自动
        ///工作状态。
        ///</summary>  
        protected override void InternalDoCalc()
        {
            double mode = this.calcParams[ParamMode].Value;
            double outmode = this.calcParams[ParamOutMode].Value;
            double range = this.calcParams[ParamRange].Value;
            double dead = this.calcParams[ParamDead].Value;
            double saftv = this.calcParams[ParamSaftV].Value;
            double pv1 = this.calcParams[InputPV1].Value;
            double pv2 = this.calcParams[InputPV2].Value;
            double pv3 = this.calcParams[InputPV3].Value;
            double ao = this.calcResults[ResultAO].Value;
            double alm = this.calcResults[ResultALM].Value;
            double mre = this.calcResults[ResultMRE].Value;

        }
    
        
    }
}