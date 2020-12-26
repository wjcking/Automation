using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("条形图", 10, "扩展图形", "BarMeter")]
    public class DOPBarMeterTool : IGraphFactory
    {
        public DOPGraphElement CreateElement()
        {
            return new DOPBarMeter();
        }
    }
}
