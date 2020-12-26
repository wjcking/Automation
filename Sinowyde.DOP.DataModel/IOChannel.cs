using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 通讯通道
    /// </summary>
    [Class]
    [Serializable]
    public class IOChannel : Entity
    {
        /// <summary>
        /// 通道名称
        /// </summary>
        [Property(Length = 50, Unique = true)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 通讯类型
        /// </summary>
        [Property]
        public virtual CommuType CommuType { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [Property(Length = 50)]
        public virtual string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        [Property]
        public virtual int Port { get; set; }

        /// <summary>
        /// 附加扩展通讯参数
        /// </summary>
        [Property(Length = 500)]
        public virtual string Params { get; set; }
 
        /// <summary>
        /// 采集周期（毫秒）
        /// </summary>
        [Property]
        public virtual int GatherPeriod { get; set; }

        [ReadOnlyManyToOne(ClassType = typeof(IOServer), Column = "IOServerID", ForeignKey = "FK_IOChannel_IOServerID")]
        public virtual IOServer IOServer { get; set; }


        public virtual long? IOServerID
        {
            get
            {
                return Entity.ToID<IOServer>(this.IOServer);
            }
            set
            {
                this.IOServer = Entity.ToEntity<IOServer>(value);
            }
        }

        public virtual IList<IOUnit> IOUnits
        {
            get;
            set;
        }
    }

}
