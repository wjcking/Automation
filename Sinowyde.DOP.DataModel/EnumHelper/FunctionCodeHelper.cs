using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// 功能码
    /// </summary>
    public enum FunctionCode : byte
    {
        ReadCoilSingle = 1,         //读取线圈状态
        ReadInputStatus = 2,        //读取输入状态
        ReadRegistersMul = 3,       //保持型寄存器读取
        ReadInputRegisters = 4,     //读取输入寄存器
        WriteCoilSingle = 5,        //写单一线圈
        WriteRegistersSingle = 6,   //写单一寄存器
        WriteCoilMul = 15,          //多点写入(强置多线圈)
        WriteRegistersMul = 16,     //预置多寄存器  
    }

    public class FunctionCodeHelper:EnumDataHelper<FunctionCode>
    {
        protected override void InitValue()
        {
            valueMap.Add("01 ReadCoils(0x)", FunctionCode.ReadCoilSingle);
            valueMap.Add("02 Read Discrete Inputs(1x)", FunctionCode.ReadInputStatus);
            valueMap.Add("03 Read Holding REgisters(4x)", FunctionCode.ReadRegistersMul);
            valueMap.Add("04 Read Input Registers(3x)", FunctionCode.ReadInputRegisters);
            valueMap.Add("05 Write Single Coil", FunctionCode.WriteCoilSingle);
            valueMap.Add("06 Write Single Register", FunctionCode.WriteRegistersSingle);
            valueMap.Add("15 Write Multiple Coils", FunctionCode.WriteCoilMul);
            valueMap.Add("16 Write Multiple Registers", FunctionCode.WriteRegistersMul);
        }
    }
}
