using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.GraphicElement.Base
{
    public enum ColorActionType
    {
        UnKnown=0,
        BrushColor,        
        PenColor,
        BackgroundColor
    }

    public class GraphColorActionDefine : GraphActionDefine
    {
        public ColorActionType ColorActionType
        {
            get
            {
                if (this.UserObject == null)
                    return ColorActionType.UnKnown;
                else
                {
                    return (ColorActionType)this.UserObject;
                }
            }
            set
            {
                this.UserObject = value;
            }
        }
    }
}
