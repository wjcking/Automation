using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Log;
using Sinowyde.Util;

namespace Sinowyde.DOP.Communication
{
    public class TCPClientWrapper : ICommunicator
    {
        public string Name
        {
            get
            {
                return "Tcp:" + this.IpAddress + ":" + this.Port.ToString();
            }
        }

        #region 变量属性
        private Socket tcpClient = null;
        private byte[] receiveBuffer = null;
        private ObjectPool<SocketAsyncEventArgs> argsSendPool;
        //接受到数据
        public event DataReceivedEventHandler DataReceived;
        public event DisconnectedEventHandler Disconnected;
        public event ConnectedEventHandler Connected;

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 通讯端口
        /// </summary>
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// 数据大小
        /// </summary>
        public int BufferSize
        {
            get;
            private set;
        }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return tcpClient == null ? false : tcpClient.Connected;
            }
        }

        private const int poolCapacity = 200;

        private const int bufferSize = 1024;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ipAddress">通讯ＩＰ地址</param>
        /// <param name="port">端口</param>
        public TCPClientWrapper(string ipAddress, int port)
        {
            this.IpAddress = ipAddress;
            this.Port = port;
            this.BufferSize = bufferSize;
            this.receiveBuffer = new Byte[bufferSize];
            argsSendPool = new ObjectPool<SocketAsyncEventArgs>(poolCapacity);
        }

        /// <summary>
        /// 打开通讯连接
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                if (tcpClient != null)
                    tcpClient.Close();
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(this.IpAddress), this.Port);                
                tcpClient.Connect(endPoint);
                if (this.Connected != null)
                    this.Connected(this, new ConnectedEventArgs() { 
                         Address = this.IpAddress,
                         Port =this.Port
                    });
                //发起数据接收
                this.BeginReceive();
                return true;
            }
            catch (Exception)
            {
                LogUtil.LogFatal("[TCPClient]连接出错");
                this.CloseAndNotify();
                return false;
            }
        }

        public bool OpenAsync()
        {
            try
            {
                if (tcpClient != null)
                    tcpClient.Close();
                tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(this.IpAddress), this.Port);
                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.RemoteEndPoint = endPoint;
                args.Completed += this.ConnectAsync_Completed;
                if (!this.tcpClient.ConnectAsync(args))
                    this.ConnectAsync_Completed(null, args);               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 异步连接完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                LogUtil.LogFatal("[TCPClient]连接出错");
                this.CloseAndNotify();
            }
            else
            {
                if (this.Connected != null)
                    this.Connected(this, new ConnectedEventArgs() { 
                         Address = this.IpAddress,
                         Port =this.Port
                    });
                //发起数据接收
                this.BeginReceive();
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public bool Close()
        {
            try
            {
                if (tcpClient != null)
                    tcpClient.Close();

                return true;
            }
            catch (Exception)
            {
                return tcpClient.Connected;
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
        /// 异步发送数据
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendData(byte[] msg, int length = 0)
        {
            try
            {
                if (this.IsConnected)
                {
                    SocketAsyncEventArgs args = argsSendPool.GetObject();
                    args.Completed -= this.SendAsync_Completed;
                    args.Completed += this.SendAsync_Completed;
                    if (length == 0)
                        length = msg.Length;
                    args.SetBuffer(msg, 0, length);
                    BeginSend(args);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BeginSend(SocketAsyncEventArgs args)
        {
            try
            {
                if (!this.tcpClient.SendAsync(args))
                {
                    this.SendAsync_Completed(this, args);
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("[TCPClient]发送数据异常", ex);
                this.CloseAndNotify();
            }
        }
        /// <summary>
        /// 发送数据完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                LogUtil.LogFatal("[TCPClient]发送数据出错");
                this.CloseAndNotify();
            }
            else
            {
                if (e.BytesTransferred < e.Count)
                {
                    LogUtil.LogWarn(string.Format("[TCPClient]发送不完全, 已发送:{0}字节, 未发送:{1}字节", e.BytesTransferred, e.Count - e.BytesTransferred));
                    e.SetBuffer(e.Offset + e.BytesTransferred, e.Count - e.BytesTransferred);
                    this.BeginSend(e);
                }
                else
                {
                    argsSendPool.PutObject(e);
                }
            }
        }
        /// <summary>
        /// 发起接收数据
        /// </summary>
        private void BeginReceive()
        {
            SocketAsyncEventArgs arg = new SocketAsyncEventArgs();
            arg.SetBuffer(this.receiveBuffer, 0, BufferSize);
            arg.Completed += receiveAsync_Completed;
            BeginReceive(arg);
        }

        private void BeginReceive(SocketAsyncEventArgs arg)
        {
            try
            {
                if (!this.tcpClient.ReceiveAsync(arg))
                {
                    receiveAsync_Completed(this, arg);
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("[TCPClient]接收数据异常", ex);
                Console.WriteLine("[TCPClient]接收数据异常"+ex.Message);
                this.CloseAndNotify();
            }
        }

        /// <summary>
        /// 接收数据完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receiveAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success || e.BytesTransferred == 0)
            {
                LogUtil.LogFatal("[TCPClient]接收数据出错");
                Console.WriteLine("[TCPClient]接收数据出错");
                this.CloseAndNotify();
            }
            else
            {
                if (DataReceived != null)
                {
                    DataReceived(this, new DataReceivedEventArgs()
                    { 
                         Buffer=e.Buffer,
                         TranLength=e.Offset + e.BytesTransferred
                    });
                }
                e.SetBuffer(this.receiveBuffer, 0, BufferSize);
                BeginReceive(e);
            }
        }

        public byte[] ReceiveData(int length)
        {
            throw new NotImplementedException();
        }
    }
}
