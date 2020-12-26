using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Northwoods.Go.Instruments;
using Sinowyde.Util;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Serializable]
    public class DOPBarMeter : DOPGraphElement
    {
        public DOPBarMeter()
            :base()
        {
            DOPBarMeters barMeter = new DOPBarMeters();
            barMeter.Bounds = new RectangleF(0, 0, 50, 200);
            barMeter.Value = 10;
            this.Add(barMeter);
        }

        /// <summary>
        /// 获取条形图对象
        /// </summary>
        private Meter Shape
        {
            get
            {
                return this.First as Meter;
            }

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlBarMeterParam(this) { Name = "棒图属性" };
        }

    }
}
