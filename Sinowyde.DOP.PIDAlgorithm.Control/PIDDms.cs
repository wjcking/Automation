using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// �����ֶ�վ�㷨�飨DMS��Digital Man Station4eecd
    /// </summary>
    public class PIDDms : PIDBindAlgorithm
    {

        ///<summary>
        /// Man �ֶ�ֵ
        /// </summary>
        public const string ParamMO = PIDAlgorithmToken.prefixParam + "MO";

        ///<summary>
        /// ѡ�����Զ���ʽ
        /// </summary>
        public const string ParamMA = PIDAlgorithmToken.prefixParam + "MA";

        ///<summary>
        /// ���̱�������
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixInput + "PV";

        ///<summary>
        /// ��/�Զ��л������ź�(0������1����ֹ)
        /// </summary>
        public const string InputSI = PIDAlgorithmToken.prefixInput + "SI";

        ///<summary>
        /// ���������
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        ///<summary>
        /// ״ָ̬ʾ���(0���ֶ���1���Զ�)
        /// </summary>
        public const string ResultSO = PIDAlgorithmToken.prefixResult + "SO";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMO] = new PIDAlgorithmVar(ParamMO, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMA] = new PIDAlgorithmVar(ParamMA, false, PIDVarDataType.Unknown);
            this.calcParams[InputPV] = new PIDAlgorithmVar(InputPV, true, PIDVarDataType.DM);
            this.calcParams[InputSI] = new PIDAlgorithmVar(InputSI, true, PIDVarDataType.DM);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, false, PIDVarDataType.DM);
            this.calcResults[ResultSO] = new PIDAlgorithmVar(ResultSO, false, PIDVarDataType.DM);

        }
        /// <summary>
        /// 4������˵��
        ///�����ֶ�վģ���������Ա�������ڼ��л����Ʋ����е��߼��źš� ���Զ���ʽ�� DO ���� PV��
        ///���ֶ���ʽ�� DO �ɲ�����Աͨ���ֲ����ȷ����
        ///5���㷨˵��
        ///�Զ���DO=PV �ֶ���DO=MANOUT
        ///�������Զ�״̬��ʱ��SO Ϊ 1�� �������ֶ�״̬��ʱ��SO Ϊ 0�� ֻ����/�Զ��л������ź� SI Ϊ 0 ʱ���ſ��Խ����л��� SI Ϊ 1 ʱ��ֻ���ֶ�������
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double mo = this.calcParams[ParamMO].Value;
            double ma = this.calcParams[ParamMA].Value;
            double pv = this.calcParams[InputPV].Value; 
            //double do =  this.calcResults[ResultDO].Value;
            //double so =  ; 

            // ��/�Զ��л������ź�(0��  �ֶ���1�� �Զ�)
            if (this.calcParams[InputSI].Value == 1)
            {
                this.calcResults[ResultSO].Value = 0;
                this.calcResults[ResultDO].Value = pv;
            }
            else
            {
                this.calcResults[ResultSO].Value = 1;
                this.calcResults[ResultDO].Value = mo;
            }

        }
    }
}