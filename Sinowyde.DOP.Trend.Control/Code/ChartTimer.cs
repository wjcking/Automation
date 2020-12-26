using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Trend.Control
{
    public class ChartTimer
    {
        private int timerPeriod = 1000;

        private Timer workTimer;

        private bool timerIsRun = false;

        public bool TimerIsRun { get { return timerIsRun; } }

        /// <summary>
        /// 轮询周期
        /// </summary>
        public int TimerPeriod
        { 
            get { return timerPeriod; }
            set 
            {
                timerPeriod = value;
                if (this.workTimer != null)
                {
                    this.StopWorkTimer();
                    this.StartWorkTimer(this.action);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TimerPeriod">轮询周期</param>
        public ChartTimer(int TimerPeriod)
        {
            this.timerPeriod = TimerPeriod;
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        public void StartWorkTimer(Action<Object> action)
        {
            timerIsRun = true;
            this.action = action;
            if (workTimer != null)
            {
                workTimer.Dispose();
                workTimer = null;
            }
            workTimer = new System.Threading.Timer(new System.Threading.TimerCallback(action), null, 0, timerPeriod);
        }

        public void StopWorkTimer() 
        {
            timerIsRun = false;
            if (workTimer != null)
            {
                workTimer.Dispose();
                workTimer = null;

            }
        }

        private Action<Object> action = null;
    }
}
