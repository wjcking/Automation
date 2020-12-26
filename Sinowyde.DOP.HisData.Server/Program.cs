using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.HisData.Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            var service = new NTService();
            service.Start(null);
            Console.WriteLine("按<Enter>结束该服务程序");
            Console.ReadLine();
            service.Stop();
#else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new NTService() 
                };
                ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
