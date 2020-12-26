using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 2 ����ƽ���㷨�飨2IB��2 INPUT BALANCE09e60
    /// </summary>
    public class PID2ib : PIDBindAlgorithm
    {
        ///<summary>
        /// �������
        /// </summary>
        public const string ParamYH = PIDAlgorithmToken.prefixParam + "YH";

        ///<summary>
        /// �������
        /// </summary>
        public const string ParamYL = PIDAlgorithmToken.prefixParam + "YL";

        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputX = PIDAlgorithmToken.prefixInput + "X";

        ///<summary>
        /// �����ź�
        /// </summary>
        public const string InputTR1 = PIDAlgorithmToken.prefixInput + "TR1";
        public const string InputTR2 = PIDAlgorithmToken.prefixInput + "TR2";

        ///<summary>
        /// ���ٿ���
        /// </summary>
        public const string InputTS1= PIDAlgorithmToken.prefixInput + "TS1";
        public const string InputTS2 = PIDAlgorithmToken.prefixInput + "TS2";

        ///<summary>
        /// ģ������� 1
        /// </summary>
        public const string ResultY1 = PIDAlgorithmToken.prefixResult + "Y1";

        ///<summary>
        /// ģ������� 2
        /// </summary>
        public const string ResultY2 = PIDAlgorithmToken.prefixResult + "Y2";


        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamYH] = new PIDAlgorithmVar(ParamYH, false, PIDVarDataType.Unknown);
            this.calcParams[ParamYL] = new PIDAlgorithmVar(ParamYL, false, PIDVarDataType.Unknown);
            this.calcParams[InputX] = new PIDAlgorithmVar(InputX, true, PIDVarDataType.DM);
            this.calcParams[InputTR1] = new PIDAlgorithmVar(InputTR1, true, PIDVarDataType.DM);
            this.calcParams[InputTR2] = new PIDAlgorithmVar(InputTR2, true, PIDVarDataType.DM);
            this.calcParams[InputTS1] = new PIDAlgorithmVar(InputTS1, true, PIDVarDataType.DM);
            this.calcParams[InputTS2] = new PIDAlgorithmVar(InputTS2, true, PIDVarDataType.DM);

        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultY1] = new PIDAlgorithmVar(ResultY1, false, PIDVarDataType.DM);
            this.calcResults[ResultY2] = new PIDAlgorithmVar(ResultY2, false, PIDVarDataType.DM);

        }

        /// <summary>
        ///4������˵��
        ///���㷨��������ĳ������������Ҫͬʱ��������ͬ���豸(�緢���ס��Ҳ������Һż ָ��)�ĳ��ϡ�
        ///5���㷨˵��
        ///������ݸ����ź� TS1��TS2 �Ĳ�ͬ�����������ν������ۣ� 1)TS1=1��TS2=1(����·ȫ���ڸ���״̬) ��ʱ���Ϊ��Y1=TR1	Y2=TR2
        ///2)TS1=0(1 ·�����Զ�)��TS2=1(2 ·���ڸ���) 
        /// ��ʱ���Ϊ��Y2=TR2	Y1=2X��Y2 3)TS1=1(1 ·���ڸ���)��
        /// TS2=0(2 ·�����Զ�) ��ʱ���Ϊ��Y1=TR1	Y2=2X��Y1 4)TS1=0��TS2=0(����·ȫ�����Զ�״̬) ��ʱ���Ϊ��Y1=X+BIAS   Y2=X��BIAS
        ///ģ������� Y1 �� Y2���������������� YH ����С��������� YL�����㷨�����Ӧ �Ľ����޷�����
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double yh = this.calcParams[ParamYH].Value;
            double yl = this.calcParams[ParamYL].Value;
            double x = this.calcParams[InputX].Value;
            double tr1 = this.calcParams[InputTR1].Value;
            double tr2 = this.calcParams[InputTR2].Value;
            double ts1 = this.calcParams[InputTS1].Value;
            double ts2 = this.calcParams[InputTS2].Value;
            double y1 = this.calcResults[ResultY1].Value;
            double y2 = this.calcResults[ResultY2].Value;
        } 
    }
}