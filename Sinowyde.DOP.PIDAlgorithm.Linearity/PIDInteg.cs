
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// �����㷨�飨INTEG��
    /// </summary>
    [Serializable]
    public class PIDInteg : PIDBindAlgorithm
    {  ///<summary>
        /// ��ϵ��
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// ���ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        private double lastAI = 0;
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
        ///��ģ���ģ������������֣���������Ϊ K��
        ///5���㷨˵��
        ///AO = K ? AI
        ///s 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            double ai = this.calcInputs[InputAI].Value;

            if (GetDt() > 0)
            {
                this.calcResults[ResultAO].Value += GetDt() * k * (ai + lastAI) / 2;
            }
            lastAI = ai;
        }

        public override string AlgName
        {
            get { return "�����㷨��"; }
        }
    }
}