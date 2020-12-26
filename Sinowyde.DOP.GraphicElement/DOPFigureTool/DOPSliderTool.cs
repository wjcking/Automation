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
    [Export(typeof(IToolGraph))]
    [ExportGraphMetaDataAttribute("标尺进度", 12, "扩展图形", "Bar")]
    public class DOPSliderTool : DOPGeneralTool
    {
        [ImportingConstructor]
        public DOPSliderTool([Import(typeof(GoView))] GoView goView)
            : base(goView)
        {

        }

        public override DOPGeneralShape CreateShape()
        {
            return new DOPSlider();
        }
    }
}