
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// �����ź� 3 ѡ 2 �㷨�飨DG��Digital Signal 2 OF 
    /// </summary>
    [Serializable]
    public class PIDDg : PIDBindAlgorithm
    {
        #region ����
        ///<summary>
        /// ����������
        /// </summary>
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        ///<summary>         
        /// ����������                
        /// </summary>               
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        ///<summary>         
        /// ����������                
        /// </summary>               
        public const string InputDI3 = PIDAlgorithmToken.prefixInput + "DI3";
        ///<summary>
        /// ���������ֵ
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        #endregion

        public override string AlgName
        {
            get { return "�����ź�3ѡ2�㷨��"; }
        }

        #region Abstract class PIDAlgorithm
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 0, PIDVarInputType.Init, PIDVarDataType.DM);
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
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }
        /// <summary>
        ///4������˵�� 1= true 0 =false;
        ///��ģ���������������ѡ���ܡ�
        ///5���㷨˵��
        ///ֻ�е���������������������������������Ϊ 1 ��ʱ����� DO Ϊ 1�� ������� DO Ϊ 0��
        ///�㷨��ֵ��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            this.calcResults[ResultDO].Value = (this.calcInputs[InputDI1].Value +
                this.calcInputs[InputDI2].Value + this.calcInputs[InputDI3].Value) >= 2 ? 1 : 0;
        }
        #endregion
    }
}