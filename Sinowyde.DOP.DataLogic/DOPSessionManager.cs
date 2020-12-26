using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using Sinowyde.DataLogic;
using Sinowyde.DataModel;
using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataLogic
{
    class DOPSessionManager : SessionManagerBase
    {
        protected override ISessionFactory GetSessionFactory()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            ConfigureByAttribute(cfg, typeof(Device).Assembly);
            ConfigureByAttribute(cfg,typeof(Sinowyde.DataModel.ModelVersion).Assembly);
            this.sessionFactory = cfg.BuildSessionFactory();
            return cfg.BuildSessionFactory();
        }

        private Configuration ConfigureByAttribute(Configuration cfg, Assembly assembly)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    HbmSerializer.Default.Validate = true;
                    HbmSerializer.Default.Serialize(stream, assembly);
                    stream.Position = 0;
                    cfg.AddInputStream(stream);
                    return cfg;
                }
                catch (Exception)
                {

                    return null;
                }
                
            }
        }
    }
}
