
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Signal
{
    ///<summary>
    /// �����ź��㷨�飨Square��Square wave 
    /// </summary>
    [Serializable]
    public class PIDSquare : PIDBindSignalAlgorithm
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
        /// �������
        /// </summary>
        public const string ParamWidth = PIDAlgorithmToken.prefixParam + "Width";
        
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmParam(ParamHigh,1.0);
            this.calcParams[ParamLow] = new PIDAlgorithmParam(ParamLow);
            this.calcParams[ParamWidth] = new PIDAlgorithmParam(ParamWidth,1.0);
        }
        /// <summary>
        ///4������˵��
        ///��һ���Ĳ��塢���ȼ�������һ�������ķ���������Ͳ��ȿ���Ϊ���������������ڲ��ȡ�
        ///5���㷨˵��
        ///��� DI=1��
        ///AO = High 2*i*Width �� t �� (2*i+1)*Width (i=0,1,2, ��..)
        ///AO = Low (2*i+1)*Width �� t �� (2*i+2)*Width (i=0,1,2, ��..)
        ///��� DI=0��
        ///AO = 0
        /// </summary>
        protected override void SignalInternalDoCalc()
        {          
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;
            double width = this.calcParams[ParamWidth].Value;

            double t = this.GetInitDT();
            while (true)
            {
                //���� 0 �� ���ֵ
                if (2 * inc * width <= t && t < (2 * inc + 1) * width)
                {
                    this.calcResults[ResultAO].Value = high;
                    break;
                }
                else if ((2 * inc + 1) * width <= t && t < (2 * inc + 2) * width)
                {
                    this.calcResults[ResultAO].Value = low;
                    break;
                }
                else
                {
                    if (inc == int.MaxValue)
                    {
                        inc = 0;
                        this.InitTime = DateTime.MinValue;
                    }
                    else
                    {
                        inc++;
                    }
                }
            }
        }

        public override string AlgName
        {
            get { return "�����ź��㷨��"; }
        }
    }
}