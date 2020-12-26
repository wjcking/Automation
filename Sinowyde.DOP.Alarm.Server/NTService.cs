using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.Alarm.Server.Tasks;
using Sinowyde.Log;

namespace Sinowyde.DOP.Alarm.Server
{
    public partial class NTService : ServiceBase
    {
        private AlarmService alarmService = new AlarmService();

        public NTService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            alarmService.StartService();
            LogUtil.LogInfo("Sinowyde.DOP.Alarm.Server服务启动");
        }

        protected override void OnStop()
        {
            alarmService.StopService();
            LogUtil.LogInfo("Sinowyde.DOP.Alarm.Server服务停止");
        }

        protected override void OnPause()
        {
            OnStop();
        }

        protected override void OnContinue()
        {
            OnStart(null);
        }

        internal void Start(string[] args)
        {
            LogUtil.LogInfo(alarmService.StartService()
                                ? "Sinowyde.DOP.Alarm.Server 启动....."
                                : "Sinowyde.DOP.Alarm.Server 启动失败.....");
        }

        internal void Stop()
        {
            LogUtil.LogInfo(alarmService.StopService()
                                ? "Sinowyde.DOP.Alarm.Server 停止....."
                                : "Sinowyde.DOP.Alarm.Server 停止失败.....");
        }
    }
}
