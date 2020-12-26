using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 数字给定值发生器算法块（DSETPOINT）
    /// </summary>
    [Serializable]
    public class PIDDsetpoint : PIDBindAlgorithm
    {
        ///<summary>
        /// 设定工作方式
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";

        ///<summary>
        /// 使能端
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";

        ///<summary>
        /// 按钮动作，是否按下
        /// </summary>
        public const string InputBtn = PIDAlgorithmToken.prefixInput + "BtnAction";

        ///<summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputBtn] = new PIDAlgorithmVar(InputBtn, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        ///4、功能说明
        ///当使能端输入 DI 为零的时候，操作员无法进行手动改变给定值的操作。 当 DI=1 时，
        ///•若工作方式为脉冲，则当在操作员界面点击按钮发出命令时，输出宽度为一个运算 周期的脉冲。
        ///•若工作方式为翻转，则当在操作员界面点击按钮发出命令时，输出变成上一次输出 的相反值(0→1 或 1→0)。
        ///•若工作方式为长脉冲，则当在操作员界面发出命令时，如果按住按钮时，发出指令
        ///1；松开按钮时，发出指令为 0。
        ///5、算法说明
        ///注意：此模块的工作方式不能在线修改。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            if (this.calcInputs[InputDI].ValueToBool())
            {
                int mode = ConvertUtil.ConvertToInt(this.GetParam(ParamMODE).Value);
                if (this.calcInputs[InputBtn].ValueToBool())
                {
                    if (mode == (int)DsetPulseStyle.Pulse)
                    {
                        this.calcResults[ResultDO].Value = 1;
                        this.calcResults[ResultDO].SourceValue = 0;
                        this.calcInputs[InputBtn].Value = 0;
                        this.calcInputs[InputBtn].SourceValue = 0;
                    }
                    else if (mode == (int)DsetPulseStyle.UpDown)
                    {
                        this.calcResults[ResultDO].Value = 1-this.calcResults[ResultDO].Value;
                        this.calcResults[ResultDO].SourceValue = this.calcResults[ResultDO].Value;
                        this.calcInputs[InputBtn].Value = 0;
                        this.calcInputs[InputBtn].SourceValue = 0;
                    }
                    else
                    {
                        this.calcResults[ResultDO].Value = 1;
                        this.calcResults[ResultDO].SourceValue = 1;
                    }
                }
                else
                {
                    if(mode == (int)DsetPulseStyle.LongSignal)
                    {
                        this.calcResults[ResultDO].Value = 0;
                    }
                    else
                    {
                        this.calcResults[ResultDO].Value = this.calcResults[ResultDO].SourceValue;
                    }
                }
            }
            else
            {
                this.calcResults[ResultDO].Value = this.calcResults[ResultDO].SourceValue;
            }
        }

        public override string GetBindVarNumber()
        {
            return GetBindParam(PIDDsetpoint.ResultDO);
        }

        public override string AlgName
        {
            get { return "数字给定值发生器算法块"; }
        }
    }
}