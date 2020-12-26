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
    [ExportGraphMetaDataAttribute("弹出对话框", 12, "扩展图形", "Dialog")]
    public class DOPDialogTool : IGraphFactory
    {

        public DOPGraphElement CreateElement()
        {
            return new DOPDialog();
        } 
    }
}