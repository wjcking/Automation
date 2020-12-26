
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// ΢���㷨�飨DIFF�� 
    /// </summary>
    [Serializable]
    public class PIDDiff : PIDBindAlgorithm
    {
        ///<summary>
        /// ʱ�䳣��
        /// </summary>
        public const string ParamT = PIDAlgorithmToken.prefixParam + "T";
        ///<summary>
        /// ��������
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
        private double lastMidVal = 0;
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamT] = new PIDAlgorithmParam(ParamT, 1);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 0);
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
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        ///4������˵��
        ///��ģ���ģ�����������΢�����㡣
        ///5���㷨˵�� 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double t = this.calcParams[ParamT].Value;
            double k = this.calcParams[ParamK].Value;
            double ai = this.calcInputs[InputAI].Value;

            double dt = GetDt();

            if (dt == 0)
            {
                this.calcResults[ResultAO].Value = 0;
                lastAI = ai;
            }
            else
            {
                double y = Math.Exp((dt * -1) / t);
                double midVal = y * lastMidVal + k / t * (1 - y) * ai;
                this.calcResults[ResultAO].Value = k / t * ai + midVal;

                lastAI = ai;
                lastMidVal = midVal;
            }
        }

        public override string AlgName
        {
            get { return "΢���㷨��"; }
        }
    }
}