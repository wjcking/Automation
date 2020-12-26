using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ∑Ω≤®–≈∫≈À„∑®øÈ£®Square£©Square wave Signal
    /// </summary>
    [Serializable]
    public class SquareBlock : PIDGeneralBlock
    {
        public SquareBlock()
            : base(new PIDSquare())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSquare();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_square_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}