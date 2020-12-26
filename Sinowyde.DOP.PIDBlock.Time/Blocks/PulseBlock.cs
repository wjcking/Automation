using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;
using System;

namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.9Âö³åÕûÐÎËã·¨¿é£¨PULSE£© 
    /// </summary>
    [Serializable]
    public class PulseBlock : PIDGeneralBlock
    {
        public PulseBlock()
            : base(new PIDPulse())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamPulse();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "time_pulse_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 63f);
        }
    }
}