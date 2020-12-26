using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.IO.Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            var service = new IOServiceBase();
            service.StartService(null);
            Console.WriteLine("按<Enter>结束该服务程序");
            Console.ReadLine();
            service.StopService();
#else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new IOServiceBase() 
                };
                ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
