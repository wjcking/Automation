using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.PIDAlgorithm.Special;

namespace Sinowyde.DOP.PIDBlock.Special
{
    [Serializable]
    public class TimeOnlineBlock : PIDGeneralBlock
    {
        public TimeOnlineBlock()
            : base(new PIDTimeOnline())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamTimeOnline();
        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "special_timeonline_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}
