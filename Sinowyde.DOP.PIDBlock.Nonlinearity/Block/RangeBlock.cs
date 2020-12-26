using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System.ComponentModel.Composition;
using System;


namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class RangeBlock : PIDGeneralBlock
    {
        public RangeBlock()
            : base(new PIDRange())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRange();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_range_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}