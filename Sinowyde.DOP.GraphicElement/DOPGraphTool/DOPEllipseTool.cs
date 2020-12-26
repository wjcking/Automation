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
    [ExportGraphMetaDataAttribute("椭圆", 6, "基本图形", "Ellipse")]
    public class DOPEllipseTool : GraphElementTool
    {
        //[ImportingConstructor]
        //public DOPEllipseTool([Import(typeof(GoView))] GoView goView)
        //    : base(goView)
        //{

        //}

        public override DOPGraphElement CreateElement()
        {
            return new DOPEllipse();
        }
    }
}
