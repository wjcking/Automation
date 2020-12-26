using Sinowyde.DOP.Communication;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.IO.Server.Properties;
using Sinowyde.Log;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sinowyde.DOP.IO.Server
{
    /// <summary>
    /// 数据通讯事件参数　
    /// </summary>
    public class DataCommuArgs : EventArgs
    {
        public MessageWrapper Message { get; set; }
    }
    /// <summary>
    /// 接收数据时间
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataReceivedEventHandler(object sender, DataCommuArgs e);


    /// <summary>
    /// 通讯线程
    /// </summary>
    public class CommuThread : ServiceThreadEx
    {      
        /// <summary>
        /// 接收数据事件
        /// </summary>
        public event DataReceivedEventHandler DataReceive;        
              
        //等待发送的报文
        public BufferManager<MessageWrapper> toSendMsgs = new BufferManager<MessageWrapper>();

        //等待返回的报文
        private MessageWrapper toReplayMsg = null;

        /// <summary>
        /// 上次数据发送时间
        /// </summary>
        private DateTime sendDataTime = DateTime.MinValue;        
        /// <summary>
        /// 通讯器
        /// </summary>
        public ICommunicator Communicator
        {
            get;
            private set;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="communicator"></param>
        public CommuThread(ICommunicator communicator)
            :base(10)
        {
            this.Communicator = communicator;
            this.Communicator.Connected += OnConnected;
            this.Communicator.DataReceived += OnDataReceived;
            this.Communicator.Disconnected += OnDisconnected;
        }

        /// <summary>
        /// 打开通讯
        /// </summary>
        protected override void InitThread()
        {
            LogMsg("准备建立与设备的连接");
            this.Communicator.Open();
        }

        /// <summary>
        /// 关闭通讯
        /// </summary>
        protected override void DestroyThread()
        {
            this.Communicator.Close();
        }

        /// <summary>
        /// 启动报文发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConnected(object sender, EventArgs e)
        {
            this.LogMsg("已经建立与设备的连接");
            //初始化状态
            InitEvn();
        }
        /// <summary>
        /// 日志消息头　
        /// </summary>
        private string LogMsgHead
        {
            get
            {
                return string.Format("[CommuThread][{0}]", this.Communicator.Name);
            }
        }
        /// <summary>
        /// 记录日志　
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        private void LogMsg(string msg, Exception ex=null)
        {
            string content = LogMsgHead + " " + msg;
            Console.WriteLine(content);
            if (ex != null)
                LogUtil.LogFatal(content, ex);
            else
                LogUtil.LogFatal(content);
        } 
                
        private int offset = 0;
        private volatile bool isFinishRec = true;
        /// <summary>
        /// 错误次数
        /// </summary>
        private volatile int errorCount = 0;
        public int MaxErrorCount
        {
            get;
            set;
        }
        private void InitEvn()
        {
            this.sendDataTime = DateTime.MinValue;
            this.isFinishRec = true;
            this.offset = 0;
            this.errorCount = 0;
        }
        /// <summary>
        /// //关闭报文发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDisconnected(object sender, ConnectedEventArgs e)
        {
            LogMsg("与设备断开连接");
        }

        /// <summary>
        /// 接收数据缓冲
        /// </summary>
        private byte[] receiveBuffer = new byte[1024];
        /// <summary>
        /// 接收数据事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            Array.Copy(e.Buffer, 0, this.receiveBuffer, offset, e.TranLength);
            offset += e.TranLength;
            if (offset >= toReplayMsg.ReplayMsg.Length)
            {
                Array.Copy(this.receiveBuffer, 0, toReplayMsg.ReplayMsg, 0, toReplayMsg.ReplayMsg.Length);
                LogMsg("[接收数据流:" + toReplayMsg.MsgToken + "]" + byteToHexStr(toReplayMsg.ReplayMsg));
                LogMsg("[时间差(毫秒)]" + DateTime.Now.Subtract(this.sendDataTime).Milliseconds.ToString());
                if (!toReplayMsg.IsSendCommand)
                {
                    if (this.DataReceive != null)
                        this.DataReceive(this, new DataCommuArgs { Message = toReplayMsg });
                }
                //恢复环境
                this.isFinishRec = true;
                this.offset -= toReplayMsg.ReplayMsg.Length;
                this.errorCount = 0;
            }
        }

        /// <summary>
        /// 周期发送数据
        /// </summary>
        /// <returns></returns>
        protected override bool DoWork()
        {
            //判断是否成功链接，重新连接
            if (!this.Communicator.IsConnected)
            {
                this.Communicator.Open();
                Thread.Sleep(3);
            }
            else
            {
                //错误次数太多，错误处理
                if (errorCount > MaxErrorCount)
                {
                    return false;
                }

                //验证是否超时
                if (!isFinishRec)
                {
                    if (DateTime.Now.Subtract(sendDataTime).TotalSeconds > 3)
                    {
                        LogMsg("消息过期, 清除消息" + this.toReplayMsg.MsgToken);
                        LogMsg("消息过期, 清除消息" + this.toReplayMsg.MsgToken);
                        errorCount++;
                    }
                }
                //发送数据
                else
                {
                    MessageWrapper message = null;
                    if (this.toSendMsgs.GetData(ref message) && message != null)
                    {
                        if (this.Communicator.SendData(message.SendMsg, message.SendMsg.Length))
                        {
                            this.toReplayMsg = message;
                            sendDataTime = DateTime.Now;
                            this.isFinishRec = false;
                            LogMsg("下发指令成功" + message.MsgToken + "下发时间" + DateTime.Now.ToString("HH:mm:ss"));
                            LogMsg("发送报文" + message.MsgToken + " " + byteToHexStr(message.SendMsg));
                        }
                        else
                        {
                            errorCount++;
                            LogMsg("下发指令失败" + message.MsgToken);
                        }

                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 处理通讯错误
        /// </summary>
        protected override void HandleFailure()
        {
            //关闭通讯连接，等待重启，需要验证是否需要
            this.Communicator.Close();
        }
        

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += " " + bytes[i].ToString("X2");
                }
            }
            return returnStr.Trim();
        }
    }
}
