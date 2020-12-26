using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.GraphicElement.Base
{
    public enum TextActionType
    {
        UnKnown=0,
        Content,
        Color
    }

    public class GraphTextActionDefine : GraphActionDefine
    {
        public TextActionType Direction
        {
            get
            {
                if (this.UserObject == null)
                    return TextActionType.UnKnown;
                else
                {
                    return (TextActionType)this.UserObject;
                }
            }
            set
            {
                this.UserObject = value;
            }
        }        
    }
}
