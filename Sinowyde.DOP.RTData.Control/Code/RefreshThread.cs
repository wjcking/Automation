using Sinowyde.DOP.DataModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.RTData.Control
{
    /// <summary>
    /// 响应消息处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventRefreshArgsMessage(object sender, EventArgs arg);

    public class RefreshThread : ServiceThread
    {
        public RefreshThread()
            : base(300, 10000)
        {
        }

        public static DataMemCache<string, RTValue> valueMap = new DataMemCache<string, RTValue>();

        public static void AddValues(IList<RTValue> values)
        {
            foreach (RTValue value in values)
            {
                valueMap.Add(value.VarNumber, value);
            }
        }

        protected override bool DoWork()
        {
            if (RefreshEvent != null)
                RefreshEvent(this, null);

            return true;
        }

        public EventRefreshArgsMessage RefreshEvent = null;
    }
}
