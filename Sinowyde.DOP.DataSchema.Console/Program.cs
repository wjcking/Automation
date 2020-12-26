using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using Sinowyde.DOP.PIDAlgorithm.DB;
using Sinowyde.DataModel;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Graph.DB;

namespace Sinowyde.DOP.DataSchema.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration();
            string fileName = null;
            if (args.Length > 0)
            {
                fileName = args[0];
            }
            else
            {
                fileName = "var.sql";
            }
            Assembly[] assemblies = new Assembly[] { typeof(PIDAlgPage).Assembly, typeof(ModelVersion).Assembly,
                typeof(GraphPage).Assembly, typeof(Device).Assembly };
            NHSchemaUtil.SchemaOutput(assemblies, fileName, "");

            //HbmSerializer.Default.Serialize(typeof(PIDAlgorithmEntity).Assembly, "DomainModel.hbm.xml");

            System.Console.WriteLine("按<Enter>结束该应用程序");
            System.Console.ReadLine();
        }

    }
}
