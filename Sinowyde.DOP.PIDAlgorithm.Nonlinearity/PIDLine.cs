using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    ///<summary>
    /// �ֶ����� ��LINE�� Linear
    /// </summary>
    [Serializable]
    public class PIDLine : PIDBindAlgorithm
    {
        ///<summary>
        /// �۵���������(i=1,2,...,10)
        /// </summary>
        public const string ParamSAI = PIDAlgorithmToken.prefixParam + "SAI";
        ///<summary>
        /// �۵��������(i=1,2,...,10)
        /// </summary>
        public const string ParamSAO = PIDAlgorithmToken.prefixParam + "SAO";
        ///<summary>
        /// ����ֵ
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// ���ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        public override string AlgName
        {
            get { return "�ֶ������㷨��"; }
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamSAI] = new PIDAlgorithmParam(ParamSAI, "1#2#3#4#5#0#0#0#0#0");
            this.calcParams[ParamSAO] = new PIDAlgorithmParam(ParamSAO, "0#1#2#3#4#0#0#0#0#0");
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);

        }
        /// <summary>
        ///4������˵��
        ///��ʾһ���ֶ����Ժ������۵�������������۵�����������һһ��Ӧ����ʾ����ֵ AI
        ///�����ֵ AO ֮���Ӧ�ķֶ����Թ�ϵ��
        ///5���㷨˵�� 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            IList<double> sai = calcParams[ParamSAI].Values;
            IList<double> sao = calcParams[ParamSAO].Values;
            double ai = calcInputs[InputAI].Value;
            int c = 1;
            for (int i = 1; i < sai.Count; i++)
            {
                if (sai[i] > 0)
                    c += 1;
            }
            if (ai <= sai[0])
                calcResults[ResultAO].Value = sao[0];
            else if (ai > sai[c - 1])
            {
                calcResults[ResultAO].Value = sao[c - 1];
            }
            else
            {
                for (int i = 0; i < c - 1; i++)
                {
                    if (sai[i] < ai && ai <= sai[i + 1])
                    {
                        double step1 = (sao[i + 1] - sao[i]) / (sai[i + 1] - sai[i]);
                        double step2 = (ai - sai[i]);
                        calcResults[ResultAO].Value = step1 * step2 + sao[i];
                        break;
                    }
                }
            }
        }
    }
}