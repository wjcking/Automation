
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Choice
{
    ///<summary>
    ///ģ��������ѡ���㷨��
    /// </summary>
    [Serializable]
    public class PIDInsel : PIDBindAlgorithm
    {
        #region ����

        ///<summary>
        ///ģ��������
        /// </summary>
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        /// <summary>
        /// ģ��������
        /// </summary>
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";
        ///<summary>
        /// AI1 �� AI2 ���л�����
        /// </summary>
        public const string ParamK1 = PIDAlgorithmToken.prefixParam + "K1";
        ///<summary>
        /// AI2 �� AI1 ���л�����
        /// </summary>
        public const string ParamK2 = PIDAlgorithmToken.prefixParam + "K2";
        ///<summary>
        ///����������
        /// </summary>
        public const string InputDI = PIDAlgorithmToken.prefixInput + "DI";
        ///<summary>
        /// ���ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        /// <summary>
        /// ��һ�μ�����
        /// </summary>
        private double lastResultAO = 0;

        #endregion

        public override string AlgName
        {
            get { return "ģ��������ѡ���㷨��"; }
        }

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputDI] = new PIDAlgorithmVar(InputDI, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamK1] = new PIDAlgorithmParam(ParamK1);
            this.calcParams[ParamK2] = new PIDAlgorithmParam(ParamK2);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);

        }
        /// <summary>
        /// K1 AI1 �� AI2 ���л����� Double
        /// K2 AI2 �� AI1 ���л����� Double
        ///4������˵��
        ///���㷨�������ѡ���ܡ����������� DI ���л����ص����á� DI Ϊ 1 ʱ����� AI1��
        ///����ı仯�ʼ�Ϊ K2�� DI Ϊ 0 ʱ����� AI2������ı仯�ʼ�Ϊ K1��
        ///5���㷨˵��
        ///�� DI=True (�� 1)ʱ�� AO=AI1��
        ///�� DI=False(�� 0)ʱ�� AO=AI2��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            bool di = this.calcInputs[InputDI].ValueToBool();

            double ai1 = this.calcInputs[InputAI1].Value;
            double ai2 = this.calcInputs[InputAI2].Value;

            double k1 = this.calcParams[ParamK1].Value;
            double k2 = this.calcParams[ParamK2].Value;


            if (di)
            {
                if (k2 == 0)
                {
                    this.calcResults[ResultAO].Value = ai1;
                }
                else if (lastResultAO > ai1)
                {
                    //�ݼ�
                    double bias = lastResultAO - k2;
                    this.calcResults[ResultAO].Value = bias < ai1 ? ai1 : bias;
                }
                else
                {
                    //����
                    double bias = lastResultAO + k2;
                    this.calcResults[ResultAO].Value = bias > ai1 ? ai1 : bias;
                }
            }
            else
            {
                if (k1 == 0)
                {
                    this.calcResults[ResultAO].Value = ai2;
                }
                else if (lastResultAO > ai2)
                {
                    //�ݼ�
                    double bias = lastResultAO - k1;
                    this.calcResults[ResultAO].Value = bias < ai2 ? ai2 : bias;
                }
                else
                {
                    //����
                    double bias = lastResultAO + k1;
                    this.calcResults[ResultAO].Value = bias > ai2 ? ai2 : bias;
                }
            }

            lastResultAO = this.calcResults[ResultAO].Value;
        }

        #endregion
    }
}