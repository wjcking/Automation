using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.GoObjectEx
{
    [Serializable]
    public class GoToolLinkingNewEx : GoToolLinkingNew
    {
        public GoToolLinkingNewEx(GoView goView)
            : base(goView)
        {

        }

        public override void StartNewLink(IGoPort port, System.Drawing.PointF dc)
        {
            if (null != port)
            {
                var algorithmVar = port.UserObject as PIDAlgorithmVar;
                if (null != algorithmVar)
                {
                    if (algorithmVar.VarType == PIDVarDataType.AM)
                    {
                        this.View.NewLinkPrototype = new BlockLink { LinkStyle = 1 };//AM=1
                    }
                    else if (algorithmVar.VarType == PIDVarDataType.DM)
                    {
                        this.View.NewLinkPrototype = new BlockLink { LinkStyle = 0 };//DM=0
                    }
                }
            }
            base.StartNewLink(port, dc);
        }
    }
}
