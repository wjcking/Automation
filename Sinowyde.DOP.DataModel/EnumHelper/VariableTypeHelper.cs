using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    // <summary>
    /// 变量类型
    /// </summary>
    public enum VariableType
    {
        AM = 0, //模拟量
        DM,    //数字量
        StringM   //字符串
    }
         
    /// <summary>
    /// 变量类型 helper
    /// </summary>
    public class VariableTypeHelper : EnumDataHelper<VariableType>
    {
        protected override void InitValue()
        {
            valueMap.Add("模拟量", VariableType.AM);
            valueMap.Add("数字量", VariableType.DM);
            valueMap.Add("字符串", VariableType.StringM);
        }
    }
}
