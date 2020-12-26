using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class LineBlock : PIDGeneralBlock
    {
        public LineBlock()
            : base(new PIDLine())
        {
        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamLine();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_line_normal", Northwoods.Go.GoFigure.Rectangle, 100f, 60f);
        }
    }
}