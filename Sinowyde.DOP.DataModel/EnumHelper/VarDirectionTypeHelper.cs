using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 变量采集方式
    /// </summary>
    public enum VarDirectionType
    {
        Read = 0, //读取
        Write,   //写入
        Calc,    //计算变量
        Temp     //中间临时
    }

    public class VarDirectionTypeHelper : EnumDataHelper<VarDirectionType>
    {
        protected override void InitValue()
        {
            valueMap.Add("读取", VarDirectionType.Read);
            valueMap.Add("写入", VarDirectionType.Write);
            valueMap.Add("临时", VarDirectionType.Temp);
            valueMap.Add("计算", VarDirectionType.Calc);
        }
       
        public virtual string[] GetReadWrite()
        {
            return new string[] {"读取","临时" };
        }
    }
}
