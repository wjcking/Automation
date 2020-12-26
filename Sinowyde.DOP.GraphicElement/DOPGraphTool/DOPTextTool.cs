using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("文本", 6, "基本图形", "Text")]
    public class DOPTextTool : IGraphFactory
    {

        public DOPGraphElement CreateElement()
        {
            return new DOPText();
        }
    }
}
