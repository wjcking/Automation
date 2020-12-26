
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// ��ʱ���Ż��㷨�飨TEX��Timer3765d
    /// </summary>
    public class PIDTex : PIDBindAlgorithm
    {

        /// <summary>
        ///  ��ʱʱ�䣨��λ���룩
        /// </summary>
        public const string ParamEndTime = PIDAlgorithmToken.prefixParam + "EndTime";
        /// <summary>
        /// ������ʽ Int
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";
        /// <summary>
        /// ���붨ʱֵ  
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixParam + "PV";
        /// <summary>
        /// ��ʼ�����ź� Bool
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixParam + "SET";
        /// <summary>
        /// ��λ�ź� RESET Bool
        /// </summary>
        public const string InputRS = PIDAlgorithmToken.prefixParam + "RS";
        /// <summary>
        /// ��ǰ��ʱʱ��ֵ Double
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixParam + "AO";
        /// <summary>
        /// ��ʱ��������� Bool
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixParam + "DO";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamEndTime] = new PIDAlgorithmParam(ParamEndTime);
            this.calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputPV] = new PIDAlgorithmVar(InputPV,  PIDVarDataType.DM);
            this.calcInputs[InputSET] = new PIDAlgorithmVar(InputSET, PIDVarDataType.DM);
            this.calcInputs[InputRS] = new PIDAlgorithmVar(InputRS, PIDVarDataType.DM);
        }

        protected override bool IsValidParam(string param, object value)
        {
            return false;
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }
        /// <summary>
        ///4������˵��
        ///��ɶ�ʱ���������巢�������ͺ���λ���ͺ�λ���ͺ�λ���ֵȹ��ܡ�
        ///5���㷨˵��
        ///ͬ��ʱ���㷨��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            //���㷨���ͬ PidT
        }
    }
}