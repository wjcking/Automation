
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// ���ڶ�ʱ���㷨�飨Cycle�� Timer2fddb
    /// </summary>
    public class PIDCycle : PIDBindAlgorithm
    {
        ///<summary>
        /// ��ʼ�����ź�
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixParam + "SET";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ParamMonth = PIDAlgorithmToken.prefixParam + "Month";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ParamDay = PIDAlgorithmToken.prefixParam + "Day";
        ///<summary>
        /// ʱ��ʾ��
        /// </summary>
        public const string ParamHour = PIDAlgorithmToken.prefixParam + "Hour";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ParamMinute = PIDAlgorithmToken.prefixParam + "Minute";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ParamScend = PIDAlgorithmToken.prefixParam + "Scend";
        ///<summary>
        /// ��ʱ���������
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMonth] =  new PIDAlgorithmParam(ParamMonth, -1);
            this.calcParams[ParamDay] = new PIDAlgorithmParam(ParamDay, -1);
            this.calcParams[ParamHour] = new PIDAlgorithmParam(ParamHour, -1);
            this.calcParams[ParamMinute] = new PIDAlgorithmParam(ParamMinute, -1);
            this.calcParams[ParamScend] = new PIDAlgorithmParam(ParamScend, 1);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputSET] = new PIDAlgorithmVar(InputSET, PIDVarDataType.DM);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, 1, PIDVarInputType. PIDVarDataType.DM);
        }

        /// <summary>
        ///4������˵��
        ///�����ܿ�Խ���ǰʱ�����趨ʱ��Ƚϣ��״δﵽ�򳬹��趨ʱ��ʱ�����һ�������壬
        ///���Ϊ�������ڡ�
        ///���ĳλ��ֵ����Ϊ��1�����ʾ��λ�������á�
        ///��� Sec ����Ϊ��1�� ��ÿ�� Min �� Sec ʱ�̻����һ�������壻��� Hour ����Ϊ��1��
        ///��ÿ�� Hour �� Min:Sec ʱ�̻����һ�������壻��� Day ����Ϊ��1����ÿ��� Hour:Min:Sec
        ///ʱ�̻����һ�������壻�Դ����ƣ��ɶ��嵽����Ϊ���ڵĶ�ʱ��
        ///������ Sec ����ȡ��1��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double month = this.calcParams[ParamMonth].Value;
            double day = this.calcParams[ParamDay].Value;
            double hour = this.calcParams[ParamHour].Value;
            double minute = this.calcParams[ParamMinute].Value;
            double sec = this.calcParams[ParamScend].Value;

            //�벻��Ϊ-1��
            if (sec < 0)
                sec=1;

            if (minute < 0 && hour < 0 && day < 0 && month < 0)
            {
                if (DateTime.Now.Minute >= minute && DateTime.Now.Second >= sec)
                    calcResults[ResultDO].Value = 1;
            }
            else if (minute > 0 && hour < 0 && day < 0 && month < 0)
            {
                if (DateTime.Now.Minute >= minute && DateTime.Now.Second >= sec)
                    calcResults[ResultDO].Value = 1;
            }
            else if (minute > 0 && hour > 0 && day < 0 && month < 0)
            {
                if (DateTime.Now.Hour >= hour && DateTime.Now.Minute >= minute && DateTime.Now.Second >= sec)
                    calcResults[ResultDO].Value = 1;
            }
            else if (minute > 0 && hour > 0 && day > 0 && month < 0)
            {
                if (DateTime.Now.Day >= day && DateTime.Now.Hour >= hour && DateTime.Now.Minute >= minute && DateTime.Now.Second >= sec)
                    calcResults[ResultDO].Value = 1;
            }
            else if (minute > 0 && hour > 0 && day > 0 && month > 0)
            {
                if (DateTime.Now.Day >= day
                    && DateTime.Now.Hour >= hour
                    && DateTime.Now.Minute >= minute
                    && DateTime.Now.Second >= sec)
                    calcResults[ResultDO].Value = 1;
            }
            else
                calcResults[ResultDO].Value = 0;
        }
    }
    
}