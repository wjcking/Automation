using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;
using System;

namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// »ýËãÆ÷Ëã·¨¿é£¨TOTAL£©
    /// </summary>
    [Serializable]
    public class TotalBlock : PIDGeneralBlock
    {
        public TotalBlock()
            : base(new PIDTotal())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamTotal();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "time_total_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 75f);
        }
    }
}