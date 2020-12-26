
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 6.5ϵͳ��ǰʱ�书�ܿ� ��SCT��6e03c
    /// </summary>
    [Serializable]
    public class PIDSct : PIDBindAlgorithm
    {
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ResultYear = PIDAlgorithmToken.prefixResult + "Year";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ResultMonth = PIDAlgorithmToken.prefixResult + "Month";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ResultDay = PIDAlgorithmToken.prefixResult + "Day";
        ///<summary>
        /// ʱ��ʾ��
        /// </summary>
        public const string ResultHour = PIDAlgorithmToken.prefixResult + "Hour";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ResultMinute = PIDAlgorithmToken.prefixResult + "Minute";
        ///<summary>
        /// ����ʾ��
        /// </summary>
        public const string ResultScend = PIDAlgorithmToken.prefixResult + "Second";

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultYear] = new PIDAlgorithmVar(ResultYear, PIDVarDataType.AM);
            this.calcResults[ResultMonth] = new PIDAlgorithmVar(ResultMonth, PIDVarDataType.AM);
            this.calcResults[ResultDay] = new PIDAlgorithmVar(ResultDay, PIDVarDataType.AM);
            this.calcResults[ResultHour] = new PIDAlgorithmVar(ResultHour, PIDVarDataType.AM);
            this.calcResults[ResultMinute] = new PIDAlgorithmVar(ResultMinute, PIDVarDataType.AM);
            this.calcResults[ResultScend] = new PIDAlgorithmVar(ResultScend, PIDVarDataType.AM);
        }
        /// <summary>
        ///4������˵��
        ///��ʾϵͳ��ǰ�ꡢ�¡��ա�ʱ���֡������ʵʱֵ
        ///5���㷨˵�� ��ȡϵͳ��ǰʱ��
        /// </summary>  
        protected override void InternalDoCalc()
        {
            DateTime current = DateTime.Now;
            this.calcResults[ResultYear].Value = current.Year;
            this.calcResults[ResultMonth].Value = current.Month;
            this.calcResults[ResultDay].Value = current.Day;
            this.calcResults[ResultHour].Value = current.Hour;
            this.calcResults[ResultMinute].Value = current.Minute;
            this.calcResults[ResultScend].Value = current.Second;
        }

        public override string AlgName
        {
            get { return "ϵͳ��ǰʱ�书�ܿ�"; }
        }
    }
}