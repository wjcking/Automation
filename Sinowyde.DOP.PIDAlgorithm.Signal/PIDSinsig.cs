
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// �����ź��㷨�飨SinSig��Sin Signald56a5
    /// </summary>
    [Serializable]
    public class PIDSinsig : PIDBindSignalAlgorithm
    { 
        ///<summary>
        /// ����ʱ��
        /// </summary>
        public const string ParamTime = PIDAlgorithmToken.prefixParam + "Time";
        ///<summary>
        /// ��ֵ
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// Ƶ��
        /// </summary>
        public const string ParamFreq = PIDAlgorithmToken.prefixParam + "Freq";
        ///<summary>
        /// ���
        /// </summary>
        public const string ParamRad = PIDAlgorithmToken.prefixParam + "Rad";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamTime] = new PIDAlgorithmParam(ParamTime);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK,1.0);
            this.calcParams[ParamFreq] = new PIDAlgorithmParam(ParamFreq,1.0);
            this.calcParams[ParamRad] = new PIDAlgorithmParam(ParamRad);
        }
       
        /// <summary>
        ///4������˵��
        ///��ָ��ʱ���𷢳�һ������б�ʵĵ�б���źš�
        ///5���㷨˵�� ��� DI=1��
        ///AO = Init ,	t��Time
        ///AO = Init+Slope*(t-Time) ,	t��Time
        ///t����ʱ�����
        ///��� DI=0
        ///AO = 0
        ///ʱ��������㡣
        ///�����ź��㷨�飨SinSig��Sin Signal
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            double freq = this.calcParams[ParamFreq].Value;
            double time = this.calcParams[ParamTime].Value;
            double rad = this.calcParams[ParamRad].Value;

            this.calcResults[ResultAO].Value = this.GetInitDT() < time ? 0 : k * Math.Sin(freq * this.GetInitDT() + rad);

        }

        public override string AlgName
        {
            get { return "�����ź��㷨��"; }
        }
    }
}