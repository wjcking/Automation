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
    [ExportGraphMetaDataAttribute("热点区域", 11, "扩展图形", "Hotspot")]
    public class DOPHotspotTool : IGraphFactory
    {

        public DOPGraphElement CreateElement()
        {
            return new DOPHotspot();
        }
    }
}

