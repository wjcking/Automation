
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    public class DelayTempData
    {
        public DateTime Timestamp
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }
    ///<summary>
    /// 纯延迟算法块（DALAY） 
    /// </summary>
    [Serializable]
    public class PIDDalay : PIDBindAlgorithm
    {
        ///<summary>
        /// 纯迟延时间
        /// </summary>
        public const string ParamT = PIDAlgorithmToken.prefixParam + "T";
        ///<summary>
        /// 模拟量输入
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        [NonSerialized]
        private IList<DelayTempData> buffer = new List<DelayTempData>();

        private DelayTempData GetFirstValue()
        {
            if (buffer.Count > 0)
                return buffer[0];
            else
                return null;
        }
        /// <summary>
        /// 初始化变量参数,单位是秒
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamT] = new PIDAlgorithmParam(ParamT, 10);
        }
        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        /// 初始化结果参数,与算法文档不一致
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        ///4、功能说明
        ///该模块将模拟量输入经迟延τ后输出。
        ///5、算法说明
        ///AO = AI ? e?τ ?S
        ///τ不能为负数。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            DateTime timestamp = DateTime.Now;
            if(buffer.Count == 0 ||
                (timestamp - GetFirstValue().Timestamp).TotalSeconds < this.calcParams[ParamT].Value)
            {
                buffer.Add(new DelayTempData{ Timestamp=DateTime.Now, Value=this.calcInputs[InputAI].Value});                
            }
            else
            {
                this.calcResults[ResultAO].Value = this.GetFirstValue().Value;
                buffer.RemoveAt(0);
            }
        }

        public override string AlgName
        {
            get { return "纯延迟算法块"; }
        }
    }
}