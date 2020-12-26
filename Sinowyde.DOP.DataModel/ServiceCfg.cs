using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    [Class]
    [Serializable]
    public class ServiceCfg : Entity
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        [Property(Length = 50, Unique = true)]
        public virtual string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 服务类型
        /// </summary>
        [Property]
        public virtual ServiceCfgType ServiceType
        {
            get;
            set;
        }
        /// <summary>
        /// 服务地址
        /// </summary>
        [Property]
        public virtual string Address
        {
            get;
            set;
        }
    }
}
