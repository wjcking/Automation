using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 数据质量
    /// </summary>
    public enum RtValueQuality
    {
        good = 1, //好的
        bad,    //坏的
        old     //旧的
    }

    public class RtValueQualityHelper:EnumDataHelper<RtValueQuality>
    {
        protected override void InitValue()
        {
            valueMap.Add("好的", RtValueQuality.good);
            valueMap.Add("坏的", RtValueQuality.bad);
            valueMap.Add("旧的", RtValueQuality.old);
        }
    }
}
