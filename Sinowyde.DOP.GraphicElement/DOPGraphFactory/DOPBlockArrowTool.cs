using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.DOP.GraphicElement;

namespace Sinowyde.DOP.GraphicElement.DOPGraphFactory
{
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("箭头", 8, "基本图形", "BlockArrow")]
    public class DOPBlockArrowTool : IGraphFactory
    {

        #region IGraphFactory 成员

        public DOPGraphElement CreateElement()
        {
            return new DOPBlockArrow();
        }

        #endregion
    }
}
