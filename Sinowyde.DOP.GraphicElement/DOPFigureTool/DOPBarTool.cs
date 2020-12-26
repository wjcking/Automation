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


    //[Export(typeof(IGraphFactory))]
    //[ExportGraphMetaDataAttribute("条形进度", 12, "扩展图形", "Bar")]
    public class DOPBarTool : IGraphFactory
    {

        public DOPGraphElement CreateElement()
        {
            return new DOPBar();
        }

    }
}