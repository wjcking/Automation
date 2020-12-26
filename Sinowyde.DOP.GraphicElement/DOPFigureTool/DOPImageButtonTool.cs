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
    [ExportGraphMetaDataAttribute("图形按钮", 15, "扩展图形", "Button")]
    public class DOPImageButtonTool : IGraphFactory
    {

        #region IGraphFactory 成员

        public DOPGraphElement CreateElement()
        {
            return new DOPImageButton();
        }

        #endregion
    }
}
