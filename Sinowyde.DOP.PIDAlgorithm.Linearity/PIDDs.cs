
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// 7.8数字信号加法器算法块（DS）
    /// </summary>
    [Serializable]
    public class PIDDs : PIDBindAlgorithm
    {  ///<summary>
        /// 比例系数
        /// </summary>
        public const string ParamK1 = PIDAlgorithmToken.prefixParam + "K1";
        public const string ParamK2 = PIDAlgorithmToken.prefixParam + "K2";
        public const string ParamK3 = PIDAlgorithmToken.prefixParam + "K3";
        public const string ParamK4 = PIDAlgorithmToken.prefixParam + "K4";
        ///<summary>
        /// 数字量输入
        /// </summary>
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        public const string InputDI3 = PIDAlgorithmToken.prefixInput + "DI3";
        public const string InputDI4 = PIDAlgorithmToken.prefixInput + "DI4";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK1] = new PIDAlgorithmParam(ParamK1, 1);
            this.calcParams[ParamK2] = new PIDAlgorithmParam(ParamK2, 1);
            this.calcParams[ParamK3] = new PIDAlgorithmParam(ParamK3, 1);
            this.calcParams[ParamK4] = new PIDAlgorithmParam(ParamK4, 1);
        }
        /// <summary>
        /// 初始化输入参数 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI4] = new PIDAlgorithmVar(InputDI4, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }
        /// <summary>
        ///4、功能说明
        ///本模块能实现在 4 个数字量输入信号中，统计出有几个为 1。
        ///5、算法说明
        ///本算法块能加权统计 DI 中 1 的个数，从 AO 输出。
        ///AO=K1*DI1+K2*DI2+K3*DI3+K4*DI4
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k1 = this.calcParams[ParamK1].Value;
            double k2 = this.calcParams[ParamK2].Value;
            double k3 = this.calcParams[ParamK3].Value;
            double k4 = this.calcParams[ParamK4].Value;

            int di1 = ConvertUtil.ConvertToInt(this.calcInputs[InputDI1].Value);
            int di2 = ConvertUtil.ConvertToInt(this.calcInputs[InputDI2].Value);
            int di3 = ConvertUtil.ConvertToInt(this.calcInputs[InputDI3].Value);
            int di4 = ConvertUtil.ConvertToInt(this.calcInputs[InputDI4].Value);

            this.calcResults[ResultAO].Value = k1 * di1 + k2 * di2 + k3 * di3 + k4 * di4;

        }

        public override string AlgName
        {
            get { return "数字信号加法器算法块"; }
        }
    }
}