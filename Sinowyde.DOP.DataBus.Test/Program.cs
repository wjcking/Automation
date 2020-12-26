using Sinowyde.DOP.DataBus.Test.Properties;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.Threading;
using RtValueQuality = Sinowyde.DOP.DataModel.RtValueQuality;

namespace Sinowyde.DOP.DataBus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = new PushThread(Settings.Default.IOService, IOTopic.IORead);
            request.Start();
            IList<Variable> vars = DOPDataLogic.Instance().Query<Variable>(null, null, 0, 0);
            Console.WriteLine("Sinowyde.DOP.DataBus.Test===>开始运行");
            var flag = true;
            while (true)
            {
                foreach (Variable var in vars)
                {
                    if (var.VariableType == VariableType.AM)
                    {
                        RTValue value = new RTValue { VarNumber = var.Number, Quality = RtValueQuality.good, Timestamp = DateTime.Now, Value = DateTime.Now.Second };
                        var str = value.ToString();
                        request.AddBuffer(str);
                        Console.WriteLine(str);
                    }
                    else
                    {
                        RTValue value = new RTValue { VarNumber = var.Number, Quality = RtValueQuality.good, Timestamp = DateTime.Now, Value = flag ? 0 : 1 };
                        var str = value.ToString();
                        request.AddBuffer(str);
                        Console.WriteLine(str);
                    }
                }
                flag = !flag;
                Thread.Sleep(5 * 1000);
            }
            Thread.Sleep(1000 * 1000 * 1000);
        }
    }
}
