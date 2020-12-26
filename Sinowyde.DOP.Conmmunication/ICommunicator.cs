using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Communication
{
    public class DataReceivedEventArgs : EventArgs
    {
        public string MsgToken { get; set; }
        public byte[] Buffer { get; set; }
        public int TranLength;
    }

    public class ConnectedEventArgs : EventArgs
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
    
    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);
    public delegate void ConnectedEventHandler(object sender, ConnectedEventArgs e);
    public delegate void DisconnectedEventHandler(object sender, ConnectedEventArgs e);
    

    public interface ICommunicator
    {
        string Name
        {
            get;
        }
        /// <summary>
        /// 打开通讯口，连接通讯口
        /// </summary>
        /// <returns></returns>
        bool Open();

        /// <summary>
        /// 关闭通讯口
        /// </summary>
        /// <returns></returns>
        bool Close();

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        byte[] ReceiveData(int length);

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        bool SendData(byte[] buffer, int length);

        /// <summary>
        /// 异步通知获取到数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        event DataReceivedEventHandler DataReceived;
        /// <summary>
        /// 断开事件
        /// </summary>
        event DisconnectedEventHandler Disconnected;
        /// <summary>
        /// 连接成功事件
        /// </summary>
        event ConnectedEventHandler Connected;
        
        /// <summary>
        /// 连接状态
        /// </summary>
        bool IsConnected
        {
            get;
        }
    }
}
