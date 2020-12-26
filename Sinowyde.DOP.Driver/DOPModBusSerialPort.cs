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
    public class DOPModBusSerialPort:DOPModBusWrapper
    {
        protected override int GetHeadLength()
        {
            return 5;
        }

        protected override int GetCommandReplyLength()
        {
            return 8;
        }

        public override IList<RtValue> GetDataFromBytes(byte[] buffer, IList<RtPoint> Points)
        {
            return AnalyzeFromBytes(buffer, Points);
        }

        public override byte[] GetReadInputRegisters(FunctionCode functionCode, int DeviceAddress, int StartAddress, int Offset)
        {
            return GetReadMessageData(functionCode, DeviceAddress, StartAddress - 1, Offset);
        }

        public override byte[] GetWriteRegistersMul(FunctionCode functionCode, DataType DataType, int DataLength, int StartAddress, IList<RtValue> data, int DeviceAddress)
        {
            byte[] headData = GetMessageHead(functionCode, DeviceAddress, StartAddress - 1, DataLength);
            byte[] dataArea = GetMessageData(headData, DataType, data);

            return GetDataCRC(dataArea);
        }

        public override byte[] CheckOutPackage(byte[] receiveData, bool IsWrite = false)
        {
            throw new NotImplementedException();
        }

    }
}
