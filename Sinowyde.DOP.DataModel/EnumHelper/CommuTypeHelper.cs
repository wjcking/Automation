using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 通讯类型
    /// </summary>
    public enum CommuType
    {
        Serial =1,
        TcpServer,
        TcpClient
    }

    /// <summary>
    /// 
    /// </summary>
    public class CommuTypeHelper : EnumDataHelper<CommuType>
    {
        protected override void InitValue()
        {
            valueMap.Add("串口", CommuType.Serial);
            valueMap.Add("服务端", CommuType.TcpServer);
            valueMap.Add("客户端", CommuType.TcpClient);
        }
    }
}
