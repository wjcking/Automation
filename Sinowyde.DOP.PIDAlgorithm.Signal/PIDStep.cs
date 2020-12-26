using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// ��Ծ�ź��㷨�飨Step��Step Signal85772
    /// </summary>
    [Serializable]
    public class PIDStep : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// ��ֵ
        /// </summary>
        public const string ParamInit = PIDAlgorithmToken.prefixParam + "Init";
        ///<summary>
        /// ��Ծֵ
        /// </summary>
        public const string ParamStep = PIDAlgorithmToken.prefixParam + "Step";
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
            this.calcParams[ParamStep] = new PIDAlgorithmParam(ParamStep, 1.0);
            this.calcParams[ParamTime] = new PIDAlgorithmParam(ParamTime);
        }

        /// <summary>
        ///4������˵��
        ///��ָ���ķ���ʱ���𷢳�һ�������߶ȵĽ�Ծ�źš� 
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double init = this.calcParams[ParamInit].Value;
            double step = this.calcParams[ParamStep].Value;
            var time = this.calcParams[ParamTime].Value;

            this.calcResults[ResultAO].Value = (this.GetInitDT() < time) ? init : step;
        }


        public override string AlgName
        {
            get { return "��Ծ�ź��㷨��"; }
        }
    }
}