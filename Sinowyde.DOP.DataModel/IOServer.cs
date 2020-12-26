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
    public class IOServer : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Property]
        public virtual string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Property]
        public virtual string Description
        {
            get;
            set;
        }        
    }
}
