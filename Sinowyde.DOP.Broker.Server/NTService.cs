using Sinowyde.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Broker.Server
{
    public partial class NTService : ServiceBase
    {
        private BrokerService service = new BrokerService();
        public NTService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Start(args);
        }

        protected override void OnStop()
        {
            Stop();
        }

        protected override void OnContinue()
        {
            this.OnStart(null);
        }

        protected override void OnPause()
        {
            this.OnStop();
        }

        internal void Start(string[] args)
        {
            if (service.StartService())
            {
                LogUtil.LogInfo("Sinowyde.DOP.Broker.Server 启动.....");
            }
            else
            {
                LogUtil.LogInfo("Sinowyde.DOP.Broker.Server 启动失败.....");
            }
        }

        internal void Stop()
        {
            LogUtil.LogInfo("Sinowyde.DOP.Broker.Server 停止.....");
            service.StopService();
        }
    }
}
