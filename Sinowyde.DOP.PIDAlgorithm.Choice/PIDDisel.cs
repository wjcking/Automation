
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// ����������ѡ���㷨�飨DISEL��Digital Input Selection
    /// </summary>
    [Serializable]
    public class PIDDisel : PIDBindAlgorithm
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
        public const string InputDC = PIDAlgorithmToken.prefixInput + "DC";
        ///<summary>
        /// ���ֵ
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        public override string AlgName
        {
            get { return "����������ѡ���㷨��"; }
        }


        #region Abstract class PIDAlgorithm
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDC] = new PIDAlgorithmVar(InputDC, 0, PIDVarInputType.Init, PIDVarDataType.DM);
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
        ///4������˵��
        ///���㷨�������ѡ���ܡ����������� DC ���л����ص����á�
        ///5���㷨˵��
        ///�� DC=True (�� 1)ʱ��DO=DI1�� �� DC=False(�� 0)ʱ��DO=DI2��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            if (calcInputs[InputDC].ValueToBool())
                this.calcResults[ResultDO].Value = this.calcInputs[InputDI1].Value;
            else
                this.calcResults[ResultDO].Value = this.calcInputs[InputDI2].Value;

        }

        #endregion
    }
}