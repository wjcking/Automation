using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 服务器配置
    /// </summary>
    public enum ServiceCfgType
    {
        Publish = 1,   //发布者
        Subscribe,   //订阅者
        BrokerPub,   //中介发布
        BrokerSub    //中介订阅
    }

    public class ServiceCfgTypeHelper : EnumDataHelper<ServiceCfgType>
    {
        protected override void InitValue()
        {
            valueMap.Add("发布者", ServiceCfgType.Publish);
            valueMap.Add("订阅者", ServiceCfgType.Subscribe);
            valueMap.Add("中介发布", ServiceCfgType.BrokerPub);
            valueMap.Add("中介订阅", ServiceCfgType.BrokerSub);
        }
    }
}
