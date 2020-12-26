using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 报警类型
    /// </summary>
    public enum AlarmType
    {
        High_Limit = 1,
        Low_Limit,
        Status,    //状态报警
        Change     //变化率
    }

    public class AlarmTypeHelper : EnumDataHelper<AlarmType>
    {
        protected override void InitValue()
        {
            valueMap.Add("高限报警", AlarmType.High_Limit);
            valueMap.Add("低限报警", AlarmType.Low_Limit);
            valueMap.Add("状态报警", AlarmType.Status);
            valueMap.Add("变化率报警", AlarmType.Change);
        }
    }
}
