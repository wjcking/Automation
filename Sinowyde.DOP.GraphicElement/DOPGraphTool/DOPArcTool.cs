﻿using System;
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
    [ExportGraphMetaDataAttribute("弧形", 2, "基本图形", "Arc")]
    public class DOPArcTool : GraphElementTool
    {
        //[ImportingConstructor]
        //public DOPArcTool([Import(typeof(GoView))] GoView goView)
        //{

        //}

        public override DOPGraphElement CreateElement()
        {
            return new DOPArc();
        }
    }
}
