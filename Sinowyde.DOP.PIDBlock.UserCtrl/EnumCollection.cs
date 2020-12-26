using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    public class CDirection<T>: EnumDataHelper<T>
    {
        object[] CDirection()
        {   return new object[] {
                new CDirection() { Key = "读取" , Value =VarDirectionType.Read},
                new CDirection() { Key = "写入" , Value =VarDirectionType.Write},
                new CDirection() { Key = "中间临时" , Value =VarDirectionType.Temp} 
            };
        }
    
    }
}
