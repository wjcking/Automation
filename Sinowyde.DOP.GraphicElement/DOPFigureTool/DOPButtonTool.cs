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
    [ExportGraphMetaDataAttribute("标准按钮", 9, "扩展图形", "Button")]
    public class DOPButtonTool : IGraphFactory
    {

        public DOPGraphElement CreateElement()
        {
            return new DOPButton();
        }

    }
}

