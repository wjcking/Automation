using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 2 输入平衡算法块（2IB）2 INPUT BALANCE09e60
    /// </summary>
    public class PID2ib : PIDBindAlgorithm
    {
        ///<summary>
        /// 输出高限
        /// </summary>
        public const string ParamYH = PIDAlgorithmToken.prefixParam + "YH";

        ///<summary>
        /// 输出低限
        /// </summary>
        public const string ParamYL = PIDAlgorithmToken.prefixParam + "YL";

        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputX = PIDAlgorithmToken.prefixInput + "X";

        ///<summary>
        /// 跟踪信号
        /// </summary>
        public const string InputTR1 = PIDAlgorithmToken.prefixInput + "TR1";
        public const string InputTR2 = PIDAlgorithmToken.prefixInput + "TR2";

        ///<summary>
        /// 跟踪开关
        /// </summary>
        public const string InputTS1= PIDAlgorithmToken.prefixInput + "TS1";
        public const string InputTS2 = PIDAlgorithmToken.prefixInput + "TS2";

        ///<summary>
        /// 模拟量输出 1
        /// </summary>
        public const string ResultY1 = PIDAlgorithmToken.prefixResult + "Y1";

        ///<summary>
        /// 模拟量输出 2
        /// </summary>
        public const string ResultY2 = PIDAlgorithmToken.prefixResult + "Y2";


        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamYH] = new PIDAlgorithmVar(ParamYH, false, PIDVarDataType.Unknown);
            this.calcParams[ParamYL] = new PIDAlgorithmVar(ParamYL, false, PIDVarDataType.Unknown);
            this.calcParams[InputX] = new PIDAlgorithmVar(InputX, true, PIDVarDataType.DM);
            this.calcParams[InputTR1] = new PIDAlgorithmVar(InputTR1, true, PIDVarDataType.DM);
            this.calcParams[InputTR2] = new PIDAlgorithmVar(InputTR2, true, PIDVarDataType.DM);
            this.calcParams[InputTS1] = new PIDAlgorithmVar(InputTS1, true, PIDVarDataType.DM);
            this.calcParams[InputTS2] = new PIDAlgorithmVar(InputTS2, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultY1] = new PIDAlgorithmVar(ResultY1, false, PIDVarDataType.DM);
            this.calcResults[ResultY2] = new PIDAlgorithmVar(ResultY2, false, PIDVarDataType.DM);

        }

        /// <summary>
        ///4、功能说明
        ///本算法块适用于某个控制作用需要同时控制两套同样设备(如发出甲、乙侧引风机液偶 指令)的场合。
        ///5、算法说明
        ///下面根据跟踪信号 TS1、TS2 的不同，分四种情形进行讨论： 1)TS1=1，TS2=1(即两路全处于跟踪状态) 此时输出为：Y1=TR1	Y2=TR2
        ///2)TS1=0(1 路处于自动)，TS2=1(2 路处于跟踪) 
        /// 此时输出为：Y2=TR2	Y1=2X－Y2 3)TS1=1(1 路处于跟踪)，
        /// TS2=0(2 路处于自动) 此时输出为：Y1=TR1	Y2=2X－Y1 4)TS1=0，TS2=0(即两路全处于自动状态) 此时输出为：Y1=X+BIAS   Y2=X－BIAS
        ///模拟量输出 Y1 和 Y2，如果大于输出上限 YH 或者小于输出下限 YL，本算法块就相应 的进行限幅处理。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double yh = this.calcParams[ParamYH].Value;
            double yl = this.calcParams[ParamYL].Value;
            double x = this.calcParams[InputX].Value;
            double tr1 = this.calcParams[InputTR1].Value;
            double tr2 = this.calcParams[InputTR2].Value;
            double ts1 = this.calcParams[InputTS1].Value;
            double ts2 = this.calcParams[InputTS2].Value;
            double y1 = this.calcResults[ResultY1].Value;
            double y2 = this.calcResults[ResultY2].Value;
        } 
    }
}