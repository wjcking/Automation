
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 6.9���������㷨�飨PULSE��8f0d8
    /// </summary>
    [Serializable]
    public class PIDPulse : PIDBindAlgorithm
    {  ///<summary>
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

        /// <summary>
        /// ��ʼʱ����
        /// </summary>
        protected DateTime InitTime = DateTime.MinValue;
        /// <summary>
        /// ���ʼʱ����ƫ��
        /// </summary>
        /// <returns></returns>
        public double GetInitDT()
        {
            return (DateTime.MinValue == InitTime) ? 0 :
                (CurrentCalcTime - InitTime).TotalSeconds;
        }

        protected override void ResetEnvVars()
        {
            base.ResetEnvVars();
            this.InitTime = DateTime.MinValue;
        }
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDELAY] = new PIDAlgorithmParam(ParamDELAY);
        }
        /// <summary>
        /// 
        /// </summary>
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
            if (this.calcInputs[InputDI].ValueToBool())
            {
                if (this.InitTime == DateTime.MinValue)
                {
                    this.InitTime = DateTime.Now;
                    this.calcResults[ResultDO].Value = 1;
                }
                else 
                {
                    if (GetInitDT() <= this.calcParams[ParamDELAY].Value)
                    {
                        this.calcResults[ResultDO].Value = 1;
                    }
                    else
                    {
                        this.calcResults[ResultDO].Value = 0;
                    }
                }
                
            }
            else
            {
                this.calcResults[ResultDO].Value = 0;
                this.InitTime = DateTime.MinValue;
            }
        }

        public override string AlgName
        {
            get { return "���������㷨��"; }
        }
    }
}