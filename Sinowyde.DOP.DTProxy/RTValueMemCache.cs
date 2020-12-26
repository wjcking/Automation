using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DTProxy.Properties;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DTProxy
{
    public class UpdateRTValuesArg : EventArgs
    {
        public IList<RTValue> Values
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 通知缓存数据发生更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventUpdateRTValues(object sender, UpdateRTValuesArg arg);

    public class RTValueMemCache
    {
        /// <summary>
        /// 订阅数据池
        /// </summary>
        private SubscribeThreadPool subPool = null;

        private volatile bool isStarted = false;
        /// <summary>
        /// 数据缓存
        /// </summary>
        private DataMemCache<string, RTValue> memCache = new DataMemCache<string, RTValue>();

        private RTValueMemCache()
        {
        }

        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static RTValueMemCache instance = null;

        private static object _lock = new object();
        /// <summary>
        /// 单例实现
        /// </summary>
        /// <returns></returns>
        public static RTValueMemCache Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new RTValueMemCache();
                }
            }

            return instance;
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        void subPool_EventSubscribe(object sender, SubscribePoolEventArgs arg)
        {
            try
            {
                IList<RTValue> values = new List<RTValue>();
                IList<string> messages = arg.Messages;
                foreach (string message in messages)
                {
                    RTValue value = RTValue.FromString(message);
                    values.Add(value);
                    memCache.Add(value.VarNumber, value);
                }
                //通知外部数据发生变更
                if (values.Count > 0 && EventUpdateRTValues != null)
                    EventUpdateRTValues(this, new UpdateRTValuesArg { Values = values });
            }
            catch
            { }
        }
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IList<RTValue> GetValues(IList<string> numbers)
        {
            IList<RTValue> values = new List<RTValue>();
            if (numbers == null)
                return values;
            foreach (string number in numbers)
            {
                RTValue value = memCache.Get(number);
                if (value != null)
                {
                    values.Add(value);
                    //memCache.Add(value.VarNumber, value);
                }
            }

            return values;
        }

        public void ClearMemCache()
        {
            if (null != memCache)
                memCache.Clear();
        }

        /// <summary>
        /// 获取单点数据缓存
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public RTValue GetValue(string number)
        {
            return memCache.Get(number);
        }
        /// <summary>
        /// 启动缓存
        /// </summary>
        public void StartMemCache(string address, IList<string> topics)
        {
            if(isStarted)
                return;

            subPool = new SubscribeThreadPool(address, topics);
            subPool.EventSubscribe += subPool_EventSubscribe;

            subPool.Start();
            isStarted = true;
        }
        /// <summary>
        /// 启动缓存
        /// </summary>
        public void StartMemCache()
        {
            if (isStarted)
                return;
            string address = Settings.Default.Address;
            string[] topics = Settings.Default.Topic.Split(new char[]{','});
            StartMemCache(address, topics);
        }
        /// <summary>
        /// 结束缓存
        /// </summary>
        public void StopMemCache()
        {
            if (subPool != null)
                subPool.Stop();
            isStarted = false;
        }
        /// <summary>
        /// 数据更新通知
        /// </summary>
        public event EventUpdateRTValues EventUpdateRTValues = null;
    }
}
