using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DataModel;

namespace Sinowyde.DOP.DataModel
{
    [Class]
    [Serializable]
    public class RTEvent : AlarmBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        [Property]
        public virtual string EventType { get; set; }

        /// <summary>
        ///  报警内容
        /// </summary>
        public override string Content
        {
            get
            {
                string levelStr = new AlarmLevelHelper().GetKeyByValue(this.Level);
                string typeStr = new AlarmTypeHelper().GetKeyByValue(this.Type);
                return string.Format("事件等级：{0} 事件类型：{1} ，数值：{2} 事件描述：{3}", levelStr, typeStr,this.Value, this.EventType);
            }
        }

    }
}
