using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Sim
{
    public class VariableExtend : Variable
    {

        public SimulateInfo SimulateInfo
        { get; set; }

        public RTValue RT
        {
            get
            {
                return new RTValue()
                {
                    ID = ID,
                    VarNumber = Number,
                    Value = SimulateInfo.Value,
                    Quality = RtValueQuality.good,
                    Timestamp = DateTime.Now
                };
            }
        }

        public string DeviceName { get; set; }
        public string IOUnitName { get; set; }

        internal static List<VariableExtend> GetList()
        {
            var vList = Sinowyde.DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<Variable>();//.GetByIOUnitID(5);

            var vexList = new List<VariableExtend>();

            foreach (var v in vList)
            {
                var vex = new VariableExtend();
                vex.ID = v.ID;
                vex.DeviceID = v.DeviceID;
                vex.Device = v.Device;
                vex.DeviceName = null == v.Device ? string.Empty : v.Device.Name;
                vex.IOUnitName = null == v.IOUnit ? string.Empty : v.IOUnit.Name;
                vex.IOUnitID = v.IOUnitID;
                vex.IOUnit = v.IOUnit;
                vex.Number = v.Number;
                vex.Name = v.Name;
                vex.Unit = v.Unit;
                vex.Ratio = v.Ratio;
                vex.Bias = v.Bias;
                vex.IsCompressed = v.IsCompressed;
                vex.CompressRatio = v.CompressRatio;
                vex.IsTransfer = v.IsTransfer;
                vex.MaxPeriod = v.MaxPeriod;
                vex.DirectionType = v.DirectionType;
                // vex.DataType = v.DataType;
                vex.Address = v.Address;
                vex.VariableType = v.VariableType;
                vex.SimulateInfo = new SimulateInfo()
                     {
                         Interval = 5,
                         Step = 1,
                         Type = 0,
                         RangeMax = 32767,
                         RangeMin = 0,
                         Value = 0,
                         IsOperated = false
                     };

                vexList.Add(vex);
            }

            return vexList;
        }
    }
}
