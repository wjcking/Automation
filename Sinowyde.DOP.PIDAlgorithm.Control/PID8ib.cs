using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 8 ����ƽ���㷨�飨8IB��8 INPUT BALANCEd6d91
    /// </summary>
    public class PID8ib : PIDBindAlgorithm
    {
        ///<summary>
        /// ģ�����������
        /// </summary>
        public const string ParamHigh = PIDAlgorithmToken.prefixParam + "High";

        ///<summary>
        /// ģ�����������
        /// </summary>
        public const string ParamLow = PIDAlgorithmToken.prefixParam + "Low";

        ///<summary>
        /// ���ֵѡ��
        /// </summary>
        public const string ParamSout = PIDAlgorithmToken.prefixParam + "Sout";

        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";

        ///<summary>
        /// 1~8 ·�����ź�
        /// </summary>
        public const string InputTR1 = PIDAlgorithmToken.prefixInput + "TR1";
        public const string InputTR2 = PIDAlgorithmToken.prefixInput + "TR2";
        public const string InputTR3 = PIDAlgorithmToken.prefixInput + "TR3";
        public const string InputTR4 = PIDAlgorithmToken.prefixInput + "TR4";
        public const string InputTR5 = PIDAlgorithmToken.prefixInput + "TR5";
        public const string InputTR6 = PIDAlgorithmToken.prefixInput + "TR6";
        public const string InputTR7 = PIDAlgorithmToken.prefixInput + "TR7";
        public const string InputTR8 = PIDAlgorithmToken.prefixInput + "TR8";

        ///<summary>
        /// 1~8 ·���ٿ���
        /// </summary>
        public const string InputTS1 = PIDAlgorithmToken.prefixInput + "TS1";
        public const string InputTS2 = PIDAlgorithmToken.prefixInput + "TS2";
        public const string InputTS3 = PIDAlgorithmToken.prefixInput + "TS3";
        public const string InputTS4 = PIDAlgorithmToken.prefixInput + "TS4";
        public const string InputTS5 = PIDAlgorithmToken.prefixInput + "TS5";
        public const string InputTS6 = PIDAlgorithmToken.prefixInput + "TS6";
        public const string InputTS7 = PIDAlgorithmToken.prefixInput + "TS7";
        public const string InputTS8 = PIDAlgorithmToken.prefixInput + "TS8";

        ///<summary>
        /// ģ�������
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        ///<summary>
        /// ���������
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamHigh] = new PIDAlgorithmVar(ParamHigh, false, PIDVarDataType.Unknown);
            this.calcParams[ParamLow] = new PIDAlgorithmVar(ParamLow, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSout] = new PIDAlgorithmVar(ParamSout, false, PIDVarDataType.Unknown);
            this.calcParams[InputAI] = new PIDAlgorithmVar(InputAI, true, PIDVarDataType.DM);
            this.calcParams[InputTR1] = new PIDAlgorithmVar(InputTR1, true, PIDVarDataType.DM);
            this.calcParams[InputTR2] = new PIDAlgorithmVar(InputTR2, true, PIDVarDataType.DM);
            this.calcParams[InputTR3] = new PIDAlgorithmVar(InputTR3, true, PIDVarDataType.DM);
            this.calcParams[InputTR4] = new PIDAlgorithmVar(InputTR4, true, PIDVarDataType.DM);
            this.calcParams[InputTR5] = new PIDAlgorithmVar(InputTR5, true, PIDVarDataType.DM);
            this.calcParams[InputTR6] = new PIDAlgorithmVar(InputTR6, true, PIDVarDataType.DM);
            this.calcParams[InputTR7] = new PIDAlgorithmVar(InputTR7, true, PIDVarDataType.DM);
            this.calcParams[InputTR8] = new PIDAlgorithmVar(InputTR8, true, PIDVarDataType.DM);
            this.calcParams[InputTS1] = new PIDAlgorithmVar(InputTS1, true, PIDVarDataType.DM);
            this.calcParams[InputTS2] = new PIDAlgorithmVar(InputTS2, true, PIDVarDataType.DM);
            this.calcParams[InputTS3] = new PIDAlgorithmVar(InputTS3, true, PIDVarDataType.DM);
            this.calcParams[InputTS4] = new PIDAlgorithmVar(InputTS4, true, PIDVarDataType.DM);
            this.calcParams[InputTS5] = new PIDAlgorithmVar(InputTS5, true, PIDVarDataType.DM);
            this.calcParams[InputTS6] = new PIDAlgorithmVar(InputTS6, true, PIDVarDataType.DM);
            this.calcParams[InputTS7] = new PIDAlgorithmVar(InputTS7, true, PIDVarDataType.DM);
            this.calcParams[InputTS8] = new PIDAlgorithmVar(InputTS8, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, false, PIDVarDataType.DM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, false, PIDVarDataType.DM);

        }

        /// <summary>
        ///4������˵��
        ///��������ֵ�����Ӧ�ĸ��ٿ������ɴ� 8 �ԣ�ʵ�ʸ��ٵ�Ķ���Ϊ���� 8 �������벻 Ϊ NULL �Ĳ��(���ٿ��ؼ�����ֵ���κ�һ��Ϊ�յ�ʱ)����������Ϊ N��
        ///�� N ����Ч�����ź� TR �У�������ٿ��� TS Ϊ 1����Ϊ�ֶ��㣻TS Ϊ 0����Ϊ�Զ� �㡣���Զ���ĸ���Ϊ K(N��K��0)��
        ///�� K��0��ƽ��������� Y Ϊ�������ֶ������ֵ֮��
        ///�����	����DO��0
        ///���У�AIΪ�����źţ� TRΪ�����ź�ֵ�� TSΪ���ٿ���
        ///�� K��0���������źŶ����ڸ���״̬����ʱ��� AO =N
        ///��TR(i) 
        ///i=1	Ϊ���������������N
        ///��� DO��1��
        ///ģ������� AO �������������޻���С��������ޣ����㷨�����Ӧ�Ľ����޷��� ���ֵѡ�� Sout ������Ϊ�����������ֵ�����ֵ����Сֵ��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double high = this.calcParams[ParamHigh].Value;
            double low = this.calcParams[ParamLow].Value;
            double sout = this.calcParams[ParamSout].Value;
            double ai = this.calcParams[InputAI].Value;
            double tr1 = this.calcParams[InputTR1].Value;
            double tr2 = this.calcParams[InputTR2].Value;
            double tr3 = this.calcParams[InputTR3].Value;
            double tr4 = this.calcParams[InputTR4].Value;
            double tr5 = this.calcParams[InputTR5].Value;
            double tr6 = this.calcParams[InputTR6].Value;
            double tr7 = this.calcParams[InputTR7].Value;
            double tr8 = this.calcParams[InputTR8].Value;
            double ts1 = this.calcParams[InputTS1].Value;
            double ts2 = this.calcParams[InputTS2].Value;
            double ts3 = this.calcParams[InputTS3].Value;
            double ts4 = this.calcParams[InputTS4].Value;
            double ts5 = this.calcParams[InputTS5].Value;
            double ts6 = this.calcParams[InputTS6].Value;
            double ts7 = this.calcParams[InputTS7].Value;
            double ts8 = this.calcParams[InputTS8].Value;
            //double ao =  this.calcResults[ResultAO].Value;
            //double do =  this.calcResults[ResultDO].Value;

        }

    }
}