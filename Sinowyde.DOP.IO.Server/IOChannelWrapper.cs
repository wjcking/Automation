using Sinowyde.DOP.Communication;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Driver;
using Sinowyde.DOP.IO.Server.Properties;
using Sinowyde.RtModel;
using Sinowyde.RTModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Sinowyde.DOP.IO.Server
{
    /// <summary>
    /// 通道包装
    /// </summary>
    public class IOChannelWrapper
    {  
        /// <summary>
        /// IO通道
        /// </summary>
        private IOChannel channel = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="channel"></param>
        public IOChannelWrapper(IOChannel channel)
        {
            this.channel = channel;
            InitCommuThread(channel);
            InitReadThread(channel);
            InitCommandThread(channel);            
        }
        
        /// <summary>
        /// 通讯线程
        /// </summary>
        public CommuThread CommuThread
        {
            get;
            private set;
        }
        /// <summary>
        /// 初始化通讯线程
        /// </summary>
        /// <param name="channel"></param>
        private void InitCommuThread(IOChannel channel)
        {
            ICommunicator communicator = null;
            if (channel.CommuType == CommuType.Serial)
            {
                communicator = new SerialPortWrapper();
                SerialChannel serialChannel = new SerialChannel(channel);
                (communicator as SerialPortWrapper).BaudRate = serialChannel.Baud;
                (communicator as SerialPortWrapper).Parity = serialChannel.ParityVerify;
                (communicator as SerialPortWrapper).StopBits = serialChannel.StopBits;
                (communicator as SerialPortWrapper).PortName = serialChannel.SerialNo;
                (communicator as SerialPortWrapper).DataBits = serialChannel.DataBits;

            }
            else if (channel.CommuType == CommuType.TcpClient)
            {
                communicator = new TCPClientWrapper(channel.IP, channel.Port);
            }
            else
            { }            
            CommuThread = new CommuThread(communicator);
            CommuThread.MaxErrorCount = 2 * (channel.IOUnits == null ? 0 : channel.IOUnits.Count);
            CommuThread.DataReceive += CommuThread_DataReceive;     
        }
        /// <summary>
        /// 接收到数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommuThread_DataReceive(object sender, DataCommuArgs e)
        {
            //报文解析
            MessageWrapper messge = e.Message;
            IDriver driver = DriverFactory.CreateDriver(messge.Protocol);
            IList<RtValue> rtValues = driver.AnalyzeFromBytes(messge.ReplayMsg, messge.Points);
            //数据预处理
            StringBuilder tmp = new StringBuilder();
            DateTime timestamp = DateTime.Now;
            foreach (RtValue value in rtValues)
            {
                Variable variable = this.ReadThread.GetVariable(value.Number);
                if (variable != null)
                {
                    this.pushThread.AddBuffer(new RTValue
                    {
                        VarNumber = value.Number,
                        Quality = Sinowyde.DOP.DataModel.RtValueQuality.good,
                        Timestamp = timestamp,
                        Value = ConvertUtil.ConvertToFloat(value.Value) * variable.Ratio + variable.Bias
                    }.ToString());
                    tmp.Append(",");
                    tmp.Append(value.Value);
                }
            }
            if (tmp.ToString().Length > 1)
            {
                Console.WriteLine("[接收时间]" + DateTime.Now);
                Console.WriteLine("[接收数据]" + tmp.ToString().Substring(1));
            }               
        }

        /// <summary>
        /// 初始化读取消息线程
        /// </summary>
        public IOReadMsgThread ReadThread
        {
            get;
            private set;
        }
        private void InitReadThread(IOChannel channel)
        {
            ReadThread = new IOReadMsgThread(channel.GatherPeriod, this);
            foreach (IOUnit ioUnit in channel.IOUnits)
            {
                ReadThread.AddVariable(ioUnit.Variables);
            }
        }

        /// <summary>
        /// 初始化发送报文线程
        /// </summary>
        public IOCommandThread CommandThread
        {
            get;
            private set;
        }
        private void InitCommandThread(IOChannel channel)
        {
            CommandThread = new IOCommandThread(this);
            foreach (IOUnit ioUnit in channel.IOUnits)
            {
                CommandThread.AddVariable(ioUnit.Variables);
            }
        }

        /// <summary>
        /// 写入数据命令
        /// </summary>
        /// <param name="values"></param>
        public void WriteCommand(IList<RTValue> values)
        {
            this.CommandThread.AddRtValue(values);
        }

        /// <summary>
        /// 初始化推送线程
        /// </summary>
        private PushThread pushThread = new PushThread(Settings.Default.Broker, IOTopic.IORead);
        
        /// <summary>
        /// 打开通讯通道
        /// </summary>
        /// <returns></returns>       
        public bool Open()
        {
            return this.CommandThread.Start() && this.ReadThread.Start()
                && this.CommuThread.Start() && pushThread.Start();
        }

        /// <summary>
        /// 关闭通道
        /// </summary>
        public void Close()
        {
            this.CommuThread.Stop();
            this.CommandThread.Stop();
            this.ReadThread.Stop();            
            this.pushThread.Stop();
        }             
    }
}
