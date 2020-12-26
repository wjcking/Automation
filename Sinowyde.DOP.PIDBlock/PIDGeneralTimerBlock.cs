using Sinowyde.DOP.PIDAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock
{
    [Serializable]
    public class PIDGeneralTimerBlock : PIDGeneralBlock
    {
        /// <summary>
        /// 定时器周期
        /// </summary>
        public long period
        {
            get;
            private set;
        }
        /// <summary>
        /// 内部触发定时器
        /// </summary>
        protected Timer triggerTimer = null;

        public PIDGeneralTimerBlock(PIDBindAlgorithm algorithm)
            : base(algorithm)
        {
            this.period = period;
            this.triggerTimer = new Timer(TimerCallback, this, 0, long.MaxValue);
        }
        /// <summary>
        /// 定时工作函数
        /// </summary>
        /// <param name="state"></param>
        protected void TimerCallback(object state)
        {
            this.Algorithm.DoCalc();
        }
        /// <summary>
        /// 修改定时周期
        /// 
        /// </summary>
        /// <param name="period"></param>
        public void SetPeriod(long period)
        {
            this.period = period;
            this.triggerTimer.Change(0, period);
        }


    }
}
