
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// ��η����ź��㷨�飨MSquare��Multi-Square Signal
    /// </summary>
    [Serializable]
    public class PIDMsquare : PIDBindSignalAlgorithm
    {  ///<summary>
        /// �۵�ʱ������
        /// </summary>
        public const string ParamSTime = PIDAlgorithmToken.prefixParam + "STime";
        ///<summary>
        /// �۵��������
        /// </summary>
        public const string ParamSOut = PIDAlgorithmToken.prefixParam + "SOut";
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamSTime] = new PIDAlgorithmParam(ParamSTime, "2#5#11#20#50#0#0#0#0#0");
            this.calcParams[ParamSOut] = new PIDAlgorithmParam(ParamSOut, "1#2#0.5#4#0#0#0#0#0#0");
        }

        /// <summary>
        ///4������˵��
        ///����һ��Ƶ�ʺ�ʱ��ɱ�ķ����źţ����ڵ��۵�ʱ��֮������ֵ�Ƕ�Ӧ���۵���
        ///����ʱ�䳬������۵�ʱ������ֵ���ǵ������Ҳ���۵����ֵ��
        ///5���㷨˵��
        ///��� DI=1��
        ///AO = 0 ��
        ///0 С�� С�� Tt 0 ʱ��
        ///= AOAO i �� i С�ڡ� TtT i+1ʱ�� i = �� 8,,2,1,0 ��
        ///= AOAO 9 �� �� �� Tt 9
        ///���У� ����ʱ������� �����۵����ֵ�� �����۵�ʱ��ֵ�� t
        ///AOi Ti
        ///��� DI=0,
        ///AO = 0 
        ///ʱ��������㡣
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            var stime = this.calcParams[ParamSTime].Values;
            var sout = this.calcParams[ParamSOut].Values;
            double t = GetTotalDt();
            int c = 1;
            for (int i = 1; i < stime.Count; i++)
            {
                if (stime[i] > 0)
                    c += 1;
            }
            for (int i = 0; i < c - 1; i++)
            {
                if (0 < t && t < stime[0])
                {
                    this.calcResults[ResultAO].Value = 0;
                    return;
                }
                else if (stime[i] <= t && t < stime[i + 1])
                {
                    this.calcResults[ResultAO].Value = sout[i];
                    return;
                }
            }

            if (t >= stime[c-1])
                this.calcResults[ResultAO].Value = sout[c-1];
        }

        public override string AlgName
        {
            get { return "��η����ź��㷨��"; }
        }
    }
}