
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// ��Сֵ�㷨�飨MIN��Minimumd
    /// </summary>
    [Serializable]
    public class PIDMin : PIDBindAlgorithm
    {
        #region ����

        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI3 = PIDAlgorithmToken.prefixInput + "AI3";
        public const string InputAI4 = PIDAlgorithmToken.prefixInput + "AI4";
        ///<summary>
        /// ģ�������
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        #endregion

        #region Abstract class PIDAlgorithm

        public override string AlgName
        {
            get { return "��Сֵ�㷨��"; }
        }


        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI3] = new PIDAlgorithmVar(InputAI3, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI4] = new PIDAlgorithmVar(InputAI4, 0, PIDVarInputType.Init, PIDVarDataType.AM);
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
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);

        }
        /// <summary>
        ///4������˵��
        ///���㷨�����Сֵѡ���ܡ�
        ///5���㷨˵��
        ///AO=MIN(AI1,AI2,AI3,AI4)
        ///ע�⣺���յ����벻�μӱȽϡ�
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double minVal = double.MaxValue;
            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI1)))
            {
                if (calcInputs[InputAI1].Value < minVal)
                    minVal = calcInputs[InputAI1].Value;
            }

            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI2)))
            {
                if (calcInputs[InputAI2].Value < minVal)
                    minVal = calcInputs[InputAI2].Value;
            }

            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI3)))
            {
                if (calcInputs[InputAI3].Value < minVal)
                    minVal = calcInputs[InputAI3].Value;
            }

            if (!string.IsNullOrEmpty(this.GetBindParam(InputAI4)))
            {
                if (calcInputs[InputAI4].Value < minVal)
                    minVal = calcInputs[InputAI4].Value;
            }
            this.calcResults[ResultAO].Value = minVal;
        }
        #endregion
    }
}