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
    public class Device : Entity
    {
        /// <summary>
        /// 可中文
        /// </summary>
        [Property(Length = 50, Unique=true)]
        public virtual string Name
        {
            get;
            set;
        }
    }
}
