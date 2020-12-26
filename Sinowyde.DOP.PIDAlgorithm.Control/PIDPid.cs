using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.1PID�����㷨��
    /// </summary>
    public class PIDPid : PIDBindAlgorithm
    {
        ///<summary>
        /// ������
        /// </summary>
        public const string ParamB = PIDAlgorithmToken.prefixParam + "B";

        ///<summary>
        /// ����ʱ�� =0 ʱ��ʾ�޻��� 
        /// </summary>
        public const string ParamTI = PIDAlgorithmToken.prefixParam + "TI";

        ///<summary>
        /// ΢��ʱ�� =0 ʱ��ʾ��΢�� 
        /// </summary>
        public const string ParamTD = PIDAlgorithmToken.prefixParam + "TD";

        ///<summary>
        /// ΢������
        /// </summary>
        public const string ParamKD = PIDAlgorithmToken.prefixParam + "KD";

        ///<summary>
        /// PV ����
        /// </summary>
        public const string ParamPVGain = PIDAlgorithmToken.prefixParam + "PVGain";

        ///<summary>
        /// PV ƫ��
        /// </summary>
        public const string ParamPVBias = PIDAlgorithmToken.prefixParam + "PVBias";

        ///<summary>
        /// SP ����
        /// </summary>
        public const string ParamSPGain = PIDAlgorithmToken.prefixParam + "SPGain";

        ///<summary>
        /// SP ƫ��
        /// </summary>
        public const string ParamSPBiao = PIDAlgorithmToken.prefixParam + "SPBiao";

        ///<summary>
        /// �����ʽ(����ʽ��λ��ʽ)
        /// </summary>
        public const string ParamOutMode = PIDAlgorithmToken.prefixParam + "OutMode";

        ///<summary>
        /// ��������(�����ã�������)
        /// </summary>
        public const string ParamDirect = PIDAlgorithmToken.prefixParam + "Direct";

        ///<summary>
        /// �����������
        /// </summary>
        public const string ParamHighRange = PIDAlgorithmToken.prefixParam + "HighRange";

        ///<summary>
        /// �����������
        /// </summary>
        public const string ParamLowRange = PIDAlgorithmToken.prefixParam + "LowRange";

        ///<summary>
        /// �������
        /// </summary>
        public const string ParamHighLmt = PIDAlgorithmToken.prefixParam + "HighLmt";

        ///<summary>
        /// �������
        /// </summary>
        public const string ParamLowLmt = PIDAlgorithmToken.prefixParam + "LowLmt";

        ///<summary>
        /// ƫ�����
        /// </summary>
        public const string ParamErrALM = PIDAlgorithmToken.prefixParam + "ErrALM";

        ///<summary>
        /// ����仯��
        /// </summary>
        public const string ParamOutRate = PIDAlgorithmToken.prefixParam + "OutRate";

        ///<summary>
        /// ���̱���
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixInput + "PV";

        ///<summary>
        /// �趨ֵ
        /// </summary>
        public const string InputSP = PIDAlgorithmToken.prefixInput + "SP";

        ///<summary>
        /// ǰ��ֵ
        /// </summary>
        public const string InputFF = PIDAlgorithmToken.prefixInput + "FF";

        ///<summary>
        /// ����ֵ
        /// </summary>
        public const string InputTR = PIDAlgorithmToken.prefixInput + "TR";

        ///<summary>
        /// KKP ��������
        /// </summary>
        public const string InputKKP = PIDAlgorithmToken.prefixInput + "KKP";

        ///<summary>
        /// KTI ��������
        /// </summary>
        public const string InputKTI = PIDAlgorithmToken.prefixInput + "KTI";

        ///<summary>
        /// KTD ΢������
        /// </summary>
        public const string InputKTD = PIDAlgorithmToken.prefixInput + "KTD";

        ///<summary>
        /// PID ����
        /// </summary>
        public const string InputPIDDB = PIDAlgorithmToken.prefixInput + "PIDDB";

        ///<summary>
        /// ���ٷ�ʽ 0���Զ���1������ 
        /// </summary>
        public const string InputSTR = PIDAlgorithmToken.prefixInput + "STR";

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
            this.calcParams[ParamB] = new PIDAlgorithmVar(ParamB, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamTI] = new PIDAlgorithmVar(ParamTI, false, PIDVarDataType.AM);
            this.calcParams[ParamTD] = new PIDAlgorithmVar(ParamTD, false, PIDVarDataType.AM);
            this.calcParams[ParamKD] = new PIDAlgorithmVar(ParamKD, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamPVGain] = new PIDAlgorithmVar(ParamPVGain, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamPVBias] = new PIDAlgorithmVar(ParamPVBias, false, PIDVarDataType.AM);
            this.calcParams[ParamSPGain] = new PIDAlgorithmVar(ParamSPGain, false, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[ParamSPBiao] = new PIDAlgorithmVar(ParamSPBiao, false, PIDVarDataType.AM);
            this.calcParams[ParamOutMode] = new PIDAlgorithmVar(ParamOutMode, false, PIDVarDataType.AM);
            this.calcParams[ParamDirect] = new PIDAlgorithmVar(ParamDirect, false, PIDVarDataType.AM);
            this.calcParams[ParamHighRange] = new PIDAlgorithmVar(ParamHighRange, false, PIDVarDataType.AM) { Value = 100 };
            this.calcParams[ParamLowRange] = new PIDAlgorithmVar(ParamLowRange, false, PIDVarDataType.AM);
            this.calcParams[ParamHighLmt] = new PIDAlgorithmVar(ParamHighLmt, false, PIDVarDataType.AM) { Value = 100 };
            this.calcParams[ParamLowLmt] = new PIDAlgorithmVar(ParamLowLmt, false, PIDVarDataType.AM);
            this.calcParams[ParamErrALM] = new PIDAlgorithmVar(ParamErrALM, false, PIDVarDataType.AM) { Value = 20 };
            this.calcParams[ParamOutRate] = new PIDAlgorithmVar(ParamOutRate, false, PIDVarDataType.AM) { Value = 5 };

            this.calcParams[InputPV] = new PIDAlgorithmVar(InputPV, true, PIDVarDataType.AM);
            this.calcParams[InputSP] = new PIDAlgorithmVar(InputSP, true, PIDVarDataType.AM);
            this.calcParams[InputFF] = new PIDAlgorithmVar(InputFF, true, PIDVarDataType.AM);
            this.calcParams[InputTR] = new PIDAlgorithmVar(InputTR, true, PIDVarDataType.AM);
            this.calcParams[InputKKP] = new PIDAlgorithmVar(InputKKP, true, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[InputKTI] = new PIDAlgorithmVar(InputKTI, true, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[InputKTD] = new PIDAlgorithmVar(InputKTD, true, PIDVarDataType.AM) { Value = 1 };
            this.calcParams[InputPIDDB] = new PIDAlgorithmVar(InputPIDDB, true, PIDVarDataType.AM);
            this.calcParams[InputSTR] = new PIDAlgorithmVar(InputSTR, true, PIDVarDataType.DM) { Value = 1 };//0-�Զ�;1-����
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, true, PIDVarDataType.AM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, true, PIDVarDataType.DM);
        }

        /// <summary>
        ///4������˵��
        ///���㷨������ɳ��� PID �����㷨���ж��ֹ���״̬���ֶ����Զ������٣���Щ״̬ ����л������ŵġ�����ǰ������������ˣ����Խ��б���������ڣ������ֱ��ͣ������� ƽ�⣬����ֵ��ƫ�����
        ///PV ����� PV ƫ�ã��Թ��̱��� PV ���б�ȱ任��ʹ PV ���� 0~100%��Χ�ڡ� 
        ///SP ����� SP ƫ�ã����趨ֵ SP ���б�ȱ任��ʹ SP ���� 0~100%��Χ�ڡ�
        ///5���㷨˵�� 
        ///���Զ�ʱ��Y(s)�� �ڸ���ʱ��Y(s) = TR(s)
        ///Ȼ�󣬽� Y ������ HighRange �� LowRange ֮�䡣 �����ܿ��������������ƵĹ��ܣ���� Y �ı仯�ʱ�����������仯�� OutRate ���ڡ� ������ƫ���ʱ��DO ���Ϊ 1����ƫ��������DO ���Ϊ 0��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double b = this.calcParams[ParamB].Value;
            double ti = this.calcParams[ParamTI].Value;
            double td = this.calcParams[ParamTD].Value;
            double kd = this.calcParams[ParamKD].Value;
            double pvgain = this.calcParams[ParamPVGain].Value;
            double pvbias = this.calcParams[ParamPVBias].Value;
            double spgain = this.calcParams[ParamSPGain].Value;
            double spbiao = this.calcParams[ParamSPBiao].Value;
            double outmode = this.calcParams[ParamOutMode].Value;
            double direct = this.calcParams[ParamDirect].Value;
            double highRange = this.calcParams[ParamHighRange].Value;
            double lowRange = this.calcParams[ParamLowRange].Value;
            double highlmt = this.calcParams[ParamHighLmt].Value;
            double lowlmt = this.calcParams[ParamLowLmt].Value;
            double erralm = this.calcParams[ParamErrALM].Value;
            double outRate = this.calcParams[ParamOutRate].Value;
            double pv = this.calcParams[InputPV].Value;
            double sp = this.calcParams[InputSP].Value;
            double ff = this.calcParams[InputFF].Value;
            double tr = this.calcParams[InputTR].Value;
            double kkp = this.calcParams[InputKKP].Value;
            double kti = this.calcParams[InputKTI].Value;
            double ktd = this.calcParams[InputKTD].Value;
            double piddb = this.calcParams[InputPIDDB].Value;

            var s = GetDt();
            double y = 0;
            if (ConvertUtil.ConvertToInt(calcParams[InputSTR].Value).Equals(0))//�Զ�
            {
                y = kkp / b + kti / (ti * s) + (kd * ktd * td * s) / (td * s + 1);
            }
            else//�ֶ�
            {
                y = tr * s;
            }



            if (y < lowRange)
                y = lowRange;

            if (y > highRange)
                y = highRange;

            //y�ı仯��
            if (y <= outRate)
            {

            }

        }
    }
}