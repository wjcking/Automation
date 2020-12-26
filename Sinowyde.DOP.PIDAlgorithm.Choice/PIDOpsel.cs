
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    /// ģ�������ѡ���㷨��
    /// </summary>
    [Serializable]
    public class PIDOpsel : PIDBindAlgorithm
    {

        #region ����

        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// ����������
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// �л�����
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";
        ///<summary>
        /// ģ�������ֵ
        /// </summary>
        public const string ResultAO1 = PIDAlgorithmToken.prefixResult + "AO1";

        ///<summary>
        /// ģ�������ֵ
        /// </summary>
        public const string ResultAO2 = PIDAlgorithmToken.prefixResult + "AO2";

        /// <summary>
        /// ��һ��AO1ֵ
        /// </summary>
        private double lastResultAO1 = 0;

        /// <summary>
        /// ��һ��AO2ֵ
        /// </summary>
        private double lastResultAO2 = 0;

        #endregion

        public override string AlgName
        {
            get { return "ģ�������ѡ���㷨��"; }
        }


        #region Abstract class PIDAlgorithm

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, PIDVarDataType.AM);
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK,0);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO1] = new PIDAlgorithmVar(ResultAO1, PIDVarDataType.AM);
            this.calcResults[ResultAO2] = new PIDAlgorithmVar(ResultAO2, PIDVarDataType.AM);
        }

        /// <summary>
        ///4������˵��
        ///���㷨������ѡ���ܡ�������л������У������ָ�����л����� K �仯��
        ///5���㷨˵��
        ///�� DI=True (�� 1)ʱ��AO1=AI ��AO2(n)=AO2(n-1)��
        ///�� DI=False(�� 0)ʱ��AO2=AI ��AO1(n)=AO1(n-1)��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            bool inputDIVal = this.calcInputs[InputDI].ValueToBool();
            double inputAIVal = this.calcInputs[InputAI].Value;
            double paramKVal = this.calcParams[ParamK].Value;
            if (inputDIVal)
            {
                /*
                 * AO1 -> AI
                 * */
                if (paramKVal == 0)
                {
                    this.calcResults[ResultAO1].Value = inputAIVal;
                }
                else if (lastResultAO1 > inputAIVal)
                {
                    double bias = lastResultAO1 - paramKVal;
                    this.calcResults[ResultAO1].Value = bias < inputAIVal ? inputAIVal : bias;
                }
                else
                {
                    double bias = lastResultAO1 + paramKVal;
                    this.calcResults[ResultAO1].Value = bias > inputAIVal ? inputAIVal : bias;
                }
                this.calcResults[ResultAO2].Value = lastResultAO2;
            }
            else
            {
                /*
                 * AO2 -> AI
                 * */
                if (paramKVal == 0)
                {
                    this.calcResults[ResultAO2].Value = inputAIVal;
                }
                else if (lastResultAO2 > inputAIVal)
                {
                    double bias = lastResultAO2 - paramKVal;
                    this.calcResults[ResultAO2].Value = bias < inputAIVal ? inputAIVal : bias;
                }
                else
                {
                    double bias = lastResultAO2 + paramKVal;
                    this.calcResults[ResultAO2].Value = bias > inputAIVal ? inputAIVal : bias;
                }
                this.calcResults[ResultAO1].Value = lastResultAO1;
            }

            lastResultAO1 = this.calcResults[ResultAO1].Value;
            lastResultAO2 = this.calcResults[ResultAO2].Value;
        }

        #endregion
    }
}