
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// б���ź��㷨�飨Ramp��Ramp Signald9b5d
    /// </summary>
    [Serializable]
    public class PIDRamp : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// ��ֵ
        /// </summary>
        public const string ParamInit = PIDAlgorithmToken.prefixParam + "Init";
        ///<summary>
        /// б��ֵ
        /// </summary>
        public const string ParamSlope = PIDAlgorithmToken.prefixParam + "Slope";
        ///<summary>
        /// ����ʱ��
        /// </summary>
        public const string ParamTime = PIDAlgorithmToken.prefixParam + "Time";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamInit] = new PIDAlgorithmParam(ParamInit);
            this.calcParams[ParamSlope] = new PIDAlgorithmParam(ParamSlope,1.0);
            this.calcParams[ParamTime] = new PIDAlgorithmParam(ParamTime);
        }
        /// <summary>
        ///4������˵��
        ///��ָ��ʱ���𷢳�һ������б�ʵĵ�б���źš�
        ///5���㷨˵��
        ///��� DI=1��
        ///AO = Init , t��Time
        ///AO = Init+Slope*(t-Time) , t��Time
        ///t����ʱ�����
        ///��� DI=0
        ///AO = 0
        ///ʱ��������㡣
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double init = this.calcParams[ParamInit].Value;
            double slope = this.calcParams[ParamSlope].Value;
            double time = this.calcParams[ParamTime].Value;

            this.calcResults[ResultAO].Value = this.GetInitDT() < time ? init :
                    init + slope * (this.GetInitDT() - time);
        }

        public override string AlgName
        {
            get { return "б���ź��㷨��"; }
        }

    }
}