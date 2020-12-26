using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// RS触发器算法块
    /// </summary>
    [Serializable]
    public class PIDRSTrigger : PIDBindAlgorithm
    {
        #region

        /// <summary>
        ///复位输入
        /// </summary>
        public const string InputRd = PIDAlgorithmToken.prefixInput + "Rd";
        /// <summary>
        ///置位输入
        /// </summary>
        public const string InputSd = PIDAlgorithmToken.prefixInput + "Sd";

        private double lastValueQ = 0;

        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultQ = PIDAlgorithmToken.prefixResult + "Q";
        
        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 该算法完成常规作用的 RS 型触发器功能。注： Q(n-1)为 Q 前一时刻输出。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            var rd = ConvertUtil.ConvertToBool(calcInputs[InputRd].Value);
            var sd = ConvertUtil.ConvertToBool(calcInputs[InputSd].Value);

            if (rd.Equals(false))
            {
                if (sd.Equals(false))
                {
                    calcResults[ResultQ].Value = lastValueQ;
                }
                else
                {
                    calcResults[ResultQ].Value = 1;
                }
            }
            else
            {
                calcResults[ResultQ].Value = 0;
            }


            lastValueQ =  calcResults[ResultQ].Value ;
        }

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputRd] = new PIDAlgorithmVar(InputRd, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputSd] = new PIDAlgorithmVar(InputSd, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// 初始化输出参数
        /// </summary>
        /// <returns></returns>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultQ] = new PIDAlgorithmVar(ResultQ, PIDVarDataType.DM);
        }
        #endregion

        public override string AlgName
        {
            get { return "RS触发器算法块"; }
        }
    }
}
