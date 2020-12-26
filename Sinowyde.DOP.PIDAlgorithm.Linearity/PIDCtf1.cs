
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    ///<summary>
    /// �������ݺ��� 1 �㷨�飨CTF1��ContinuousTransFunction15034c
    /// </summary>
    public class PIDCtf1 : PIDBindAlgorithm
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
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
            this.calcParams[ParamA] = new PIDAlgorithmParam(ParamA);
            this.calcParams[ParamB] = new PIDAlgorithmParam(ParamB);
            this.calcParams[ParamINIT] = new PIDAlgorithmParam(ParamINIT);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0);
        }`
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO);
        }
        /// <summary>
        ///�������ݺ����㷨��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            IList<double> b = this.calcParams[ParamB].Values;
            IList<double> a = this.calcParams[ParamA].Values;
            double init = this.calcParams[ParamINIT].Value;
            double ai = this.calcParams[InputAI].Value;
            //double ao = ;
       
            //�����������ݺ����㷨��
            if (a.Count == 0 || k == 0 || a.Count < b.Count)
            {
                this.calcResults[ResultAO].Value = -1;
                return;
            }
            
            double denominator =0;//��ĸ
            double numerator =0;//����
            var s = GetDt();//s�����Ժ������

            for (int i = b.Count-1; i > 0; i--)
            {
                denominator += b[i] * Math.Pow(s, i);
            }

            for (int i = a.Count-1; i > 0; i--)
            {
                numerator += a[i] * Math.Pow(s, i);
            }

            this.calcParams[InputAI].Value = k * (denominator / numerator) * ai;
        }
    }
}