using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    /// 反三角函数
    /// </summary>
    public enum PIDAsins
    {
        ASin = 1,
        ACos = 2,
        ATan = 3,
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]    
    public class PIDAsinHelper : EnumDataHelper<PIDAsins>
    {
        protected override void InitValue()
        {
            valueMap.Add("ASin", PIDAsins.ASin);
            valueMap.Add("ACos", PIDAsins.ACos);
            valueMap.Add("ATan", PIDAsins.ATan);
        }
    }
}
