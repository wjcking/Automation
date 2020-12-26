using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Driver;
using Sinowyde.RTModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Sinowyde.DOP.IO.Server
{
    /// <summary>
    /// 周期生成发送报文到通讯线程
    /// </summary>
    public class IOReadMsgThread : ServiceThreadEx
    {
        private IOChannelWrapper channel = null;
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="interval"></param>
        public IOReadMsgThread(int interval, IOChannelWrapper channel)
            :base(interval)
        {
            this.channel = channel;
        }
        /// <summary>
        /// 变量映射
        /// </summary>
        private DataMemCache<string, Variable> varMap = new DataMemCache<string, Variable>();
        /// <summary>
        /// 读取变量对象列表
        /// </summary>
        private DataMemCache<int, IList<Variable>> varUnitMap = new DataMemCache<int, IList<Variable>>();
        /// <summary>
        /// 添加变量
        /// </summary>
        /// <param name="variable"></param>
        public void AddVariable(Variable variable)
        {
            if (variable.DirectionType == VarDirectionType.Read)
            {
                if (!varUnitMap.Contain(variable.IOUnit.Address))
                    varUnitMap.Add(variable.IOUnit.Address, new List<Variable>());
                varUnitMap.Get(variable.IOUnit.Address).Add(variable);
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

        public Variable GetVariable(string number)
        {
            return varMap.Get(number);
        }      
        /// <summary>
        /// 消息模板队列
        /// </summary>
        public IList<MessageWrapper> messageTempaltes = new List<MessageWrapper>();
        /// <summary>
        /// 构建静态报文
        /// </summary>
        protected override void InitThread()
        {
            //故障下会重启，需要清空
            messageTempaltes.Clear();

            ICollection addresses = varUnitMap.GetKeys();
            if (addresses == null || addresses.Count == 0)
                return;
            foreach (object address in addresses)
            {
                IList<Variable> variables = varUnitMap.Get(ConvertUtil.ConvertToInt(address));
                if (variables.Count == 0)
                    continue;

                IDriver driver = DriverFactory.CreateDriver(variables[0].IOUnit.Protocol);
                IList<MessageDefine> defines = driver.CreateRequestMsg(ConvertUtil.ConvertToInt(address), Variable.ConvertToPoints(variables), variables[0].IOUnit.functionCode);

                foreach (MessageDefine define in defines)
                {
                    MessageWrapper wrapper = new MessageWrapper();
                    wrapper.IsSendCommand = false;
                    wrapper.MsgToken = "Request:" + DateTime.Now.ToShortTimeString();
                    wrapper.Protocol = variables[0].IOUnit.Protocol;
                    wrapper.SendMsg = define.MsgBuffer;
                    wrapper.ReplayMsg = new byte[define.ReplyLength];
                    IList<Variable> subVars = new List<Variable>();
                    foreach (RtPoint point in define.Points)
                    {
                        subVars.Add(varMap.Get(point.Number));
                    }
                    wrapper.Variables = subVars;

                    messageTempaltes.Add(wrapper);
                }
            }
        }

        /// <summary>
        /// 循环发送报文
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {         
            foreach (MessageWrapper msg in messageTempaltes)
            {
                channel.CommuThread.toSendMsgs.Add(msg);
            }
            return true;
        }
    }
}
