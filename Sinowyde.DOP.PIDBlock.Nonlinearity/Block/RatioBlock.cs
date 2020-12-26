using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class RatioBlock : PIDGeneralBlock
    {
        public RatioBlock()
            : base(new PIDRatio())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRatio();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_ratio_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}