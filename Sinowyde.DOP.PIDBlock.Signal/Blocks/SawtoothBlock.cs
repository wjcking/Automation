using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// æ‚≥›≤®–≈∫≈À„∑®øÈ£®Sawtooth£©Sawtooth wave Signalcc37c
    /// </summary>
    [Serializable]
    public class SawtoothBlock : PIDGeneralBlock
    {
        public SawtoothBlock()
            : base(new PIDSawtooth())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return  new CtrlParamSawtooth();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_sawtooth_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}