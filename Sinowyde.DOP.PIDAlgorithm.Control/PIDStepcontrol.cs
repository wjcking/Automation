    
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.10��������㷨��
    /// </summary>
    public class PIDStepcontrol : PIDBindAlgorithm
    {
        ///<summary>
        /// �������1 С�� MAXS С��8
        /// </summary>
        public const string ParamMAXS = PIDAlgorithmToken.prefixParam + "MAXS";

        ///<summary>
        /// �� n ���趨ʱ�䣬������ִ��ʱ��ﵽ��ʱ��ʱ�� ������Ӧ�ķ� ��Ϊ 1 ���Զ� ת����һ��ִ �С� SetTime ���벻С�� 0��
        /// </summary>
        public const string ParamSetTime1 = PIDAlgorithmToken.prefixParam + "SetTime1";
        public const string ParamSetTime2 = PIDAlgorithmToken.prefixParam + "SetTime2";
        public const string ParamSetTime3 = PIDAlgorithmToken.prefixParam + "SetTime3";
        public const string ParamSetTime4 = PIDAlgorithmToken.prefixParam + "SetTime4";
        public const string ParamSetTime5 = PIDAlgorithmToken.prefixParam + "SetTime5";
        public const string ParamSetTime6 = PIDAlgorithmToken.prefixParam + "SetTime6";
        public const string ParamSetTime7 = PIDAlgorithmToken.prefixParam + "SetTime7";
        public const string ParamSetTime8 = PIDAlgorithmToken.prefixParam + "SetTime8";

        ///<summary>
        /// �� n ���޶�ʱ�䣬������ִ��ʱ�䳬����ʱ��ʱ��
        ///��Ӧ�ķ�����û�е����������źŷ��������� �߼�����ͣ������������Ť���������¼�ʱִ�У��� Tlimit n=0 ʱ���ù��ܱ���ֹ��Tlmit ���벻С�� 0��
        /// </summary>
        public const string ParamTlimit1 = PIDAlgorithmToken.prefixParam + "Tlimit1";
        public const string ParamTlimit2 = PIDAlgorithmToken.prefixParam + "Tlimit2";
        public const string ParamTlimit3 = PIDAlgorithmToken.prefixParam + "Tlimit3";
        public const string ParamTlimit4 = PIDAlgorithmToken.prefixParam + "Tlimit4";
        public const string ParamTlimit5 = PIDAlgorithmToken.prefixParam + "Tlimit5";
        public const string ParamTlimit6 = PIDAlgorithmToken.prefixParam + "Tlimit6";
        public const string ParamTlimit7 = PIDAlgorithmToken.prefixParam + "Tlimit7";
        public const string ParamTlimit8 = PIDAlgorithmToken.prefixParam + "Tlimit8";

        ///<summary>
        /// Ԥ�ò����� 0С��TmodeС��MAXS ʱ����������ť����
        ///Ԥ�ò���ʼִ�С�
        /// </summary>
        public const string InputTmode = PIDAlgorithmToken.prefixInput + "Tmode";

        ///<summary>
        /// ��λ��ֹ������� 8 λ b0-b7 ��Ӧ Step1-Step8��
        ///Ϊ 1 ʱ��ֹ��������Ӧ�Ĳ���
        /// </summary>
        public const string InputBitDis = PIDAlgorithmToken.prefixInput + "BitDis";

        ///<summary>
        /// �����߼������ź�
        /// </summary>
        public const string InputStart = PIDAlgorithmToken.prefixInput + "Start";

        ///<summary>
        /// ������ͣ�źţ������߼�����ͣ���ٰ�������ť��
        ///����Ӷϵ㿪ʼ����ִ�С�
        /// </summary>
        public const string InputStop = PIDAlgorithmToken.prefixInput + "Stop";

        ///<summary>
        /// ������ʱ��Ϊ 1 ʱͣ���ڵ�ǰ����
        /// </summary>
        public const string InputDelay = PIDAlgorithmToken.prefixInput + "Delay";

        ///<summary>
        /// �� n ��������ɣ��� n �����������źŻ�� n+1 �� ���������źš�
        /// </summary>
        public const string InputFB1 = PIDAlgorithmToken.prefixInput + "FB1";
        public const string InputFB2 = PIDAlgorithmToken.prefixInput + "FB2";
        public const string InputFB3 = PIDAlgorithmToken.prefixInput + "FB3";
        public const string InputFB4 = PIDAlgorithmToken.prefixInput + "FB4";
        public const string InputFB5 = PIDAlgorithmToken.prefixInput + "FB5";
        public const string InputFB6 = PIDAlgorithmToken.prefixInput + "FB6";
        public const string InputFB7 = PIDAlgorithmToken.prefixInput + "FB7";
        public const string InputFB8 = PIDAlgorithmToken.prefixInput + "FB8";
                                     
        ///<summary>
        /// ��λ�������߼�������
        /// </summary>
        public const string InputRst = PIDAlgorithmToken.prefixInput + "Rst";

        ///<summary>
        /// ������ʽ��������ִֻ��һ����
        /// </summary>
        public const string InputDStep = PIDAlgorithmToken.prefixInput + "DStep";

        ///<summary>
        /// ������������ǰ��ִ����һ���������ǰ��Ϊ��� ���������߼�������
        /// </summary>
        public const string InputJStep = PIDAlgorithmToken.prefixInput + "JStep";

        ///<summary>
        /// ��ǰ�����������ִ�еĲ����
        /// </summary>
        public const string ResultStep = PIDAlgorithmToken.prefixResult + "Step";

        ///<summary>
        /// �������ʱ�䣬������ڽ��еĲ����ѽ��е�ʱ�䡣
        /// </summary>
        public const string ResultTrun = PIDAlgorithmToken.prefixResult + "Trun";

        ///<summary>
        /// ����ʣ��ʱ�䣬������ڽ��еĲ���ʣ���ʱ�䡣
        /// </summary>
        public const string ResultTrst = PIDAlgorithmToken.prefixResult + "Trst";

        ///<summary>
        /// ������У������߼����ڽ���ʱ����� 1��
        /// </summary>
        public const string ResultRun = PIDAlgorithmToken.prefixResult + "Run";

        ///<summary>
        /// �����ⲽ��ʱ���߲�����ͣ����� 1��
        /// </summary>
        public const string ResultFail = PIDAlgorithmToken.prefixResult + "Fail";

        ///<summary>
        /// ������ɣ�������ɹ�����趨���������ߵ�8 ��ʱ����� 1��
        /// </summary>
        public const string ResultEnd = PIDAlgorithmToken.prefixResult + "End";

        ///<summary>
        /// �� n ��ָ��� n ��ָ����ЧʱΪ 1��
        /// </summary>
        public const string ResultSTEP1  = PIDAlgorithmToken.prefixResult + "STEP1";
        public const string ResultSTEP2  = PIDAlgorithmToken.prefixResult + "STEP2";
        public const string ResultSTEP3  = PIDAlgorithmToken.prefixResult + "STEP3";
        public const string ResultSTEP4  = PIDAlgorithmToken.prefixResult + "STEP4";
        public const string ResultSTEP5  = PIDAlgorithmToken.prefixResult + "STEP5";
        public const string ResultSTEP6  = PIDAlgorithmToken.prefixResult + "STEP6";
        public const string ResultSTEP7 =  PIDAlgorithmToken.prefixResult + "STEP7";
        public const string ResultSTEP8  = PIDAlgorithmToken.prefixResult + "STEP8";


        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMAXS] = new PIDAlgorithmVar(ParamMAXS, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime1] = new PIDAlgorithmVar(ParamSetTime1, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime2] = new PIDAlgorithmVar(ParamSetTime2, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime3] = new PIDAlgorithmVar(ParamSetTime3, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime4] = new PIDAlgorithmVar(ParamSetTime4, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime5] = new PIDAlgorithmVar(ParamSetTime5, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime6] = new PIDAlgorithmVar(ParamSetTime6, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime7] = new PIDAlgorithmVar(ParamSetTime7, false, PIDVarDataType.Unknown);
            this.calcParams[ParamSetTime8] = new PIDAlgorithmVar(ParamSetTime8, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit1] = new PIDAlgorithmVar(ParamTlimit1, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit2] = new PIDAlgorithmVar(ParamTlimit2, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit3] = new PIDAlgorithmVar(ParamTlimit3, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit4] = new PIDAlgorithmVar(ParamTlimit4, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit5] = new PIDAlgorithmVar(ParamTlimit5, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit6] = new PIDAlgorithmVar(ParamTlimit6, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit7] = new PIDAlgorithmVar(ParamTlimit7, false, PIDVarDataType.Unknown);
            this.calcParams[ParamTlimit8] = new PIDAlgorithmVar(ParamTlimit8, false, PIDVarDataType.Unknown);
            this.calcParams[InputTmode] = new PIDAlgorithmVar(InputTmode, true, PIDVarDataType.DM);
            this.calcParams[InputBitDis] = new PIDAlgorithmVar(InputBitDis, true, PIDVarDataType.DM);
            this.calcParams[InputStart] = new PIDAlgorithmVar(InputStart, true, PIDVarDataType.DM);
            this.calcParams[InputStop] = new PIDAlgorithmVar(InputStop, true, PIDVarDataType.DM);
            this.calcParams[InputDelay] = new PIDAlgorithmVar(InputDelay, true, PIDVarDataType.DM);
            this.calcParams[InputFB1] = new PIDAlgorithmVar(InputFB1, true, PIDVarDataType.DM);
            this.calcParams[InputFB2] = new PIDAlgorithmVar(InputFB2, true, PIDVarDataType.DM);
            this.calcParams[InputFB3] = new PIDAlgorithmVar(InputFB3, true, PIDVarDataType.DM);
            this.calcParams[InputFB4] = new PIDAlgorithmVar(InputFB4, true, PIDVarDataType.DM);
            this.calcParams[InputFB5] = new PIDAlgorithmVar(InputFB5, true, PIDVarDataType.DM);
            this.calcParams[InputFB6] = new PIDAlgorithmVar(InputFB6, true, PIDVarDataType.DM);
            this.calcParams[InputFB7] = new PIDAlgorithmVar(InputFB7, true, PIDVarDataType.DM);
            this.calcParams[InputFB8] = new PIDAlgorithmVar(InputFB8, true, PIDVarDataType.DM);
            this.calcParams[InputRst] = new PIDAlgorithmVar(InputRst, true, PIDVarDataType.DM);
            this.calcParams[InputDStep] = new PIDAlgorithmVar(InputDStep, true, PIDVarDataType.DM);
            this.calcParams[InputJStep] = new PIDAlgorithmVar(InputJStep, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultStep] = new PIDAlgorithmVar(ResultStep, false, PIDVarDataType.DM);
            this.calcResults[ResultTrun] = new PIDAlgorithmVar(ResultTrun, false, PIDVarDataType.DM);
            this.calcResults[ResultTrst] = new PIDAlgorithmVar(ResultTrst, false, PIDVarDataType.DM);
            this.calcResults[ResultRun] = new PIDAlgorithmVar(ResultRun, false, PIDVarDataType.DM);
            this.calcResults[ResultFail] = new PIDAlgorithmVar(ResultFail, false, PIDVarDataType.DM);
            this.calcResults[ResultEnd] = new PIDAlgorithmVar(ResultEnd, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP1] = new PIDAlgorithmVar(ResultSTEP1, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP2] = new PIDAlgorithmVar(ResultSTEP2, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP3] = new PIDAlgorithmVar(ResultSTEP3, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP4] = new PIDAlgorithmVar(ResultSTEP4, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP5] = new PIDAlgorithmVar(ResultSTEP5, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP6] = new PIDAlgorithmVar(ResultSTEP6, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP7] = new PIDAlgorithmVar(ResultSTEP7, false, PIDVarDataType.DM);
            this.calcResults[ResultSTEP8] = new PIDAlgorithmVar(ResultSTEP8, false, PIDVarDataType.DM);

        } 
           
 
        /// <summary>
        /// 4������˵��
        ///�����߼��㷨�ṩ�����鼶˳���߼��ı�׼ʵ�ַ����� �����߼��㷨�ɽ����ϼ�˳���߼���������Ա������ָ�������Ӧ�豸��Ϊ˳�ط�ʽ��
        ///�����ִ�м������������ģ�ͬʱ������ʱ���ġ���ǰ���Ĳ����ɹ�(�����źŵ�� �����źŵ���ﵽ�趨ʱ��)�󣬳����Զ�������һ��������ֹ��ϲ���һ����ʱ���ӳ� ��δ��ʧ��ﵽ�����趨ʱ�������δ��ɣ������߼�����ֹ����˳���߼������������� Ա����������ʱ���˹���ֹ���򣬻�ѡ���������ò����������ò������������豸��ȫ���� �²ű�ִ�С�
        ///ÿ�������߼��㷨����ɲ������������豸�Զ������߼�������ͨ��������������߼� �����ʵ�ָ����ӵ�˳������߼���
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double maxs = this.calcParams[ParamMAXS].Value;
            double settime1 = this.calcParams[ParamSetTime1].Value;
            double settime2 = this.calcParams[ParamSetTime2].Value;
            double settime3 = this.calcParams[ParamSetTime3].Value;
            double settime4 = this.calcParams[ParamSetTime4].Value;
            double settime5 = this.calcParams[ParamSetTime5].Value;
            double settime6 = this.calcParams[ParamSetTime6].Value;
            double settime7 = this.calcParams[ParamSetTime7].Value;
            double settime8 = this.calcParams[ParamSetTime8].Value;
            double tlimit1 = this.calcParams[ParamTlimit1].Value;
            double tlimit2 = this.calcParams[ParamTlimit2].Value;
            double tlimit3 = this.calcParams[ParamTlimit3].Value;
            double tlimit4 = this.calcParams[ParamTlimit4].Value;
            double tlimit5 = this.calcParams[ParamTlimit5].Value;
            double tlimit6 = this.calcParams[ParamTlimit6].Value;
            double tlimit7 = this.calcParams[ParamTlimit7].Value;
            double tlimit8 = this.calcParams[ParamTlimit8].Value;
            double tmode = this.calcParams[InputTmode].Value;
            double bitdis = this.calcParams[InputBitDis].Value;
            double start = this.calcParams[InputStart].Value;
            double stop = this.calcParams[InputStop].Value;
            double delay = this.calcParams[InputDelay].Value;
            double fb1 = this.calcParams[InputFB1].Value;
            double fb2 = this.calcParams[InputFB2].Value;
            double fb3 = this.calcParams[InputFB3].Value;
            double fb4 = this.calcParams[InputFB4].Value;
            double fb5 = this.calcParams[InputFB5].Value;
            double fb6 = this.calcParams[InputFB6].Value;
            double fb7 = this.calcParams[InputFB7].Value;
            double fb8 = this.calcParams[InputFB8].Value;
            double rst = this.calcParams[InputRst].Value;
            double dstep = this.calcParams[InputDStep].Value;
            double jstep = this.calcParams[InputJStep].Value;
            //double step = this.calcResults[ResultStep].Value;
            //double trun = this.calcResults[ResultTrun].Value;
            //double trst = this.calcResults[ResultTrst].Value;
            //double run = this.calcResults[ResultRun].Value;
            //double fail = this.calcResults[ResultFail].Value;
            //double end = this.calcResults[ResultEnd].Value;
            //double step1 = this.calcResults[ResultSTEP1].Value;
            //double step2 = this.calcResults[ResultSTEP2].Value;
            //double step3 = this.calcResults[ResultSTEP3].Value;
            //double step4 = this.calcResults[ResultSTEP4].Value;
            //double step5 = this.calcResults[ResultSTEP5].Value;
            //double step6 = this.calcResults[ResultSTEP6].Value;
            //double step7 = this.calcResults[ResultSTEP7].Value;
            //double step8 = this.calcResults[ResultSTEP8].Value;
        }
    }
}