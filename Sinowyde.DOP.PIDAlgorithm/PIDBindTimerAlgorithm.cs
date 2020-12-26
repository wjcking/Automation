using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sinowyde.DOP.PIDAlgorithm
{
    [Serializable]
    public abstract class PIDBindTimerAlgorithm : PIDBindAlgorithm
    {
        /// <summary>
        /// 定时器周期
        /// </summary>
        public double period
        {
            get
            {
                return this.triggerTimer.Interval;
            }
            protected set
            {
                if (value == 0)
                {
                    value = 1;
                }
                this.triggerTimer.Interval = value;
            }
        }
        /// <summary>
        /// 定时器 是否 启动
        /// 
        /// </summary>
        protected volatile bool isStarted = false;
        /// <summary>
        /// 内部触发定时器
        /// </summary>
        [NonSerialized]
        protected Timer triggerTimer = null;

        public PIDBindTimerAlgorithm()
            : base()
        {
            this.triggerTimer = new Timer();
            this.triggerTimer.AutoReset = false;
            this.triggerTimer.Elapsed += triggerTimer_Elapsed;
        }

        //延时出发操作
        private void triggerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            base.CalcOneRound();
            this.isStarted = false;    
        }

        /// <summary>
        /// 计算,需要注意结果
        /// </summary>
        /// <returns>计算是否成功</returns>
        public override bool DoCalc()
        {
            if (this.IsReadyToCalc() && !this.isStarted)
            {
                SetTimerPeriod();
                this.triggerTimer.Start();
                this.isStarted = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置时间间隔
        /// </summary>
        protected virtual void SetTimerPeriod()
        {
        }

    }
}
