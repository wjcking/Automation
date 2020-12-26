using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.RTModel;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.IO.Server
{
    public class MessageWrapper
    {
        /// <summary>
        /// 消息标记
        /// </summary>
        public string MsgToken
        {
            get;
            set;
        }
        /// <summary>
        /// 发送消息内容
        /// </summary>
        public Byte[] SendMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 返回消息内容,长度
        /// </summary>
        public Byte[] ReplayMsg
        {
            get;
            set;
        }
        
        /// <summary>
        /// 消息携带变量
        /// </summary>
        private IList<Variable> variables = null;
        public IList<Variable> Variables
        {
            get
            {
                return variables;
            }
            set
            {
                variables = value;
                this.Points = new List<RtPoint>();
                foreach (Variable variable in value)
                {
                    this.Points.Add(new RtPoint { Address=variable.Address, Number=variable.Number, DataType=variable.DataType });
                }
            }
        }
        /// <summary>
        /// 协议
        /// </summary>
        public string Protocol
        {
            get;
            set;
        }
        /// <summary>
        ///  是否是命令报文
        /// </summary>
        public bool IsSendCommand
        {
            get;
            set;
        }
        /// <summary>
        /// 点表
        /// </summary>
        public IList<RtPoint> Points
        {
            get;
            private set;

        }
    }
}
