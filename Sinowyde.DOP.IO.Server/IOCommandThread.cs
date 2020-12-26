using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.Driver;
using Sinowyde.RTModel;
using Sinowyde.Util;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.IO.Server.Properties;
using System.Collections;

namespace Sinowyde.DOP.IO.Server
{
    public class IOCommandThread : ServiceThread
    {
        /// <summary>
        /// 下发数据变量对象
        /// </summary>
        private DataMemCache<string, Variable> varMap = new DataMemCache<string, Variable>();
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="variable"></param>
        public void AddVariable(Variable variable)
        {
            if (variable.DirectionType == VarDirectionType.Write)
            {
                varMap.Add(variable.Number, variable);
            }
        }
        public void AddVariable(IList<Variable> variables)
        {
            foreach (Variable variable in variables)
            {
                this.AddVariable(variable);
            }
        }
        /// <summary>
        /// 下发指令数据缓存
        /// </summary>
        private DataMemCache<int, IDictionary<string, RTValue>> valueBuffer =
            new DataMemCache<int, IDictionary<string, RTValue>>();
        /// <summary>
        /// 设置写入数值
        /// </summary>
        /// <param name="value"></param>
        public void AddRtValue(RTValue value)
        {
            if (value != null && varMap.Contain(value.VarNumber))
            {
                Variable varible= varMap.Get(value.VarNumber);
                if (!valueBuffer.Contain(varible.IOUnit.Address))
                {
                    valueBuffer.Add(varible.IOUnit.Address, new Dictionary<string,RTValue>());
                }
                valueBuffer.Get(varible.IOUnit.Address)[value.VarNumber] = value;
            }
        }
        public void AddRtValue(IList<RTValue> values)
        {
            foreach (RTValue value in values)
            {
                AddRtValue(value);                
            }
        }

        private IOChannelWrapper channel = null;
        public IOCommandThread(IOChannelWrapper channel)
            : base(10, 10000)
        {
            this.channel = channel;
        }
        
        /// <summary>
        /// 周期处理下发数据
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            try
            {               
                ICollection keys = valueBuffer.GetKeys();
                if (keys == null || keys.Count == 0)
                    return true;
                foreach (int address in keys)
                {
                    IList<RTValue> values = valueBuffer.Get(address).Values.ToList<RTValue>();
                    if (values == null || values.Count == 0)
                        continue;
                    if (values[0] == null)
                    {
                        Console.WriteLine("值为空！！");
                    }
                    string protocol = varMap.Get(values[0].VarNumber).IOUnit.Protocol;
                    IDriver driver = DriverFactory.CreateDriver(protocol);                    
                    IList<RtPoint> points = new List<RtPoint>();
                    IList<RtValue> rtValues = new List<RtValue>();
                    foreach (RTValue value in values)
                    {
                        Variable variable = varMap.Get(value.VarNumber);
                        points.Add(new RtPoint { Number=value.VarNumber, DataType=variable.DataType, Address=variable.Address });
                        rtValues.Add(new RtValue { Number=value.VarNumber, Value=value.Value, Quality= RTModel.RtValueQuality.good, Timestamp=value.Timestamp });
                    }
                    IList<MessageDefine> defines = driver.CreateCommondMsg(address, points, rtValues, varMap.Get(values[0].VarNumber).IOUnit.functionCode);

                    foreach (MessageDefine define in defines)
                    {
                        MessageWrapper wrapper = new MessageWrapper();
                        wrapper.IsSendCommand = true;
                        wrapper.MsgToken = "Command:" + DateTime.Now.ToLongTimeString();
                        wrapper.Protocol = protocol;
                        wrapper.SendMsg = define.MsgBuffer;
                        wrapper.ReplayMsg = new byte[define.ReplyLength];
                        IList<Variable> subVars = new List<Variable>();
                        foreach (RtPoint point in define.Points)
                        {
                            subVars.Add(varMap.Get(point.Number));
                        }
                        wrapper.Variables = subVars;

                        //送入消息线程
                        channel.CommuThread.toSendMsgs.Insert(wrapper);
                        Console.WriteLine("下发指令时间：" + DateTime.Now.ToString("HH:mm:ss"));
                    }

                    valueBuffer.Get(address).Clear();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("[IOCommandThread]取得下发数据失败", ex);
                return false;
            }
        }

    }
}
