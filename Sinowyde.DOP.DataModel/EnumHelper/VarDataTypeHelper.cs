using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;
using Sinowyde.RTModel;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 变量数据类型
    /// </summary>
    public class VarDataTypeHelper : EnumDataHelper<Sinowyde.RTModel.DataType>
    {
        protected override void InitValue()
        {
            valueMap.Add("字节", DataType.data_byte);
            valueMap.Add("短整型", DataType.data_short);
            valueMap.Add("无符号整型", DataType.data_ushort);
            valueMap.Add("整型", DataType.data_int);
            valueMap.Add("长整型", DataType.data_long);
            valueMap.Add("浮点型", DataType.data_float);
            valueMap.Add("字符串", DataType.data_string);
            valueMap.Add("时间", DataType.data_datetime);
        }
    }
}
