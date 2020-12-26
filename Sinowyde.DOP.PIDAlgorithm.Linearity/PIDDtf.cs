
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// ��ɢ���ݺ����㷨�飨DTF��Discrete Trans Function6ab8e
    /// </summary>
    public class PIDDtf : PIDBindAlgorithm
    {  ///<summary>
        /// ����ϵ��
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// ����ϵ������
        /// </summary>
        public const string ParamA = PIDAlgorithmToken.prefixParam + "A";
        ///<summary>
        /// ��ĸϵ������
        /// </summary>
        public const string ParamB = PIDAlgorithmToken.prefixParam + "B";
        ///<summary>
        /// ����ʱ��
        /// </summary>
        public const string ParamT = PIDAlgorithmToken.prefixParam + "T";
        ///<summary>
        /// �����ʼֵ
        /// </summary>
        public const string ParamINIT = PIDAlgorithmToken.prefixParam + "INIT";
        ///<summary>
        /// ģ��������
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
            this.calcParams[ParamK] = new PIDAlgorithmVar(ParamK, false, PIDVarType.Unknown);
            this.calcParams[ParamA] = new PIDAlgorithmVar(ParamA, false, PIDVarType.AM);
            this.calcParams[ParamB] = new PIDAlgorithmVar(ParamB, false, PIDVarType.Unknown);
            this.calcParams[ParamT] = new PIDAlgorithmVar(ParamT, false, PIDVarType.Unknown);
            this.calcParams[ParamINIT] = new PIDAlgorithmVar(ParamINIT, false, PIDVarType.Unknown);
            this.calcParams[InputAI] = new PIDAlgorithmVar(InputAI, true, PIDVarType.AM);

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, true, PIDVarType.AM);

        }
        /// <summary>
        ///
        /// </summary>  
        protected override void InternalDoCalc()
        {
          
            double t = this.calcParams[ParamT].Value;        
            double k = this.calcParams[ParamK].Value;
            IList<double> b = this.calcParams[ParamB].Values;
            IList<double> a = this.calcParams[ParamA].Values;
            double init = this.calcParams[ParamINIT].Value;
            double ai = this.calcParams[InputAI].Value;

            //�����������ݺ����㷨��
            if (a.Count == 0 || k == 0 || a.Count < b.Count)
            {
                this.calcResults[ResultAO].Value = -1;
                return;
            }

            double denominator = 0;//��ĸ
            double numerator = 0;//����
            var s = GetDt();//s�����Ժ������

            for (int i = b.Count-1; i >= 0; i--)
            {
                denominator += b[i] * Math.Pow(s, i);
            }

            for (int i = a.Count-1; i >= 0; i--)
            {
                numerator += a[i] * Math.Pow(s, i);
            }

            this.calcParams[InputAI].Value = k * (denominator / numerator) * ai;
        }
    }
}