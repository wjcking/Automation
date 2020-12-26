using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class MagampBlock : PIDGeneralBlock
    {
        public MagampBlock()
            : base(new PIDMagAmp())
        {
        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMagamp();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_magamp_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}