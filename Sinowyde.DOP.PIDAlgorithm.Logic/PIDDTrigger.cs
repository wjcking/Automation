using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 时钟触发边界{改中文}
    /// </summary>
    public enum TimerSenseType
    {
        Up = 1,
        Down = 2,
        Any = 3
    }

    /// <summary>
    /// D触发器算法块
    /// </summary>
    [Serializable]
    public class PIDDTrigger : PIDBindAlgorithm
    {
        #region 变量

        /// <summary>
        /// 时钟输入触发边界选择
        /// </summary>
        public const string ParamSense = PIDAlgorithmToken.prefixParam + "Sense";

        /// <summary>
        /// 重置输入
        /// </summary>
        public const string InputSD = PIDAlgorithmToken.prefixInput + "Sd";
        /// <summary>
        /// 预置输入
        /// </summary>
        public const string InputRD = PIDAlgorithmToken.prefixInput + "Rd";
        /// <summary>
        /// 时钟输入
        /// </summary>
        public const string InputCP = PIDAlgorithmToken.prefixInput + "Cp";
        /// <summary>
        /// 数字输入
        /// </summary>
        public const string InputD = PIDAlgorithmToken.prefixInput + "D";

        ///<summary>
        ///输出值
        ///</summary>
        public const string Result = PIDAlgorithmToken.prefixResult + "Q";

        private double lastInputCP = 1;
        private double lastResultQ = 1;

        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputSD] = new PIDAlgorithmVar(InputSD, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputRD] = new PIDAlgorithmVar(InputRD, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputD] = new PIDAlgorithmVar(InputD, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputCP] = new PIDAlgorithmVar(InputCP, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamSense] = new PIDAlgorithmParam(ParamSense, (double)TimerSenseType.Up);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            calcResults[Result] = new PIDAlgorithmVar(Result, PIDVarDataType.DM);
        }

        /// <summary>
        ///4、功能说明
        ///该算法完成常规作用的 D 型触发器运算。
        ///5、算法说明
        ///带一个时钟输入，可设定控制上升、下降或任意沿的触发动作（由 Sense 参数确定）。
        ///CP 输入设定输出 Q 等于输入 D，除非 Sd 或 Rd 动作。 Sd 强迫 Q 为 False（即 0）；如果 Sd
        ///为 False， Rd 强迫 Q 为 True（即 1）。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double sd = this.calcInputs[InputSD].Value;
            double rd = this.calcInputs[InputRD].Value;
            double cp = this.calcInputs[InputCP].Value;
            double d = this.calcInputs[InputD].Value;

            TimerSenseType sense = (TimerSenseType)this.calcParams[ParamSense].Value;

            #region 暂时放弃
            //第一次计算
            //if (GetDt() == 0)
            //{
            //    this.calcResults[Result].Value = 0;
            //}
            //else
            //{
            //    if (rd == 1)
            //    {
            //        this.calcResults[Result].Value = 0;
            //    }
            //    else
            //    {
            //        if (sd == 1)
            //        {
            //            this.calcResults[Result].Value = 1;
            //        }
            //        else
            //        {

            //            switch (sense)
            //            {
            //                case TimerSenseType.Up:
            //                    if (cp == 1)
            //                    {
            //                        this.calcResults[Result].Value = d;
            //                    }
            //                    else
            //                    {
            //                    }
            //                    break;
            //                case TimerSenseType.Down:
            //                    if (cp == 0)
            //                    {
            //                        this.calcResults[Result].Value = d;
            //                    }
            //                    else
            //                    {
            //                    }
            //                    break;
            //                default:
            //                    this.calcResults[Result].Value = d;
            //                    break;
            //            }



            //        }
            //    }
            //}
            #endregion

            if (rd == 1)
            {
                this.calcResults[Result].Value = 0;
            }
            else
            {
                if (sd == 1)
                {
                    this.calcResults[Result].Value = 1;
                }
                else
                {
                    if (!lastInputCP.Equals(cp))
                    {
                        if (sense.Equals(TimerSenseType.Up) && cp > lastInputCP)
                        {
                            this.calcResults[Result].Value = d;
                        }
                        else if (sense.Equals(TimerSenseType.Down) && cp < lastInputCP)
                        {
                            this.calcResults[Result].Value = d;
                        }
                        else if (sense.Equals(TimerSenseType.Any))
                        {
                            this.calcResults[Result].Value = d;
                        }
                    }
                }
            }
            lastInputCP = this.calcInputs[InputCP].Value;
            lastResultQ = this.calcResults[Result].Value;
        }

        #endregion

        public override string AlgName
        {
            get { return "D触发器算法块"; }
        }
    }
}
