using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制图像
    /// </summary>
    [Serializable]
    public class DOPImageLibrary : DOPGraphElement 
    {
        public DOPImageLibrary()
            : base()
        {
          //  this.Add(new go
            this.Add(new GoImage());
        }


        //public override void Refresh()
        //{
           
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
             return new UCtlImageLibraryParam(this) { Name = "图库属性" };
        }
    }
}
