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
    public class RTAlarm :AlarmBase
    {
        /// <summary>
        /// 确认人
        /// </summary>
        [Property]
        public virtual string Operator { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [Property]
        public virtual DateTime? ConfirmTime { get; set; }

        
    }
}