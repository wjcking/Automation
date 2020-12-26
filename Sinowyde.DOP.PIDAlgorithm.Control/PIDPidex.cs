using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.2 PID�Ż��㷨��
    /// </summary>
    [Serializable]
    public class PIDPidex : PIDBindAlgorithm
    {
        #region ����

        ///<summary>
        /// ������
        /// </summary>
        public const string ParamKP = PIDAlgorithmToken.prefixParam + "KP";

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
        public const string ParamSPBias = PIDAlgorithmToken.prefixParam + "SPBias";

        ///<summary>
        /// �����ʽ(����ʽ��λ��ʽ)
        /// </summary>
        public const string ParamOutMode = PIDAlgorithmToken.prefixParam + "OutMode";

        ///<summary>
        /// ��������(�����ã�������)
        /// </summary>
        public const string ParamDirect = PIDAlgorithmToken.prefixParam + "Direct";

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
        /// ���ٷ�ʽ(0���Զ���1������)
        /// </summary>
        public const string InputSTR = PIDAlgorithmToken.prefixInput + "STR";

        ///<summary>
        /// ������
        /// </summary>
        public const string InputIL = PIDAlgorithmToken.prefixInput + "IL";

        ///<summary>
        /// ������
        /// </summary>
        public const string InputDL = PIDAlgorithmToken.prefixInput + "DL";

        ///<summary>
        /// ģ�������
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        ///<summary>
        /// ���������
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region �м����

        private double err_1 = 0;
        private double ud_1 = 0;
        private double midVal_1 = 0;
        private double ff_1 = 0;

        #endregion

        protected override void InitCalcParams()
        {
            calcParams[ParamKP] = new PIDAlgorithmParam(ParamKP, 1);
            calcParams[ParamTI] = new PIDAlgorithmParam(ParamTI);
            calcParams[ParamTD] = new PIDAlgorithmParam(ParamTD);
            calcParams[ParamKD] = new PIDAlgorithmParam(ParamKD, 1);
            calcParams[ParamPVGain] = new PIDAlgorithmParam(ParamPVGain, 1);
            calcParams[ParamPVBias] = new PIDAlgorithmParam(ParamPVBias);
            calcParams[ParamSPGain] = new PIDAlgorithmParam(ParamSPGain, 1);
            calcParams[ParamSPBias] = new PIDAlgorithmParam(ParamSPBias);
            calcParams[ParamOutMode] = new PIDAlgorithmParam(ParamOutMode, 1); //0����ʽ,1λ��ʽ
            calcParams[ParamDirect] = new PIDAlgorithmParam(ParamDirect, 1);//0������,1������
            //calcParams[ParamHighRange] = new PIDAlgorithmParam(ParamHighRange, 100);
            //calcParams[ParamLowRange] = new PIDAlgorithmParam(ParamLowRange);
            calcParams[ParamHighLmt] = new PIDAlgorithmParam(ParamHighLmt, 100);
            calcParams[ParamLowLmt] = new PIDAlgorithmParam(ParamLowLmt);
            calcParams[ParamErrALM] = new PIDAlgorithmParam(ParamErrALM, 20);
            calcParams[ParamOutRate] = new PIDAlgorithmParam(ParamOutRate, 5);
        }

        protected override void InitCalcInputs()
        {
            calcInputs[InputPV] = new PIDAlgorithmVar(InputPV, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputSP] = new PIDAlgorithmVar(InputSP, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputFF] = new PIDAlgorithmVar(InputFF, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputTR] = new PIDAlgorithmVar(InputTR, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputKKP] = new PIDAlgorithmVar(InputKKP, 1, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputKTI] = new PIDAlgorithmVar(InputKTI, 1, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputKTD] = new PIDAlgorithmVar(InputKTD, 1, PIDVarInputType.Init, PIDVarDataType.AM);
            //calcInputs[InputKKD] = new PIDAlgorithmVar(InputKKD, 1);
            calcInputs[InputPIDDB] = new PIDAlgorithmVar(InputPIDDB, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputSTR] = new PIDAlgorithmVar(InputSTR, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputIL] = new PIDAlgorithmVar(InputIL, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputDL] = new PIDAlgorithmVar(InputDL, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        protected override void ResetEnvVars()
        {
            err_1 = 0;
            ud_1 = 0;
            midVal_1 = 0;
            ff_1 = 0;

            base.ResetEnvVars();
        }

        protected override void InternalDoCalc()
        {
            var kp = calcParams[ParamKP].Value;
            var ti = calcParams[ParamTI].Value;
            var td = calcParams[ParamTD].Value;
            var kd = calcParams[ParamKD].Value;

            var pvGain = calcParams[ParamPVGain].Value;
            var pvBias = calcParams[ParamPVBias].Value;
            var spGain = calcParams[ParamSPGain].Value;
            var spBias = calcParams[ParamSPBias].Value;
            var outMode = calcParams[ParamOutMode].Value;
            var direct = calcParams[ParamDirect].Value;
            var highLmt = calcParams[ParamHighLmt].Value;
            var lowLmt = calcParams[ParamLowLmt].Value;
            var errAlm = calcParams[ParamErrALM].Value;
            var outRate = calcParams[ParamOutRate].Value;

            var pv = calcInputs[InputPV].Value;
            var sp = calcInputs[InputSP].Value;
            var ff = calcInputs[InputFF].Value;
            var tr = calcInputs[InputTR].Value;
            var kkp = calcInputs[InputKKP].Value;
            var kti = calcInputs[InputKTI].Value;
            var ktd = calcInputs[InputKTD].Value;
            var piddb = calcInputs[InputPIDDB].Value;
            var str = calcInputs[InputSTR].Value;
            var il = calcInputs[InputIL].Value;
            var dl = calcInputs[InputDL].Value;

            if (LastCalcTime == DateTime.MinValue)
            {
                calcResults[ResultAO].Value = 0;
                calcResults[ResultDO].Value = 0;
                return;
            }


            double kpReciprocal = 1 / kp;//kp�ĵ���
            pv = MathEx.GainAndBias(pv, pvGain, pvBias);//����,ƫ��
            sp = MathEx.GainAndBias(sp, spGain, spBias);//����,ƫ��
            double err = ConvertUtil.ConvertToInt(direct).Equals(0) ? pv - sp : sp - pv;//0������,1������

            var dt = GetDt();

            double y_1 = calcResults[ResultAO].Value;
            double y = 0;
            double ud = 0;
            double midVal = 0;

            if (ConvertUtil.ConvertToInt(str).Equals(1))//����
            {
                y = tr;
            }
            else//�Զ�
            {
                #region �Զ�

                double proportion = kp.Equals(0) ? 0 : (err - err_1) * kpReciprocal * kkp;//����
                double integ = ti.Equals(0) ? 0 : (dt * kpReciprocal / ti) * err * kti;//����
                double diff = 0;
                if (td.Equals(0))
                {
                    midVal = 0;
                    ud = 0;
                    diff = 0;//΢��
                }
                else
                {
                    double temp = Math.Exp((dt * -1) / td);
                    midVal = temp * midVal_1 - kpReciprocal * kd * ktd * (1 - temp) * err;
                    ud = kpReciprocal * kd * ktd * err + midVal;
                    diff = ud - ud_1;//΢��
                }
                double delta = Math.Abs(err) <= piddb ? 0 : proportion + integ + diff;

                if (ConvertUtil.ConvertToInt(outMode).Equals((int)PidOutMode.Increment))/*��Ϊ����ʽ�������Ϊ����*/
                    y = delta;
                else
                    y = y_1 + delta + (ff - ff_1);

                y = MathEx.ILandDL(y_1, y, il, dl);//��������

                #endregion
            }

            y = MathEx.OutRate(y_1, y, outRate, GetDt());//����仯������
            y = MathEx.InRange(y, lowLmt, highLmt);//����������

            //���긳ֵ
            err_1 = err;
            ud_1 = ud;
            midVal_1 = midVal;
            ff_1 = ff;

            calcResults[ResultAO].Value = y;
            calcResults[ResultDO].Value = err >= Math.Abs(errAlm) ? 1 : 0;//ƫ���
        }

        public override string AlgName
        {
            get { return "PID�Ż��㷨��"; }
        }
    }
}