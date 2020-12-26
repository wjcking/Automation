using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Sinowyde.Log;
using Sinowyde.Util;

namespace Sinowyde.DOP.IO.Server
{
    public class TCPServerWrapper
    {
        #region 变量属性
        public event DataReceivedEventHandler DataReceived;
        public event DisconnectedEventHandler Disconnected;
        public event ConnectedEventHandler Connected;

        private ManualResetEvent manualResetEventLock = new ManualResetEvent(false);

        public delegate byte[] IResponse(byte[] buffer, IPEndPoint ipEndPoint);

        private Socket socketListener;

        private int maxCount = 100;

        private bool IsStoping = false;

        private int threadCount = 0;

        private object threadCountLock = new object();

        /// <summary>
        /// IP地址
        /// </summary>
        public IPAddress IpAddress
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
                return false;
            }
        }

        /// <summary>
        /// 线程数
        /// </summary>
        public int ThreadCount
        {
            get
            {
                return threadCount;
            }
            private set
            {
                lock (threadCountLock)
                {
                    threadCount = value;
                }
            }
        }
        /// <summary>
        /// 处理Socket请求的方法
        /// </summary>
        public IResponse responseMethod { private get; set; }

        /// <summary>
        /// 根目录
        /// </summary>
        public string Root { get; set; }
        #endregion

        #region 基础方法
        /// <summary>
        /// 初始化Socket服务器
        /// </summary>
        /// <param name="port">端口</param>
        /// <param name="maxCount">最大监听数</param>
        public TCPServerWrapper(int port, int maxCount)
        {
            this.Port = port;
            this.maxCount = maxCount;
            this.IpAddress = GetLocalIPAddress();
            responseMethod = null;
        }

        /// <summary>
        /// 初始化Socket服务器
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="maxCount">最大监听数</param>
        public TCPServerWrapper(string ipAddress, int port, int maxCount)
        {
            this.Port = port;
            this.maxCount = maxCount;
            IpAddress = IPAddress.Parse(ipAddress);
            responseMethod = null;
        }

        /// <summary>
        /// 取得本地IP地址
        /// </summary>
        /// <returns></returns>
        private IPAddress GetLocalIPAddress()
        {
            IPAddress ipAddress = null;
            Regex reg = new Regex("^(\\d+\\.){3}\\d+$");
            foreach (IPAddress eachIp in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (reg.IsMatch(eachIp.ToString()))
                {
                    ipAddress = eachIp;
                    break;
                }
            }

            return ipAddress;
        }

        /// <summary>
        /// 默认的响应方法
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="ipEndPoint"></param>
        /// <returns></returns>
        private byte[] GetResponseData(byte[] buffer, IPEndPoint ipEndPoint)
        {
            if (this.DataReceived != null)
                this.DataReceived(this, new DataReceivedEventArgs()
                {
                    Buffer = buffer,
                });
            return buffer;
            //return Encoding.UTF8.GetBytes("Response");
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        public bool Run()
        {
            if (responseMethod == null)
                responseMethod = this.GetResponseData;
            this.ThreadCount = 0;
            this.IsStoping = false;
            Thread thread = new Thread(Listen);
            thread.Start();
            if(this.Connected!=null)
                this.Connected(this,null);
            return true;
        }

        /// <summary>
        /// 停止Socket服务器
        /// </summary>
        public bool Stop()
        {
            this.IsStoping = true;
            if(this.Disconnected!=null)
                this.Disconnected(this,null);
            return this.IsStoping;
        }

        /// <summary>
        /// 监听
        /// </summary>
        private void Listen()
        {
            try
            {
                ThreadCount += 1;
                IPEndPoint localIpEndPoint = new IPEndPoint(this.IpAddress, this.Port);
                socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketListener.Bind(localIpEndPoint);
                socketListener.Listen(maxCount);
                while (!IsStoping)
                {
                    this.manualResetEventLock.Reset();
                    socketListener.BeginAccept(new AsyncCallback(AcceptCallBack), null);
                    this.manualResetEventLock.WaitOne();
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("[TCPServerWrapper]Listen异常" + ex.Message);
                Console.WriteLine("[TCPServerWrapper]Listen异常" + ex.Message);
            }
            finally
            {
                ThreadCount -= 1;
            }
        }

        private void AcceptCallBack(IAsyncResult iar)
        {
            try
            {
                ThreadCount += 1;
                this.manualResetEventLock.Set();
                if (this.IsStoping) return;
                Socket currentSocket = socketListener.EndAccept(iar);
                RequestData currentSocketObj = new RequestData(currentSocket);
                currentSocket.BeginReceive(currentSocketObj.TmpData, 0, currentSocketObj.TmpDataSize, 0, new AsyncCallback(ProcessRequest), currentSocketObj);
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("[TCPServerWrapper]AcceptCallBack异常" + ex.Message);
                Console.WriteLine("[TCPServerWrapper]AcceptCallBack异常" + ex.Message);
            }
            finally
            {
                ThreadCount -= 1;
            }
        }

        private void ProcessRequest(IAsyncResult iar)
        {
            RequestData requestData = (RequestData)iar.AsyncState;
            Socket currentSocket = requestData.socket;
            ThreadCount += 1;
            try
            {
                if (this.IsStoping)
                {
                    requestData.Close();
                    return;
                }
                requestData.RemoteEndPoint = (IPEndPoint)currentSocket.RemoteEndPoint;
                int byteLen = currentSocket.EndReceive(iar);
                if (byteLen > 0)
                {
                    if (requestData.requestData == null)
                        requestData.Watch.Start();
                    requestData.AppendData(requestData.TmpData, byteLen);
                    if (byteLen != requestData.TmpDataSize)
                    {
                        //获取响应数据
                        byte[] ResponseData = responseMethod(requestData.requestData, requestData.RemoteEndPoint);
                        currentSocket.BeginSend(ResponseData, 0, ResponseData.Length, 0, new AsyncCallback(SendCallback), requestData);
                        requestData.Watch.Stop();
                        requestData.Reset();
                    }
                    currentSocket.BeginReceive(requestData.TmpData, 0, requestData.TmpDataSize, 0, new AsyncCallback(ProcessRequest), requestData);
                }
            }
            catch (Exception ex)
            {
                requestData.Reset();
                LogUtil.LogFatal("[TCPServerWrapper]ProcessRequest异常" + ex.Message);
                Console.WriteLine("[TCPServerWrapper]ProcessRequest异常" + ex.Message);
            }
            finally
            {
                ThreadCount -= 1;
            }
        }

        private void SendCallback(IAsyncResult iar)
        {
            RequestData requestData = (RequestData)iar.AsyncState;
            requestData.socket.EndSend(iar);
        }

        /// <summary>
        /// 重启Socket服务器
        /// </summary>
        public void Restart()
        {
            Stop();
            //发送解锁信号
            this.manualResetEventLock.Set();
            Stopwatch stopwatch = new Stopwatch();
            while (true)
            {
                Thread.Sleep(1000);
                if (this.ThreadCount < 1)
                    break;
                if (stopwatch.ElapsedMilliseconds > 40000)
                {
                    stopwatch.Reset();
                    return;
                }
            }
            socketListener.Close();
            this.Run();
        }
        #endregion
    }
}
