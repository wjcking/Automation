using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataBus.Test
{
    class NameThread : ServiceNameThread
    {
        public NameThread(string address)
            : base(address)
        { }

        protected override void InitAddressMap()
        {
            this.addressMap.Add("s1", "tcp://127.0.0.1:9001");
            this.addressMap.Add("s2", "tcp://127.0.0.1:9002");
            this.addressMap.Add("s3", "tcp://127.0.0.1:9003");
            this.addressMap.Add("s4", "tcp://127.0.0.1:9004");
        }
    }
}
