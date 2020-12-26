
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 周期定时器算法块（Cycle） Timer2fddb
    /// </summary>
    public class PIDCycle : PIDBindAlgorithm
    {
        ///<summary>
        /// 开始工作信号
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixParam + "SET";
        ///<summary>
        /// 月显示项
        /// </summary>
        public const string ParamMonth = PIDAlgorithmToken.prefixParam + "Month";
        ///<summary>
        /// 日显示项
        /// </summary>
        public const string ParamDay = PIDAlgorithmToken.prefixParam + "Day";
        ///<summary>
        /// 时显示项
        /// </summary>
        public const string ParamHour = PIDAlgorithmToken.prefixParam + "Hour";
        ///<summary>
        /// 分显示项
        /// </summary>
        public const string ParamMinute = PIDAlgorithmToken.prefixParam + "Minute";
        ///<summary>
        /// 秒显示项
        /// </summary>
        public const string ParamScend = PIDAlgorithmToken.prefixParam + "Scend";
        ///<summary>
        /// 定时器脉冲输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        /// <summary>
        /// 初始化变量参数
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
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, 1, PIDVarInputType. PIDVarDataType.DM);
        }

        /// <summary>
        ///4、功能说明
        ///本功能块对将当前时间与设定时间比较，首次达到或超过设定时间时，输出一个单脉冲，
        ///宽度为计算周期。
        ///如果某位的值被置为－1，则表示该位不起作用。
        ///如果 Sec 以上为－1， 则每个 Min 的 Sec 时刻会输出一个单脉冲；如果 Hour 以上为－1，
        ///则每个 Hour 的 Min:Sec 时刻会输出一个单脉冲；如果 Day 以上为－1，则每天的 Hour:Min:Sec
        ///时刻会输出一个单脉冲；以此类推，可定义到以年为周期的定时。
        ///参数秒 Sec 不能取－1。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double month = this.calcParams[ParamMonth].Value;
            double day = this.calcParams[ParamDay].Value;
            double hour = this.calcParams[ParamHour].Value;
            double minute = this.calcParams[ParamMinute].Value;
            double sec = this.calcParams[ParamScend].Value;

            //秒不能为-1；
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