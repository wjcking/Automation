using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 偏差报警算法块
    /// </summary>
    [Serializable]
    public class PIDAlarm : PIDBindAlgorithm
    {
        #region 变量

        /// <summary>
        /// 正偏差限
        /// </summary>
        public const string ParamHL = PIDAlgorithmToken.prefixParam + "HL";
        /// <summary>
        /// 负偏差限
        /// </summary>
        public const string ParamLL = PIDAlgorithmToken.prefixParam + "LL";
        /// <summary>
        /// 不灵敏带
        /// </summary>
        public const string ParamBD = PIDAlgorithmToken.prefixParam + "BD";

        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";

        /// <summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region Abstract class PIDAlgorithm
        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHL] = new PIDAlgorithmParam(ParamHL);
            this.calcParams[ParamLL] = new PIDAlgorithmParam(ParamLL);
            this.calcParams[ParamBD] = new PIDAlgorithmParam(ParamBD);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        /// 4、功能说明
        ///ALARM 模块比较两个模拟输入，执行逻辑比较功能，输出比较的逻辑结果。
        ///5、算法说明
        /// 当 AI1-AI2≥HL 或者 AI1-AI2≤LL 时，输出量 DO=1
        /// 若 DO=1，且 HL-BD＜AI1-AI2＜HL 的时候
        ///DO 保持不变
        /// 当 LL＜AI1-AI2＜LL+BD 的时候
        /// DO 保持不变
        /// 其他情况下，
        /// DO=0
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double hl = calcParams[ParamHL].Value;
            double ll = calcParams[ParamLL].Value;
            double bd = calcParams[ParamBD].Value;

            double ai1 = calcInputs[InputAI1].Value;
            double ai2 = calcInputs[InputAI2].Value;

            //bool last = calcResults[ResultDO].ValueToBool();

            double diff = ai1 - ai2;

            //wangyahui modified
            if (diff >= hl || diff <= ll)
            {
                this.calcResults[ResultDO].Value = 1;
            }
            else
            {
                if (((hl - bd) < diff) || (diff < (ll + bd)))
                {
                    if (this.calcResults.ContainsKey(ResultDO))
                        return;
                }

                this.calcResults[ResultDO].Value = 0;
            }
        }

        #endregion

        public override string AlgName
        {
            get { return "偏差报警算法块"; }
        }
    }
}
