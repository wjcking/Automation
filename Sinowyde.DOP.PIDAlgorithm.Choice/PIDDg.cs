
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// 数字信号 3 选 2 算法块（DG）Digital Signal 2 OF 
    /// </summary>
    [Serializable]
    public class PIDDg : PIDBindAlgorithm
    {
        #region 变量
        ///<summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        ///<summary>         
        /// 数字量输入                
        /// </summary>               
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        ///<summary>         
        /// 数字量输入                
        /// </summary>               
        public const string InputDI3 = PIDAlgorithmToken.prefixInput + "DI3";
        ///<summary>
        /// 数字量输出值
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        #endregion

        public override string AlgName
        {
            get { return "数字信号3选2算法块"; }
        }

        #region Abstract class PIDAlgorithm
        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }
        /// <summary>
        ///4、功能说明 1= true 0 =false;
        ///该模块完成数字量输入选择功能。
        ///5、算法说明
        ///只有当三个数字量输入中有两个或两个以上为 1 的时候，输出 DO 为 1； 其他情况 DO 为 0。
        ///算法真值表：
        /// </summary>  
        protected override void InternalDoCalc()
        {
            this.calcResults[ResultDO].Value = (this.calcInputs[InputDI1].Value +
                this.calcInputs[InputDI2].Value + this.calcInputs[InputDI3].Value) >= 2 ? 1 : 0;
        }
        #endregion
    }
}