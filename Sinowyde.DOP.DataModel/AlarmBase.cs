using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    [Serializable]
    public class AlarmBase : Entity
    {
        [Property]
        public virtual string VarNumber { get; set; }

        [Property]
        public virtual DateTime Timestamp { get; set; }


        [Property]
        public virtual double Value { get; set; }


        [Property]
        public virtual AlarmLevel Level { get; set; }


        [Property]
        public virtual AlarmType Type { get; set; }

        /// <summary>
        ///  报警内容
        /// </summary>
        public virtual string Content
        {
            get
            {
                string levelStr = new AlarmLevelHelper().GetKeyByValue(this.Level);
                string typeStr = new AlarmTypeHelper().GetKeyByValue(this.Type);
                return string.Format(" 报警类型：{0} 报警等级：{1} 数值：{2}", typeStr, levelStr, this.Value);
            }
        }
    }
}
