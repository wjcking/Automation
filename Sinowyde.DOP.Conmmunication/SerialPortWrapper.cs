using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace Sinowyde.DOP.Communication
{
    public class SerialPortWrapper : ICommunicator
    {
        public string Name
        {
            get
            {
                return "SerialPort:" + PortName;
            }
        }
        #region 变量属性
        /// <summary>
        /// 串口对象
        /// </summary>
        private SerialPort serialPort = new SerialPort();

        public event DisconnectedEventHandler Disconnected;
        public event ConnectedEventHandler Connected;
        public event DataReceivedEventHandler DataReceived;
        /// <summary>
        /// 端口名称
        /// </summary>
        public string PortName
        {
            get
            {
                return serialPort.PortName;
            }
            set
            {
                serialPort.PortName = value;
            }
        }
        /// <summary>
        /// 设置波特率
        /// </summary>
        public int BaudRate
        {
            get
            {
                return serialPort.BaudRate;
            }
            set
            {
                serialPort.BaudRate = value;
            }
        }
        /// <summary>
        /// 奇偶校验
        /// </summary>
        public Parity Parity
        {
            get
            {
                return serialPort.Parity;
            }
            set
            {
                serialPort.Parity = value;
            }
        }
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits
        {
            get
            {
                return this.serialPort.DataBits;
            }
            set
            {
                this.serialPort.DataBits = DataBits;
            }
        }
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits
        {
            get
            {
                return serialPort.StopBits;
            }
            set
            {
                serialPort.StopBits = value;
            }
        }
        /// <summary>
        /// 读超时
        /// </summary>
        public int ReadTimeout
        {
            get
            {
                return serialPort.ReadTimeout;
            }
            set
            {
                serialPort.ReadTimeout = value;
            }
        }
        /// <summary>
        /// 写超时
        /// </summary>
        public int WriteTimeout
        {
            get
            {
                return this.serialPort.WriteTimeout;
            }
            set
            {
                this.serialPort.WriteTimeout = value;
            }
        }

        /// <summary>
        /// 串口是否打开
        /// </summary>
        public bool IsConnected
        {
            get 
            {
                return this.serialPort.IsOpen;
            }
        }
        #endregion

        public SerialPortWrapper()
        {
            serialPort.DataReceived += serialPort_DataReceived;
            this.serialPort.ReadTimeout = 1000;
            this.serialPort.WriteTimeout = 1000;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                serialPort.Open();
                if (this.Connected != null)
                    this.Connected(this, null);
                return IsConnected;
            }
            catch (Exception)
            {
                CloseAndNotify();
                return false;
            }
        }
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                serialPort.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭连接，同时通知外部
        /// </summary>
        public void CloseAndNotify()
        {
            Close();
            if (this.Disconnected != null)
                this.Disconnected(this, null);
        }
        /// <summary>
        /// 接收数据（同步接收数据）
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] ReceiveData(int length)
        {
            int start = 0;
            byte[] buffer = new byte[length];
            while (start < length)
            {
                int rec = serialPort.Read(buffer, start, length - start);
                start += rec;
                Thread.Sleep(1);
            }
            return buffer;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        public bool SendData(byte[] buffer, int length)
        {
            try
            {
                this.serialPort.DiscardInBuffer();
                this.serialPort.DiscardOutBuffer();
                this.serialPort.Write(buffer, 0, length);
                return true;
            }
            catch (Exception)
            {
                CloseAndNotify();
                return false; ;
            }
        }

        /// <summary>
        /// 接收数据（异步接收数据）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] buffer = new byte[this.serialPort.BytesToRead];
                this.serialPort.Read(buffer, 0, buffer.Length);
                if (buffer.Length == 0) { return; }
                if (DataReceived != null)
                    this.DataReceived(this, new DataReceivedEventArgs() { Buffer = buffer, TranLength = buffer.Length });
            }
            catch (Exception)
            {
                CloseAndNotify();
            }
        }
    }
}
