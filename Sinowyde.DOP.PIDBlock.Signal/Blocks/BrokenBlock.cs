using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ’€œﬂ–≈∫≈À„∑®øÈ£®Broken£©Broken Line Signal41660
    /// </summary>
    [Serializable]
    public class BrokenBlock : PIDGeneralBlock
    {
        public BrokenBlock()
            : base(new PIDBroken())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamBroken();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_broken_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}