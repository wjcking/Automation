using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.PIDAlgorithm.Special;

namespace Sinowyde.DOP.PIDBlock.Special
{
    [Serializable]
    public class MonthOnlineBlock : PIDGeneralBlock
    {
        public MonthOnlineBlock()
            : base(new PIDMonthOnline())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMonthOnline();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "special_monthonline_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}
