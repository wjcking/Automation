using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 模拟给定值发生器算法块(ASETPOINT)
    /// </summary>
    [Serializable]
    public class PIDAsetpoint : PIDBindAlgorithm
    {
        public PIDAsetpoint()
            :base()
        {
        }
        ///<summary>
        /// 使能端
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";

        ///<summary>
        /// 操作偏差值
        /// </summary>
        public const string InputBIAS = PIDAlgorithmToken.prefixInput + "BIAS";

        ///<summary>
        /// 控制输出
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputBIAS] = new PIDAlgorithmVar(InputBIAS, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI,1,PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        
        /// <summary>
        ///4、功能说明
        ///当使能端 DI=0 的时候，操作员无法进行手动增减给定值的操作；当 DI=1 的时候，
        ///操 作员可以选择增减给定值。
        ///5、算法说明
        ///当 DI=1 时，操作员可以发送手动增减，设定给定值的操作，当 DI=0 时，输出被复位。
        /// </summary>
        protected override void InternalDoCalc()
        {
            if (this.calcInputs[InputDI].ValueToBool())
            {
                this.calcResults[ResultAO].Value = this.calcInputs[InputBIAS].Value;
            }
            else
            {
                this.calcResults[ResultAO].Value = this.calcResults[ResultAO].SourceValue;
            }           
        }

        public override string AlgName
        {
            get { return "模拟给定值发生器算法块"; }
        }

    }
}