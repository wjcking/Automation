
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// ���������ѡ���㷨�飨DOSEL��Digital Output Selection
    /// </summary>
    [Serializable]
    public class PIDDosel : PIDBindAlgorithm
    {
        #region ����

        ///<summary>
        /// ����������
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// ���ѡ���ź�
        /// </summary>
        public const string InputDC = PIDAlgorithmToken.prefixInput + "DC";
        ///<summary>
        /// ���������ֵ
        /// </summary>
        public const string ResultDO1 = PIDAlgorithmToken.prefixResult + "DO1";
        ///<summary>
        /// ���������ֵ
        /// </summary>
        public const string ResultDO2 = PIDAlgorithmToken.prefixResult + "DO2";

        /// <summary>
        /// ��һ��DO1ֵ
        /// </summary>
        private double lastResultDO1 = 0;

        /// <summary>
        /// ��һ��DO2ֵ
        /// </summary>
        private double lastResultDO2 = 0;
        #endregion

        #region Abstract class PIDAlgorithm

        public override string AlgName
        {
            get { return "���������ѡ���㷨��"; }
        }


        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDC] = new PIDAlgorithmVar(InputDC, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams() { }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO1] = new PIDAlgorithmVar(ResultDO1, PIDVarDataType.DM);
            this.calcResults[ResultDO2] = new PIDAlgorithmVar(ResultDO2, PIDVarDataType.DM);
        }

        /// <summary>
        ///4������˵��
        ///���㷨������������ѡ���ܡ����������� DC ���л����ص����á�
        ///5���㷨˵��
        ///�� DC=True (�� 1)ʱ��DO1=DI��DO2(n)=DO2(n-1)��
        ///�� DC=False(�� 0)ʱ��DO2=DI��DO1(n)=DO1(n-1)��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            if (calcInputs[InputDC].ValueToBool())
            {
                this.calcResults[ResultDO1].Value = calcInputs[InputDI].Value;
                this.calcResults[ResultDO2].Value = lastResultDO2;
            }
            else
            {
                this.calcResults[ResultDO1].Value = lastResultDO1;
                this.calcResults[ResultDO2].Value = calcInputs[InputDI].Value;
            }

            lastResultDO1 = this.calcResults[ResultDO1].Value;
            lastResultDO2 = this.calcResults[ResultDO2].Value;
        }

        #endregion
    }
}