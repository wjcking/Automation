using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class RangAlmBlock : PIDGeneralBlock
    {
        public RangAlmBlock()
            : base(new PIDRangeAlm())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRangeAlm();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_rangealm_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}