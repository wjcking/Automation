using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// ģ�����ֵ�������㷨��(ASETPOINT)
    /// </summary>
    [Serializable]
    public class PIDAsetpoint : PIDBindAlgorithm
    {
        public PIDAsetpoint()
            :base()
        {
        }
        ///<summary>
        /// ʹ�ܶ�
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";

        ///<summary>
        /// ����ƫ��ֵ
        /// </summary>
        public const string InputBIAS = PIDAlgorithmToken.prefixInput + "BIAS";

        ///<summary>
        /// �������
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputBIAS] = new PIDAlgorithmVar(InputBIAS, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI,1,PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        
        /// <summary>
        ///4������˵��
        ///��ʹ�ܶ� DI=0 ��ʱ�򣬲���Ա�޷������ֶ���������ֵ�Ĳ������� DI=1 ��ʱ��
        ///�� ��Ա����ѡ����������ֵ��
        ///5���㷨˵��
        ///�� DI=1 ʱ������Ա���Է����ֶ��������趨����ֵ�Ĳ������� DI=0 ʱ���������λ��
        /// </summary>
        protected override void InternalDoCalc()
        {
            if (this.calcInputs[InputDI].ValueToBool())
            {
                this.calcResults[ResultAO].Value = this.calcInputs[InputBIAS].Value;
            }
            else
            {
                this.calcResults[ResultAO].Value = this.calcResults[ResultAO].SourceValue;
            }           
        }

        public override string AlgName
        {
            get { return "ģ�����ֵ�������㷨��"; }
        }

    }
}