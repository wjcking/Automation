using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.RTModel;
using Sinowyde.Util;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.Driver
{

    public abstract class DOPModBusWrapper : IDriver
    {
        /// <summary>
        /// 包大小
        /// </summary>
        private const int packageSize = 248;

        protected abstract int GetHeadLength();

        /// <summary>
        /// 发布采集报文
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public IList<MessageDefine> CreateRequestMsg(int address, IList<RtPoint> points,FunctionCode functionCode = FunctionCode.ReadRegistersMul)
        {
            IList<MessageDefine> messageDefines = new List<MessageDefine>(); 
            //地址排序
            IList<RtPoint> lstPoints = points.OrderBy(v => v.Address).ToList();
            //根据数据类型分组
            IDictionary<DataType, IList<RtPoint>> pointMap = new Dictionary<DataType, IList<RtPoint>>();
            foreach (RtPoint point in lstPoints)
            {
                if (!pointMap.ContainsKey(point.DataType))
                    pointMap.Add(point.DataType, new List<RtPoint>());
                pointMap[point.DataType].Add(point);
            }
            foreach (DataType key in pointMap.Keys)
            {
                List<RtPoint> subPoints = new List<RtPoint>();
                for (int j=0; j<pointMap[key].Count; j++)
                {
                    RtPoint rtPoint = pointMap[key][j];
                    if (subPoints.Count == 0 || IsContinue(rtPoint.DataType, rtPoint.Address, subPoints.Last().Address))
                    {
                        subPoints.Add(rtPoint);
                        if (j < pointMap[key].Count - 1)
                        {
                           continue;
                        }
                    }
                    //构造报文
                    int dataLength = GetLength(subPoints.Last().DataType);
                    int totalLength = 0;
                    int packageCount = 0;
                    if (subPoints.Last().DataType.Equals(DataType.data_byte))
                    {
                        dataLength = (subPoints.Count % 8 == 0) ? (subPoints.Count / 8) : (subPoints.Count / 8 + 1);
                        totalLength = subPoints.Count;
                        packageCount = totalLength % packageSize > 0 ? totalLength / packageSize + 1 : totalLength / packageSize;
                        for (int i = 0; i < packageCount; i++)
                        {
                            var intAddress = subPoints.First().Address + i * packageSize;
                            var length = i == packageCount - 1 ? totalLength - i * packageSize : packageSize;
                            messageDefines.Add(new MessageDefine()
                            {
                                Points = subPoints.GetRange(i * packageSize / dataLength, length / dataLength),
                                MsgBuffer = this.GetReadInputRegisters(functionCode, address, intAddress, length / dataLength),
                                ReplyLength = dataLength + this.GetHeadLength()
                            });
                        }
                    }
                    else {
                        dataLength = dataLength * 2 ;
                        totalLength = dataLength * subPoints.Count;
                        packageCount = totalLength % packageSize > 0 ? totalLength / packageSize + 1 : totalLength / packageSize;
                        for (int i = 0; i < packageCount; i++)
                        {
                            var intAddress = subPoints.First().Address + i * packageSize / dataLength;
                            var length = i == packageCount - 1 ? totalLength - i * packageSize : packageSize;
                            messageDefines.Add(new MessageDefine()
                            {
                                Points = subPoints.GetRange(i * packageSize / dataLength, length / dataLength),
                                MsgBuffer = this.GetReadInputRegisters(functionCode, address, intAddress, length / dataLength),
                                ReplyLength = length + this.GetHeadLength()
                            });
                        }
                    }
                    //新报文
                    subPoints.Clear();
                    subPoints.Add(rtPoint);
                }
            }

            return messageDefines;
        }
        
        /// <summary>
        /// 发布命令报文
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public virtual IList<MessageDefine> CreateCommondMsg(int address, IList<RtPoint> points, IList<RtValue> values, FunctionCode functionCode = FunctionCode.WriteRegistersMul)
        {
            IList<MessageDefine> messageDefines = new List<MessageDefine>();
            //地址排序
            IList<RtPoint> lstPoints = points.OrderBy(v => v.Address).ToList();

            //根据数据类型分组
            IDictionary<DataType, IList<RtPoint>> pointMap = new Dictionary<DataType, IList<RtPoint>>();
            foreach (RtPoint point in lstPoints)
            {
                if (!pointMap.ContainsKey(point.DataType))
                    pointMap.Add(point.DataType, new List<RtPoint>());
                pointMap[point.DataType].Add(point);
            }

            IDictionary<string, RtValue> valueMap = new Dictionary<string, RtValue>();
            foreach (RtValue value in values)
            {
                valueMap.Add(value.Number, value);
            }

            foreach (DataType key in pointMap.Keys)
            {
                List<RtPoint> subPoints = new List<RtPoint>();
                for (int j = 0; j < pointMap[key].Count; j++)
                {
                    RtPoint rtPoint = pointMap[key][j];
                    //加入节点，并且　不是最后一个，则继续添加
                    if (subPoints.Count == 0 || IsContinue(rtPoint.DataType, rtPoint.Address, subPoints.Last().Address))
                    {
                        subPoints.Add(rtPoint);
                        if (j < pointMap[key].Count - 1)
                        {
                            continue;
                        }
                    }
                    //构造报文
                    int dataLength = GetLength(subPoints.Last().DataType);
                    int totalLength = 0;
                    int packageCount = 0;
                    if (subPoints.Last().DataType.Equals(DataType.data_byte))
                    {
                        totalLength = dataLength * subPoints.Count / 8;
                        packageCount = totalLength % packageSize > 0 ? totalLength / packageSize + 1 : totalLength / packageSize;
                        for (int i = 0; i < packageCount; i++)
                        {
                            var intAddress = subPoints.First().Address + i * packageSize * 8 / dataLength;
                            var length = i == packageCount - 1 ? totalLength - i * packageSize : packageSize;
                            MessageDefine define = new MessageDefine()
                            {
                                Points = subPoints.GetRange(i * packageSize * 8/ dataLength, length / dataLength),
                                ReplyLength = length + this.GetHeadLength()
                            };
                            IList<RtValue> rtValues = new List<RtValue>();
                            foreach (RtPoint point in define.Points)
                            {
                                rtValues.Add(valueMap[point.Number]);
                            }
                            define.MsgBuffer = this.GetWriteRegistersMul(functionCode, subPoints.First().DataType, length / dataLength, intAddress, rtValues, address);
                            define.ReplyLength = this.GetCommandReplyLength();

                            messageDefines.Add(define);
                        }
                    }
                    else {
                        dataLength *= 2;
                        totalLength = dataLength * subPoints.Count;
                        packageCount = totalLength % packageSize > 0 ? totalLength / packageSize + 1 : totalLength / packageSize;
                        for (int i = 0; i < packageCount; i++)
                        {
                            var intAddress = subPoints.First().Address + i * packageSize / dataLength;
                            var length = i == packageCount - 1 ? totalLength - i * packageSize : packageSize;
                            MessageDefine define = new MessageDefine()
                            {
                                Points = subPoints.GetRange(i * packageSize / dataLength, length / dataLength),
                                ReplyLength = length + this.GetHeadLength()
                            };
                            IList<RtValue> rtValues = new List<RtValue>();
                            foreach (RtPoint point in define.Points)
                            {
                                rtValues.Add(valueMap[point.Number]);
                            }
                            define.MsgBuffer = this.GetWriteRegistersMul(functionCode, subPoints.First().DataType, length / dataLength, intAddress, rtValues, address);
                            define.ReplyLength = this.GetCommandReplyLength();

                            messageDefines.Add(define);
                        }
                    }
                    //新报文
                    subPoints.Clear();
                    subPoints.Add(rtPoint);
                }
            }

            return messageDefines;

        }

        protected abstract int GetCommandReplyLength();
        
        #region 读写数据基本方法
        public abstract byte[] GetReadInputRegisters(FunctionCode functionCode, int DeviceAddress, int StartAddress, int Offset);

        public abstract byte[] GetWriteRegistersMul(FunctionCode functionCode, DataType DataType, int DataLength, int StartAddress, IList<RtValue> data, int DeviceAddress);
        #endregion

        #region 报文处理方法
        /// <summary>
        /// 取得接收数据
        /// </summary>
        /// <param name="buffer">接收字节对象</param>
        /// <param name="dataType">数据类型</param>
        /// <returns></returns>
        public abstract IList<RtValue> GetDataFromBytes(byte[] buffer, IList<RtPoint> Points);

        /// <summary>
        /// 检查数据是否有效
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public bool CheckResponse(byte[] buffer)
        {
            if (buffer == null || buffer.Length < 2) return false;
            byte[] crc = new byte[2];
            byte[] bytes = new byte[buffer.Length - 2];
            Array.Copy(buffer, 0, bytes, 0, buffer.Length - 2);
            crc = GetCRC(bytes);
            if (crc[0] == buffer[buffer.Length - 1] && crc[1] == buffer[buffer.Length - 2])
                return true;
            else
                return false;
        }

        /// <summary>
        /// 取得校验码
        /// </summary>
        /// <param name="buffer">校验字节对象</param>
        /// <returns></returns>
        public virtual byte[] GetCRC(byte[] buffer)
        {
            ushort crcFull = 0xFFFF;
            byte crcHigh = 0xFF, crcLow = 0xFF;
            char crcLSB;
            List<byte> crc = new List<byte>(2);
            for (int i = 0; i < (buffer.Length); i++)
            {
                crcFull = (ushort)(crcFull ^ buffer[i]);
                for (int j = 0; j < 8; j++)
                {
                    crcLSB = (char)(crcFull & 0x0001);
                    crcFull = (ushort)((crcFull >> 1) & 0x7FFF);
                    if (crcLSB == 1)
                        crcFull = (ushort)(crcFull ^ 0xA001);
                }
            }
            crc.Add(crcHigh = (byte)((crcFull >> 8) & 0xFF));
            crc.Add(crcLow = (byte)(crcFull & 0xFF));
            return crc.ToArray();
        }

        /// <summary>
        /// 得到CRC校验部分
        /// </summary>
        /// <param name="data">数据对象</param>
        /// <returns></returns>
        public virtual byte[] GetDataCRC(byte[] data)
        {
            byte[] bytes = new byte[data.Length + 2];
            data.CopyTo(bytes, 0);
            var crc = GetCRC(data);
            bytes[bytes.Length - 2] = crc[1];
            bytes[bytes.Length - 1] = crc[0];

            return bytes;
        }

        /// <summary>
        /// 数据包首部分
        /// </summary>
        /// <param name="DeviceAddress">设备地址</param>
        /// <param name="functionCode">功能码</param>
        /// <param name="StartAddress">寄存器地址</param>
        /// <param name="len">数据长度，或单个数据</param>
        /// <returns>包头部分</returns>
        public virtual byte[] GetMessageHead(FunctionCode functionCode, int DeviceAddress, int StartAddress, int len)
        {
            byte[] head = new byte[6];
            head[0] = Convert.ToByte(DeviceAddress);
            head[1] = (byte)functionCode;
            head[2] = (byte)(StartAddress >> 8);
            head[3] = (byte)(StartAddress & 0xFF);
            head[4] = (byte)(len >> 8);
            head[5] = (byte)(len & 0xFF);

            return head;
        }

        /// <summary>
        /// 通用读数据
        /// </summary>
        /// <param name="functionCode">功能码</param>
        /// <param name="DeviceAddress">设备地址</param>
        /// <param name="Points">数据类型</param>
        /// <returns></returns>
        public virtual byte[] GetReadMessageData(FunctionCode functionCode, int DeviceAddress, int StartAddress, int Offset)
        {
            byte[] bytes = new byte[6];
            string strOffset = Convert.ToString(Offset, 16).PadLeft(4, '0');
            string strStartAddress = Convert.ToString(StartAddress, 16).PadLeft(4, '0');
            bytes[0] = (byte)DeviceAddress;
            bytes[1] = (byte)functionCode;
            bytes[2] = Convert.ToByte(strStartAddress.Substring(0, 2), 16);
            bytes[3] = Convert.ToByte(strStartAddress.Substring(2, 2), 16);
            bytes[4] = Convert.ToByte(strOffset.Substring(0, 2), 16);
            bytes[5] = Convert.ToByte(strOffset.Substring(2, 2), 16);

            return GetDataCRC(bytes);
        }

        /// <summary>
        /// 计算数据长度,得到写数据报文
        /// </summary>
        /// <param name="DataHead">包首部分</param>
        /// <param name="dataType">数据类型</param>
        /// <param name="data">数据</param>
        /// <returns>数据包及包头部分</returns>
        public virtual byte[] GetMessageData(byte[] DataHead, DataType dataType, IList<RtValue> data)
        {
            byte[] bytes = null;
            var index = DataHead.Length;
            var datalen = data.Count;
            switch (dataType)
            {
                case DataType.data_byte:
                    var strData = new StringBuilder();
                    datalen = (datalen % 8 == 0) ? (datalen / 8) : (datalen / 8 + 1);
                    bytes = new byte[index + datalen + 1];
                    DataHead.CopyTo(bytes, 0);
                    bytes[index] = (byte)(datalen);
                    for (int i = 0; i < datalen; i++)
                    {
                        strData.Append(data[i].Value);
                    }
                    bytes[bytes.Length - 1] = (byte)Convert.ToInt32(strData.ToString(), 2);
                    break;
                case DataType.data_ushort:
                    bytes = new byte[index + datalen * 2 + 1];
                    DataHead.CopyTo(bytes, 0);
                    bytes[index] = (byte)(datalen * 2);
                    for (int i = 0; i < datalen; i++)
                    {
                        var array = BitConverter.GetBytes(Convert.ToInt16(data[i].Value));
                        Array.Reverse(array);
                        bytes[index + 1] = array[0];
                        bytes[index + 2] = array[1];
                        index += 2;
                    }
                    break;
                case DataType.data_short:
                    bytes = new byte[index + datalen * 2 + 1];
                    DataHead.CopyTo(bytes, 0);
                    bytes[index] = (byte)(datalen);
                    for (int i = 0; i < datalen; i++)
                    {
                        var array = BitConverter.GetBytes(ConvertUtil.ConvertToInt(data[i].Value));
                        Array.Reverse(array);
                        bytes[index + 1] = array[0];
                        bytes[index + 2] = array[1];
                        index += 2;
                    }
                    break;
                case DataType.data_float:
                    bytes = new byte[index + datalen * 4 + 1];
                    DataHead.CopyTo(bytes, 0);
                    bytes[index] = (byte)(datalen);
                    for (int i = 0; i < datalen; i++)
                    {
                        var array = BitConverter.GetBytes(ConvertUtil.ConvertToFloat(data[i].Value));
                        Array.Reverse(array);
                        bytes[index + 1] = array[2];
                        bytes[index + 2] = array[3];
                        bytes[index + 3] = array[0];
                        bytes[index + 4] = array[1];
                        index += 4;
                    }
                    break;
                default:
                    break;
            }

            return bytes;
        }

        /// <summary>
        /// 解析报文数据
        /// </summary>
        /// <param name="buffer">报文</param>
        /// <param name="Points">数据类型</param>
        /// <returns>数据对象</returns>
        public virtual IList<RtValue> AnalyzeFromBytes(byte[] buffer, IList<RtPoint> Points)
        {
            if (buffer == null || buffer.Length < 6) return null;
            IList<RtValue> data = new List<RtValue>();
            int j = 0;
            if (CheckResponse(buffer))
            {
                var len = ConvertUtil.ConvertToInt(buffer[2]);
                int count = 0;
                byte[] bytes = null;
                switch (Points[0].DataType)
                {
                    case DataType.data_byte:
                        bytes = new byte[len];
                        Array.Copy(buffer, 3, bytes, 0, len);
                        data = GetSwitchValue(bytes);
                        break;
                    case DataType.data_ushort:
                        count = len / 2;
                        for (int i = 0; i < count; i++)
                        {
                            bytes = new byte[2];
                            Array.Copy(buffer, 3 + i * 2, bytes, 0, 2);
                            data.Add( new RtValue() { Number = Points[j].Number,
                                Value = BitConverter.ToInt16(ArraySequence(bytes, new List<Int16>() { 1, 0 }),0) });
                            j += 1;
                        }
                        break;
                    case DataType.data_int:
                    case DataType.data_long:
                    case DataType.data_short:
                        count = len / 4;
                        for (int i = 0; i < count; i++)
                        {
                            bytes = new byte[4];
                            Array.Copy(buffer, 3 + i * 4, bytes, 0, 4);
                            data.Add(new RtValue()
                            {
                                Number = Points[j].Number,
                                Value = BitConverter.ToUInt32(ArraySequence(bytes, new List<Int16>() { 1, 0, 3, 2 }), 0)
                            });
                        }
                        break;
                    case DataType.data_float:
                        count = len / 4;
                        for (int i = 0; i < count; i++)
                        {
                            bytes = new byte[4];
                            Array.Copy(buffer, 3 + i * 4, bytes, 0, 4);
                            data.Add(new RtValue()
                            {
                                Number = Points[j].Number,
                                Value = BitConverter.ToSingle(ArraySequence(bytes, new List<Int16>() { 1, 0, 3, 2 }), 0)
                            });
                        }
                        break;
                    default:
                        break;
                }
            }

            return data;
        }

        /// <summary>
        /// 数组排序
        /// </summary>
        /// <param name="data">字节对象</param>
        /// <param name="dataSequence">排序</param>
        /// <returns>排序后数组对象</returns>
        public byte[] ArraySequence(byte[] data, IList<Int16> dataSequence)
        {
            byte[] buffer = new byte[data.Length];
            for (Int16 i = 0; i < data.Length; i++)
            {
                buffer[i] = data[dataSequence[i]];
            }

            return buffer;
        }

        /// <summary>
        /// 取得开关量值
        /// </summary>
        /// <param name="buffer">字节对象</param>
        /// <returns></returns>
        public IList<RtValue> GetSwitchValue(byte[] buffer)
        {
            var data = new List<RtValue>();
            StringBuilder strData = new StringBuilder();
            for (int i = buffer.Length - 1; i >= 0; i--)
            {
                strData.Append(Convert.ToString(buffer[i], 2).PadLeft(8, '0'));
            }
            char[] charData = new char[strData.Length];
            strData.CopyTo(0, charData, 0, strData.Length);
            Array.Reverse(charData);
            foreach (char c in charData)
            {
                var d = new RtValue();
                d.Value = ConvertUtil.ConvertToInt(c);
                data.Add(d);
            }
            return data;
        }

        /// <summary>
        /// 取得偏移量值
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <returns></returns>
        public int GetOffset(DataType dataType)
        {
            int offset = 0;
            switch (dataType)
            { 
                case DataType.data_ushort:
                    offset = 1;
                    break;
                case DataType.data_short:
                case DataType.data_float:
                case DataType.data_long:
                    offset = 2;
                    break;
                default:
                    break;
            }

            return offset;
        }

        public abstract byte[] CheckOutPackage(byte[] receiveData,bool IsWrite = false);
        #endregion

        /// <summary>
        /// 变量是否连续
        /// </summary>
        /// <param name="DataType">数据类型</param>
        /// <param name="RegisterAddress">寄存器地址</param>
        /// <param name="oldRegisterAddress">寄存器地址（前一变量）</param>
        /// <returns></returns>
        private bool IsContinue(DataType DataType, object RegisterAddress, object oldRegisterAddress)
        {
            var length = GetLength(DataType);
            if (ConvertUtil.ConvertToInt(RegisterAddress) - ConvertUtil.ConvertToInt(oldRegisterAddress) == length)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 取得数据长度
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <returns></returns>
        private int GetLength(DataType dataType)
        {
            int length = 0;
            switch (dataType)
            {
                case DataType.data_ushort:
                    length = 1;
                    break;
                case DataType.data_short:
                case DataType.data_float:
                case DataType.data_long:
                    length = 2;
                    break;
                default:
                    length = 1;
                    break;
            }

            return length;
        }
    }
}
