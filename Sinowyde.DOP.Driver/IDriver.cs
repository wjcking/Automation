using Sinowyde.DOP.DataModel;
using Sinowyde.RTModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Driver
{
    /// <summary>
    /// 消息定义
    /// </summary>
    public class MessageDefine
    {
        public IList<RtPoint> Points
        {
            get;
            set;
        }

        public byte[] MsgBuffer
        {
            get;
            set;
        }

        public int ReplyLength
        {
            get;
            set;
        }
    }

    public interface IDriver
    {
        /// <summary>
        /// 名称
        /// </summary>
        //string Name
        //{
        //    get;
        //}
        /// <summary>
        /// 从接收报文中获取地址
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        //int GetDeviceAddress(byte[] buffer);
        /// <summary>
        /// 解析报文数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        IList<RtValue> AnalyzeFromBytes(byte[] buffer, IList<RtPoint> Points);
        /// <summary>
        /// 发布采集报文
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        IList<MessageDefine> CreateRequestMsg(int address, IList<RtPoint> points, FunctionCode functionCode);
        /// <summary>
        /// 发布命令报文
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        IList<MessageDefine> CreateCommondMsg(int address, IList<RtPoint> points, IList<RtValue> values, FunctionCode functionCode);
    }
}
