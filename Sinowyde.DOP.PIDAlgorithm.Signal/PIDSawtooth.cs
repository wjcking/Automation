
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// ��ݲ��ź��㷨�飨Sawtooth��Sawtooth wave Signal2a40e
    /// </summary>
    [Serializable]
    public class PIDSawtooth : PIDBindSignalAlgorithm
    {
        ///<summary>
        /// ����
        /// </summary>
        public const string ParamHigh = PIDAlgorithmToken.prefixParam + "High";
        ///<summary>
        /// ����
        /// </summary>
        public const string ParamLow = PIDAlgorithmToken.prefixParam + "Low";
        ///<summary>
        /// ����
        /// </summary>
        public const string ParamWidth = PIDAlgorithmToken.prefixParam + "Width";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmParam(ParamHigh,1.0);
            this.calcParams[ParamLow] = new PIDAlgorithmParam(ParamLow);
            this.calcParams[ParamWidth] = new PIDAlgorithmParam(ParamWidth,100.0);
        }

        /// <summary>
        ///4������˵��
        ///��һ���Ĳ��塢���ȼ�������һ�������ľ�ݲ�������Ͳ��ȿ���Ϊ�������������
        ///���ڲ��ȡ�
        ///5���㷨˵��
        ///��� DI=1,
        ///AO = High-(Width-t)(High-Low)/Width (0��t��Width)
        ///AO=0 (t��0 �� t��Width)
        ///t ���� ʱ�����
        ///��� DI=0
        ///AO = 0
        /// </summary>  
        protected override void SignalInternalDoCalc()
        {
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;
            double width = this.calcParams[ParamWidth].Value;
            double t = this.GetInitDT();

            //���� 0 �� ���ֵ
            if (0 <= t && t < width)
            {
                this.calcResults[ResultAO].Value = high - (width - t) * (high - low) / width;
            }
            else if (t >= width)
            {
                this.calcResults[ResultAO].Value = low;
                this.InitTime = DateTime.MinValue;
            }
        }

        public override string AlgName
        {
            get { return "��ݲ��ź��㷨��"; }
        }
    }
}