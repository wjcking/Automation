using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Math
{
    /// <summary>
    /// 三角函数
    /// </summary>
    public enum PIDsins
    {
        Sin = 1,
        Cos = 2,
        Tan = 3,
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PIDsinHelper : EnumDataHelper<PIDsins>
    {
        protected override void InitValue()
        {
            valueMap.Add("Sin", PIDsins.Sin);
            valueMap.Add("Cos", PIDsins.Cos);
            valueMap.Add("Tan", PIDsins.Tan);
        }
    }
}
