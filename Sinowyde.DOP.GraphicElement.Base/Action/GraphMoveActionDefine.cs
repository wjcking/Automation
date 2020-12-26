using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.GraphicElement.Base
{
    /// <summary>
    /// 移动方向
    /// </summary>
    public enum MoveDirection
    {
        UnKnown=0,
        Top,
        Bottom,
        Left,
        Right
    }     

    public class GraphMoveActionDefine : GraphActionDefine
    {
        public MoveDirection Direction
        {
            get
            {
                if (this.UserObject == null)
                    return MoveDirection.UnKnown;
                else
                {
                    return (MoveDirection)this.UserObject;
                }
            }
            set
            {
                this.UserObject = value;
            }
        }
    }
}
