
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 6.5系统当前时间功能块 （SCT）6e03c
    /// </summary>
    [Serializable]
    public class PIDSct : PIDBindAlgorithm
    {
        ///<summary>
        /// 年显示项
        /// </summary>
        public const string ResultYear = PIDAlgorithmToken.prefixResult + "Year";
        ///<summary>
        /// 月显示项
        /// </summary>
        public const string ResultMonth = PIDAlgorithmToken.prefixResult + "Month";
        ///<summary>
        /// 日显示项
        /// </summary>
        public const string ResultDay = PIDAlgorithmToken.prefixResult + "Day";
        ///<summary>
        /// 时显示项
        /// </summary>
        public const string ResultHour = PIDAlgorithmToken.prefixResult + "Hour";
        ///<summary>
        /// 分显示项
        /// </summary>
        public const string ResultMinute = PIDAlgorithmToken.prefixResult + "Minute";
        ///<summary>
        /// 秒显示项
        /// </summary>
        public const string ResultScend = PIDAlgorithmToken.prefixResult + "Second";

        /// <summary>
        /// 初始化结果参数
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
        ///4、功能说明
        ///显示系统当前年、月、日、时、分、秒各项实时值
        ///5、算法说明 提取系统当前时间
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
            get { return "系统当前时间功能块"; }
        }
    }
}