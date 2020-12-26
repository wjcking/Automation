using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement.DOPFigureTool
{
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("时间", 13, "扩展图形", "Timer")]
    public class DOPTimerTool : IGraphFactory
    {
        public DOPGraphElement CreateElement()
        {
            return new DOPTimer();
        }
    }
}
