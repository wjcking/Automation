using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.IO.Server
{
    public class RequestData
    {
        #region 属性
        /// <summary>
        /// 请求数据
        /// </summary>
        public byte[] requestData { get; set; }
        /// <summary>
        /// 锁
        /// </summary>
        private object _Lock = new object();
        /// <summary>
        /// 临时数据
        /// </summary>
        public byte[] TmpData;
        /// <summary>
        /// 临时数据长度
        /// </summary>
        public readonly int TmpDataSize = 1024;
        /// <summary>
        /// 请求数据长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 当前Socket
        /// </summary>
        public Socket socket = null;
        /// <summary>
        /// 客户端IP端口信息
        /// </summary>
        public IPEndPoint RemoteEndPoint { get; set; }
        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Watch = new Stopwatch();
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="obj"></param>
        public RequestData(Socket obj)
        {
            socket = obj;
            TmpData = new byte[TmpDataSize];
            this.requestData = null;
        }
        /// <summary>
        /// 添加请求数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        public void AppendData(byte[] data, int length)
        {
            lock (_Lock)
            {
                if (requestData == null)
                {
                    requestData = new byte[length];
                    Array.Copy(data, 0, requestData, 0, length);
                    this.Length = length;
                }
                else
                {
                    this.Length = requestData.Length + length;
                    byte[] newData = new byte[this.Length];
                    requestData.CopyTo(newData, 0);
                    Array.Copy(data, 0, requestData, 0, length);
                    requestData = newData;
                }
            }
        }

        /// <summary>
        /// 重置当前SocketObj内容
        /// </summary>
        public void Reset()
        {
            this.Watch.Reset();
            this.requestData = null;
        }

        /// <summary>
        /// 关闭套接字
        /// </summary>
        public void Close()
        {
            Reset();
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            else
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
