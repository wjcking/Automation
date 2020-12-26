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

namespace Sinowyde.DOP.SamaEngine.Server
{
    public partial class NTService : ServiceBase
    {
        private EngineService samaService = new EngineService();

        public NTService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            samaService.StartService();
            LogUtil.LogInfo("Sinowyde.DOP.SamaEngine.Server服务启动");
        }

        protected override void OnStop()
        {
            samaService.StopService();
            LogUtil.LogInfo("Sinowyde.DOP.SamaEngine.Server服务停止");
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
            LogUtil.LogInfo(samaService.StartService()
                                ? "Sinowyde.DOP.SamaEngine.Server 启动....."
                                : "Sinowyde.DOP.SamaEngine.Server 启动失败.....");
        }

        internal void Stop()
        {
            LogUtil.LogInfo(samaService.StopService()
                                ? "Sinowyde.DOP.SamaEngine.Server 停止....."
                                : "Sinowyde.DOP.SamaEngine.Server 停止失败.....");
        }
    }
}
