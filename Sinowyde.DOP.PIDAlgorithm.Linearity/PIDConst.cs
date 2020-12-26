
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// ��ϵ���㷨�飨CONST�� 
    /// </summary>
    [Serializable]
    public class PIDConst : PIDBindAlgorithm
    {  ///<summary>
        /// ��ϵ��ֵ
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// ����ֵ
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// ���ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
        }
        /// <summary>
        ///4������˵��
        ///��ģ����б������㡣
        ///5���㷨˵��
        ///AO=K*AI 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            this.calcResults[ResultAO].Value = this.calcParams[ParamK].Value * this.calcInputs[InputAI].Value;
        }

        public override string AlgName
        {
            get { return "��ϵ���㷨��"; }
        }
    }
}