using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class RatioAlmBlock : PIDGeneralBlock
    {
        public RatioAlmBlock()
            : base(new PIDRatioAlm())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRatioAlm();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_ratioalm_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}