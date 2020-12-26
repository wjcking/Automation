
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 6.7��ʱ���㷨�飨DelayOn��aa6d6
    /// </summary>
    [Serializable]
    public class PIDDelayon : PIDBindTimerAlgorithm
    {
        ///<summary>
        /// ��ʱʱ��
        /// </summary>
        public const string ParamDELAY = PIDAlgorithmToken.prefixParam + "DELAY";
        ///<summary>
        /// ʹ�ܶ�
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// ���������
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        private double lastDI = 0;
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDELAY] = new PIDAlgorithmParam(ParamDELAY);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary> 
        ///4�� ����˵��
        ///�趨��ʱʱ������������� 0 �� 1
        ///5���㷨˵��
        ///�����趨��������ʱ��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double di = this.calcInputs[InputDI].Value;
            this.calcResults[ResultDO].Value = di;
            this.lastDI = di;
        }
        /// <summary>
        /// ��������
        /// </summary>
        protected override void SetTimerPeriod()
        {
            double di = this.calcInputs[InputDI].Value;
            if (this.FirstCalcTime == DateTime.MinValue)
            {
                this.period = 0;
            }
            else
            {
                if (lastDI == 0 && di == 1)
                {
                    this.period = this.calcParams[ParamDELAY].Value*1000;
                }
                else
                {
                    this.period = 0;
                }
            }            
        }

        public override string AlgName
        {
            get { return "��ʱ���㷨��"; }
        }

    }
}