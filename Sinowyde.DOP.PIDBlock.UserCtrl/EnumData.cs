using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    public enum DropEnum
    {
        None = 0,
        DVarDirection = 1,
        DVarDataType = 2,
        DDevice = 3,
    }
    public class EnumData
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public static EnumData[] GetEnumDataHelper(DropEnum d)
        {
            if (d == DropEnum.DVarDirection)
            {
                return new EnumData[] { 
                    new EnumData () { Key = "采集类型" , Value = VarDirectionType.Unknown},
                    new EnumData () { Key = "读取" , Value =VarDirectionType.Read},
                    new EnumData () { Key = "写入" , Value =VarDirectionType.Write},
                    new EnumData () { Key = "中间临时" , Value =VarDirectionType.Temp}
                };

            }
            else if (d == DropEnum.DVarDataType)
            {
                return new EnumData[] { 
                    new EnumData () { Key ="数据类型", Value =VarDataType.Unknown},
                    new EnumData () { Key ="模拟量", Value =VarDataType.AM},
                    new EnumData () { Key ="数字量" , Value =VarDataType.DM},
                    new EnumData () { Key ="字符串" , Value =VarDataType.StringM}
                };

            }
            else if (d == DropEnum.DDevice)
            {
                return new EnumData[] { 
                    new EnumData () { Key ="设备选择", Value =-1}, 
                };

            }
            return null;
        }
        public override string ToString()
        {
            return String.Format("{0}", Key);
        }
    }

    public class EnumDataHelper<T>
    {
        protected string Key { get; set; }
        protected T Value { get; set; }


        public static object[] GetEnumDataHelper()
        {
            var t = default(T).GetType();

            if (t == typeof(VarDirectionType))
            {
                return new object[] { 
                    new EnumDataHelper<VarDirectionType>() { Key = "读取" , Value =VarDirectionType.Read},
                    new EnumDataHelper<VarDirectionType>() { Key = "写入" , Value =VarDirectionType.Write},
                    new EnumDataHelper<VarDirectionType>() { Key = "中间临时" , Value =VarDirectionType.Temp}
                };

            }
            else if (t == typeof(VarDataType))
            {
                return new object[] { 
                    new EnumDataHelper<VarDataType>() { Key ="模拟量", Value =VarDataType.AM},
                    new EnumDataHelper<VarDataType>() { Key ="数字量" , Value =VarDataType.DM},
                    new EnumDataHelper<VarDataType>() { Key ="字符串" , Value =VarDataType.StringM}
                };

            }
            return null;
        }
        public override string ToString()
        {
            return String.Format("{0}", Key);
        }
    }
}
