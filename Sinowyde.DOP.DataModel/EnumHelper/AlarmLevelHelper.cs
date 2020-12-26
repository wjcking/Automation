using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 报警等级
    /// </summary>
    public enum AlarmLevel
    {
        Low = 1,//中级
        Normal,//低级
        High, //高级
    }

    public class AlarmLevelHelper : EnumDataHelper<AlarmLevel>
    {
        protected override void InitValue()
        {
            valueMap.Add("中级", AlarmLevel.Low);
            valueMap.Add("低级", AlarmLevel.Normal);
            valueMap.Add("高级", AlarmLevel.High);
        }
    }
}
