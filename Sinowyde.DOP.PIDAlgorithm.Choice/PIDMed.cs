
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// ��ֵѡ���㷨�飨MED��Median Value
    /// </summary>
    [Serializable]
    public class PIDMed : PIDBindAlgorithm
    {
        #region ����

        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI3 = PIDAlgorithmToken.prefixInput + "AI3";
        ///<summary>
        /// ģ�����ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        #endregion

        public override string AlgName
        {
            get { return "��ֵѡ���㷨��"; }
        }


        #region Abstract class PIDAlgorithm

        /// <summary>
        /// �ж��㷨��Ч��,��Ҫ�����������Ƿ�󶨱���������ֵ
        /// ��Ҫȷ���޸�
        /// </summary>
        /// <returns></returns>
        public override bool CheckSelfValid()
        {
            bool result = base.CheckSelfValid();
            if (result)
            {
                if (string.IsNullOrEmpty(this.GetBindParam(InputAI1)))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.GetBindParam(InputAI2)))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(this.GetBindParam(InputAI3)))
                {
                    return false;
                }
            }
            return result;

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, PIDVarDataType.AM);
            this.calcInputs[InputAI3] = new PIDAlgorithmVar(InputAI3, PIDVarDataType.AM);
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
        ///���㷨�����ֵѡ���ܡ�
        ///5���㷨˵��
        ///AO=MED(AI1,AI2,AI3)
        ///ע�⣺��������յ����룬��ģ�鲻�����ã�����Ϊ 0
        /// </summary>  
        protected override void InternalDoCalc()
        {
            var vals = from c in calcInputs.Values
                       orderby c.Value
                       select c.Value;

            this.calcResults[ResultAO].Value = vals.ToArray()[1];
        }
        #endregion
    }
}