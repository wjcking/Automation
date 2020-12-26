using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// Ð±ÆÂÐÅºÅËã·¨¿é£¨Ramp£©Ramp Signalaeec0
    /// </summary>
    [Serializable]
    public class RampBlock : PIDGeneralBlock
    {
        public RampBlock()
            : base(new PIDRamp())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRamp();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_ramp_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}