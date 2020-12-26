using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 串口通道
    /// </summary>
    [Serializable]
    public class SerialChannel : IOChannel
    {
        public SerialChannel(IOChannel channel)
        {
            this.Name = channel.Name;
            this.CommuType = channel.CommuType;
            this.IP = channel.IP;
            this.Port = channel.Port;
            this.GatherPeriod = channel.GatherPeriod;
            this.Params = channel.Params;
        }
        /// <summary>
        /// 波特率
        /// </summary>
        public virtual int Baud { get; set; }

        /// <summary>
        /// 串口号
        /// </summary>
        public virtual string SerialNo { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        public virtual int DataBits { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        public virtual StopBits StopBits { get; set; }

        /// <summary>
        /// 奇偶校验
        /// </summary>
        public virtual Parity ParityVerify { get; set; }

        public override IOServer IOServer
        {
            get
            {
                return base.IOServer;
            }
            set
            {
                base.IOServer = value;
            }
        }
        /// <summary>
        /// 重载params
        /// </summary>
        public override string Params
        {
            get
            {
                return string.Format("{0} {1} {2} {3} {4}", this.SerialNo,
                    this.Baud, this.DataBits, this.StopBits, this.ParityVerify);
            }
            set
            {
                base.Params = value;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] results = value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (results.Length != 5)
                        return;
                    this.SerialNo = results[0];
                    this.Baud = ConvertUtil.ConvertToInt(results[1]);
                    this.DataBits = ConvertUtil.ConvertToInt(results[2]);
                    this.StopBits = (StopBits)Enum.Parse(typeof(StopBits), results[3]);
                    this.ParityVerify = (Parity)Enum.Parse(typeof(Parity), results[4]);
                }
            }
        }
    }
}
