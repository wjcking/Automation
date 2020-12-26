using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Driver
{
    public class DriverFactory
    {
        private static DOPModBusSerialPort serialPort = new DOPModBusSerialPort();
        private static DOPModBusTCP tcpPort = new DOPModBusTCP();

        public static IDriver CreateDriver(string Protocol)
        {
            switch (Protocol)
            {
                case "ModBusSerialPort":
                    return serialPort;
                case  "ModBusTCP":
                    return tcpPort;
                default:
                    return null;
            }
        }

    }
}
