using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Driver;
using Sinowyde.DOP.IO.Server.Properties;
using Sinowyde.Log;
using Sinowyde.RTModel;
using Sinowyde.Util;

namespace Sinowyde.DOP.IO.Server
{
    public class TCPServerCommunicator : ServiceThread,ICommunicator
    {
        #region 变量属性
        private TCPServerWrapper tcpServer = null;

        /// <summary>
        /// 发布数据
        /// </summary>
        private PushThread pushThread = null;
        #endregion
        public TCPServerCommunicator(string ipAddress, int port, int MaxCount, int interval = 1000, int retry = 1000)
            : base(interval, retry)
        {
            tcpServer = new TCPServerWrapper(ipAddress, port, MaxCount);
            tcpServer.DataReceived += OnDataReceived;
            tcpServer.Connected += OnConnected;
            tcpServer.Disconnected += OnDisconnected;
            //实例发布对象
            pushThread = new PushThread(Settings.Default.Response, Settings.Default.Topic);
        }

        /// <summary>
        /// 处理接收的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            byte[] buffer = e.Buffer;
            IList<RtValue> rtValue = DOPModBusWrapper.CreateInstance("ModBusSerialPort").GetDataFromBytes(buffer, null);
            RTValue rtValues = new RTValue();
            //发布数据
            pushThread.AddBuffer(rtValues.ToString());
        }

        private void OnConnected(object sender, EventArgs e)
        {
            LogUtil.LogInfo("[TCPServerCommunicator]服务启动成功");
            Console.WriteLine("[TCPServerCommunicator]服务启动成功");
            pushThread.Start();
            //启动报文发送
            this.Start();
        }

        private void OnDisconnected(object sender, EventArgs e)
        {
            this.Close();
            pushThread.Stop();
            LogUtil.LogInfo("[TCPServerCommunicator]断开服务成功");
            Console.WriteLine("[TCPServerCommunicator]断开服务成功");
        }

        private void HandleError()
        {
            LogUtil.LogInfo("[TCPServerCommunicator]报文解析错误");
            Console.WriteLine("[TCPServerCommunicator]报文解析错误");
        }


        #region ICommunicator 成员

        public bool Open()
        {
            return this.tcpServer.Run();
        }

        public bool Close()
        {
            this.Stop();
            return this.tcpServer.Stop();
        }

        public byte[] ReceiveData(int length)
        {
            throw new NotImplementedException();
        }

        public bool SendData(byte[] buffer, int length)
        {
            throw new NotImplementedException();
        }

        public event DataReceivedEventHandler DataReceived;

        public event DisconnectedEventHandler Disconnected;

        public event ConnectedEventHandler Connected;

        public event DataReceiveTimeoutEventHandler DataReceiveTimeout;

        #endregion

        protected override bool DoWork()
        {
            return true;
        }
    }
}
