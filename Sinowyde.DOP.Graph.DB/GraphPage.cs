using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Graph.DB
{
    public class GraphUnit : Entity
    {
        [Property(Unique=true)]
        public virtual string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 并发锁定
        /// </summary>
        [Property]
        public virtual bool IsLock
        {
            get;
            set;
        }
        /// <summary>
        /// 组描述
        /// </summary>
        [Property]
        public virtual string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 作为版本时戳
        /// </summary>
        [Property]
        public virtual DateTime Timestamp
        {
            get;
            set;
        }

    }

    [Class(Table="GraphPage")]
    public class GraphPageSummary : GraphUnit
    {
        
    }

    [Class]
    public class GraphPage : GraphUnit
    {
        /// <summary>
        /// 展现用的xml流
        /// </summary>
        [Property(Length = 16777216)]
        public virtual string Content
        {
            get;
            set;
        }
    }
}
