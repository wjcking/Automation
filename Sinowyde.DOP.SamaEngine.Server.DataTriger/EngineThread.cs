using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.SamaEngine.Server
{
    public class EngineThread : ServiceThread
    {
        /// <summary>
        /// 计算引擎
        /// </summary>
        public EngineThread()
            : base(10, 1000)
        {
        }

        /// <summary>
        /// 采集数据缓存
        /// </summary>
        private BufferManager<RTValue> valueBuffer = new BufferManager<RTValue>();

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="value"></param>
        public void AddRTValue(RTValue value)
        {
            if (value != null && Page != null
                && Page.BindVarList.Contains(value.VarNumber))
            {
                valueBuffer.Add(value);
            }
        }
        
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="value"></param>
        public void AddRTValue(List<RTValue> values)
        {
            valueBuffer.Add(values);
        }

        /// <summary>
        /// 算法页
        /// </summary>
        public SamaPageRunTime Page
        {
            get;
            set;
        }

        /// <summary>
        /// 执行计算
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            //触发无参计算
            Page.TrigerNoInputAlgoritm();
            //采集数据触发就算
            IList<RTValue> values = valueBuffer.GetAllData();
            foreach (RTValue value in values)
            {
                Page.PushSama(value);                    
            }
            return true;
        }
    }
}
