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
    public class AlarmRule : Entity
    {
        /// <summary>
        /// 类型
        /// </summary>
        [Property]
        public virtual AlarmType AlarmType { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [Property]
        public virtual AlarmLevel AlarmLevel { get; set; }

        /// <summary>
        /// 极限值
        /// </summary>
        [Property]
        public virtual float LimitValue { get; set; }

        /// <summary>
        /// 是否作为事件记录
        /// </summary>
        [Property]
        public virtual bool RecordAsEvent { get; set; }

        /// <summary>
        /// 事件类型说明
        /// </summary>
        [Property]
        public virtual string EventType { get; set; }

        /// <summary>
        /// 记录最大时间间隔
        /// </summary>
        [Property]
        public virtual int TimeSpan { get; set; }
        /// <summary>
        /// 是否上传
        /// </summary>
        [Property]
        public virtual bool IsTransfer { get; set; }

        [ReadOnlyManyToOne(ClassType = typeof(Variable), Column = "VariableID", ForeignKey = "FK_AlarmRule_VariableID")]
        public virtual Variable Variable
        {
            get;
            set;
        }

        public virtual long? VariableID
        {
            get
            {
                return Entity.ToID<Variable>(this.Variable);
            }
            set
            {
                this.Variable = Entity.ToEntity<Variable>(value);
            }
        }

    }
}
