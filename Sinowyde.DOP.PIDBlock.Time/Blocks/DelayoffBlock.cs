using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;
using System;

namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.8—” ±πÿÀ„∑®øÈ£®DelayOff£©31958
    /// </summary>
    [Serializable]
    public class DelayoffBlock : PIDGeneralBlock
    {
        public DelayoffBlock()
            : base(new PIDDelayoff())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDelayoff();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "time_delayoff_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 64f);
        }
    }
}