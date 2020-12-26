using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.RTModel;
using Sinowyde.Util;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.Driver
{
    public class DOPModBusTCP:DOPModBusWrapper
    {
        protected override int GetHeadLength()
        {
            return 9;
        }

        protected override int GetCommandReplyLength()
        {
            return 12;
        }

        public override IList<RTModel.RtValue> GetDataFromBytes(byte[] buffer, IList<RTModel.RtPoint> Points)
        {
            return AnalyzeFromBytes(buffer, Points);
        }

        public override byte[] GetReadInputRegisters(FunctionCode functionCode, int DeviceAddress, int StartAddress, int Offset)
        {
            return GetReadMessageData(functionCode, DeviceAddress, StartAddress - 1, Offset);
        }
               

        public override byte[] GetWriteRegistersMul(FunctionCode functionCode, DataType DataType, int DataLength, int StartAddress, IList<RTModel.RtValue> data, int DeviceAddress)
        {
            byte[] headData = GetReadMessageData(functionCode, DeviceAddress, StartAddress - 1, DataLength);
            byte[] dataArea = GetMessageData(headData, DataType, data);

            return dataArea;
        }


        public override byte[] GetReadMessageData(FunctionCode functionCode, int DeviceAddress, int StartAddress, int Offset)
        {
            List<byte> sendData = new List<byte>(255);
            short dataIndex = 255;
            sendData.AddRange(ValueHelper.GetBytes(dataIndex));
            sendData.AddRange(new byte[] { 0, 0 });
            sendData.AddRange(ValueHelper.GetBytes((short)6));
            sendData.Add((byte)DeviceAddress);
            sendData.Add((byte)functionCode);
            sendData.AddRange(ValueHelper.GetBytes((short)StartAddress));
            sendData.AddRange(ValueHelper.GetBytes((short)Offset));

            return sendData.ToArray();

        }

        /// <summary>
        /// 校验数据包是否合法
        /// </summary>
        /// <param name="receiveData">接收数据对象</param>
        /// <returns></returns>
        public override byte[] CheckOutPackage(byte[] receiveData, bool IsWrite = false)
        {
            short identifier = (short)((((short)receiveData[0]) << 8) + receiveData[1]);
            //请求的数据标识与返回的标识不一致，则丢掉数据包
            if (identifier != 255)
            {
                return null;
            }
            //最后一个字节，记录寄存器中数据的Byte数
            int length = 0;
            int index = 0;
            if (IsWrite)
            {
                length = 12;
            }
            else {
                length = ConvertUtil.ConvertToInt(receiveData[8]) + 3;
                index = 6;
            }
            byte[] result = new byte[length];
            Array.Copy(receiveData, index, result, 0, length);
            return result;
        }

        public override IList<RTModel.RtValue> AnalyzeFromBytes(byte[] buffer, IList<RTModel.RtPoint> Points)
        {
            if (buffer == null || buffer.Length < 9) return null;
            IList<RtValue> data = new List<RtValue>();
            if (buffer!=null)
            {
                var len = ConvertUtil.ConvertToInt(buffer[8]);
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
                            Array.Copy(buffer, 9 + i * 2, bytes, 0, 2);
                            data.Add(new RtValue() { Number = Points[i].Number, Value = BitConverter.ToInt16(ArraySequence(bytes, new List<Int16>() { 1, 0 }), 0)});
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
                            data.Add(new RtValue() { Number = Points[i].Number, Value = BitConverter.ToInt32(ArraySequence(bytes, new List<Int16>() { 1, 0, 3, 2 }), 0) });
                        }
                        break;
                    case DataType.data_float:
                        count = len / 4;
                        for (int i = 0; i < count; i++)
                        {
                            bytes = new byte[4];
                            Array.Copy(buffer, 3 + i * 4, bytes, 0, 4);
                            data.Add(new RtValue() { Number = Points[i].Number, Value = BitConverter.ToSingle(ArraySequence(bytes, new List<Int16>() { 1, 0, 3, 2 }), 0) });
                        }
                        break;
                    default:
                        break;
                }
            }

            return data;
        }

        #region Transaction Identifier
        /// <summary>
        /// 数据序号标识
        /// </summary>
        private byte dataIndex = 0;

        protected byte CurrentDataIndex
        {
            get
            {
                return this.dataIndex;
            }
        }

        protected byte NextDataIndex()
        {
            return ++this.dataIndex;
        }
        #endregion
       
    }
}
