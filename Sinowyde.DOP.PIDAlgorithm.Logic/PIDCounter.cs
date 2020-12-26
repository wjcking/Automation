using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 脉冲信号 上升 下降
    /// </summary>
    public enum PulseSignal : short
    {
        Up = 1,
        Down = 2,
        Normal = 3
    }

    /// <summary>
    /// 计数器算法块
    /// </summary>
    [Serializable]
    public class PIDCounter : PIDBindAlgorithm
    {
        #region 变量

        /// <summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        /// <summary>
        /// 复位输入
        /// </summary>
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        /// <summary>
        /// 时钟输入触发边界选择
        /// </summary>
        public const string ParamSense = PIDAlgorithmToken.prefixParam + "Sense";

        /// <summary>
        /// 最大计数次数设定值
        /// </summary>
        public const string ParamMaxVal = PIDAlgorithmToken.prefixParam + "SetVal";

        /// <summary>
        /// 选择计数器计数方向
        /// </summary>
        public const string ParamUpCount = PIDAlgorithmToken.prefixParam + "UpCount";

        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        private double lastInputDI1 = 1;
        private double lastResultAO = 0;
        private double lastResultDO = 0;

        #endregion

        /// <summary>
        /// 初始次数
        /// </summary>
        public const string ResultVal = PIDAlgorithmToken.prefixResult + "Val";

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamSense] = new PIDAlgorithmParam(ParamSense, (double)PulseSignal.Up);
            this.calcParams[ParamMaxVal] = new PIDAlgorithmParam(ParamMaxVal);
            this.calcParams[ParamUpCount] = new PIDAlgorithmParam(ParamUpCount, 1); // bool类型
        }


        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
            calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }
        /// <summary>
        ///   4、功能说明
        ///COUNT 模块能统计 DI1 端的脉冲输入，时钟触发边界可以是上升沿、下降沿或者任意
        ///沿，统计总数作为模拟量输出 AO。
        ///5、算法说明
        ///计数器由 UpCount 参数，可设置为一个增计数器或减计数器。
        ///当设置为增计数器，即 UpCount＞0 时， 输入脉冲不断增加计数总数，直到它达到 SetVal
        ///参数所定的“终值”，并且 DO 输出由 0 变 1，然后从零开始重新计数。
        ///当设置为减计数器，即 UpCount＜0 时，输入脉冲不断减少计数的总数，直到达到“终
        ///值”，此时为 0，并且 DO 输出由 0 变 1。在下一个触发脉冲到来时， AO 返回“初始值”SetVal。
        ///同时，本模块提供复位功能。当复位输入 DI2 为 1 时， AO 清零， DO 置 0。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            PulseSignal sense = (PulseSignal)this.calcParams[ParamSense].Value;
            bool upcount = this.calcParams[ParamUpCount].Value > 0;
            int setVal = (int)this.calcParams[ParamMaxVal].Value;
            double di1 = calcInputs[InputDI1].Value;
            double di2 = calcInputs[InputDI2].Value;

            if (GetDt() == 0)
            {
                lastResultAO = upcount ? 0 : setVal;
            }

            if (di2>0)
            {
                this.calcResults[ResultAO].Value = 0;
                this.calcResults[ResultDO].Value = 0;
                lastResultAO = upcount ? 0 : setVal;
            }
            else 
            {
                if (upcount)
                {
                    //正向
                    if (sense == PulseSignal.Up && di1 > lastInputDI1)
                    {
                        if (lastResultAO >= setVal)
                        {
                            this.calcResults[ResultDO].Value = 1;
                            this.calcResults[ResultAO].Value = lastResultAO;
                        }
                        else
                        {
                            lastResultAO++;
                            this.calcResults[ResultAO].Value = lastResultAO;
                            if (lastResultAO == setVal)
                            {
                                this.calcResults[ResultDO].Value = 1;
                            }
                        }
                    }
                    else if (sense == PulseSignal.Down && di1 < lastInputDI1)
                    {

                        if (lastResultAO >= setVal)
                        {
                            this.calcResults[ResultDO].Value = 1;
                            this.calcResults[ResultAO].Value = lastResultAO;
                        }
                        else
                        {
                            lastResultAO++;
                            this.calcResults[ResultAO].Value = lastResultAO;
                            if (lastResultAO == setVal)
                            {
                                this.calcResults[ResultDO].Value = 1;
                            }
                        }
                    }
                    else if (sense == PulseSignal.Normal && !di1.Equals(lastInputDI1))
                    {

                        if (lastResultAO >= setVal)
                        {
                            this.calcResults[ResultDO].Value = 1;
                            this.calcResults[ResultAO].Value = lastResultAO;
                        }
                        else
                        {
                            lastResultAO++;
                            this.calcResults[ResultAO].Value = lastResultAO;
                            if (lastResultAO == setVal)
                            {
                                this.calcResults[ResultDO].Value = 1;
                            }
                        }
                    }
                    else
                    {
                        this.calcResults[ResultAO].Value = lastResultAO;
                    }
                }
                else 
                {
                    //逆向
                    if (sense == PulseSignal.Up && di1 > lastInputDI1)
                    {

                        if (lastResultAO <= 0)
                        {
                            this.calcResults[ResultDO].Value = 1;
                            this.calcResults[ResultAO].Value = lastResultAO;
                        }
                        else
                        {
                            lastResultAO--;
                            this.calcResults[ResultAO].Value = lastResultAO;
                            if (lastResultAO == 0)
                            {
                                this.calcResults[ResultDO].Value = 1;
                            }
                        }
                    }
                    else if (sense == PulseSignal.Down && di1 < lastInputDI1)
                    {

                        if (lastResultAO <= 0)
                        {
                            this.calcResults[ResultDO].Value = 1;
                            this.calcResults[ResultAO].Value = lastResultAO;
                        }
                        else
                        {
                            lastResultAO--;
                            this.calcResults[ResultAO].Value = lastResultAO;
                            if (lastResultAO == 0)
                            {
                                this.calcResults[ResultDO].Value = 1;
                            }
                        }
                    }
                    else if (sense == PulseSignal.Normal && !di1.Equals(lastInputDI1))
                    {

                        if (lastResultAO <= 0)
                        {
                            this.calcResults[ResultDO].Value = 1;
                            this.calcResults[ResultAO].Value = lastResultAO;
                        }
                        else
                        {
                            lastResultAO--;
                            this.calcResults[ResultAO].Value = lastResultAO;
                            if (lastResultAO == 0)
                            {
                                this.calcResults[ResultDO].Value = 1;
                            }
                        }
                    }
                    else
                    {
                        this.calcResults[ResultAO].Value = lastResultAO;
                    }
                }
            }
            lastInputDI1 = this.calcInputs[InputDI1].Value;
            
        }

        #endregion

        public override string AlgName
        {
            get { return "计数器算法块"; }
        }
    }
}
