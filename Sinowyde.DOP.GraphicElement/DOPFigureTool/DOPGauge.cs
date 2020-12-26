using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{


    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("仪表盘", 14, "扩展图形", "Gauge")]
    public class DOPGaugeTool : IGraphFactory
    {

        public DOPGraphElement CreateElement()
        {
            return new DOPGauge();
        }

    }
}