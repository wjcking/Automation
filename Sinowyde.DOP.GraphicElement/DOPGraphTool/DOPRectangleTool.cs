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
    [ExportGraphMetaDataAttribute("矩形", 4, "基本图形", "Rectangle")]
    public class DOPRectangleTool : GraphElementTool
    {
        //[ImportingConstructor]
        //public DOPRectangleTool([Import(typeof(GoView))] GoView goView)
        //    : base(goView)
        //{

        //}

        public override DOPGraphElement CreateElement()
        {
            return new DOPRectangle();
        }

    }
}
