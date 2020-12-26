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
    [ExportGraphMetaDataAttribute("椭圆", 4, "基本图形", "Ellipse")]
    public class DOPEllipseFactory : IGraphFactory
    {
        public DOPGraphElement CreateElement()
        {
            return new DOPEllipse();
        }
    }
}
