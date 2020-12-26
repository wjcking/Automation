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
    public class IOUnit : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Property]
        public virtual string Name { get; set; }

        /// <summary>
        /// 采集地址
        /// </summary>
        [Property]
        public virtual int Address { get; set; }

        /// <summary>
        /// 协议名称
        /// </summary>
        [Property]
        public virtual string Protocol { get; set; }

        [Property]
        public virtual FunctionCode FunctionCode { get; set; }

        [ReadOnlyManyToOneAttribute(ClassType = typeof(IOChannel), Column = "ChannelID", ForeignKey = "FK_IOUnit_ChannelID")]
        public virtual IOChannel Channel { get; set; }
        
        public virtual long? ChannelID
        {
            get
            {
                return Entity.ToID<IOChannel>(this.Channel);
            }
            set
            {
                this.Channel = Entity.ToEntity<IOChannel>(value);
            }
        }

        public virtual IList<Variable> Variables
        {
            get;
            set;
        }
    }
}
