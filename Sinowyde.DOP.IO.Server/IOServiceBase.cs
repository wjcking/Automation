using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Log;

namespace Sinowyde.DOP.IO.Server
{
    public partial class IOServiceBase:ServiceBase
    {
        private IOService ioService = null;

        public IOServiceBase()
        {
            ioService = new IOService();
        }

        protected override void OnStart(string[] args)
        {
            ioService.StartService();
        }

        protected override void OnPause()
        {
            ioService.StopService();
        }

        protected override void OnStop()
        {
            ioService.StopService();
        }

        protected override void OnContinue()
        {
            ioService.StartService();
        }

        internal void StartService(string[] args)
        {
            LogUtil.LogInfo(ioService.StartService()
                                ? "Sinowyde.DOP.IO.Server 启动....."
                                : "Sinowyde.DOP.IO.Server 启动失败.....");
        }

        internal void StopService()
        {
            //LogUtil.LogInfo(ioService.StopService()
            //                    ? "Sinowyde.DOP.IO.Server 停止....."
            //                    : "Sinowyde.DOP.IO.Server 停止失败.....");
        }
    }
}
