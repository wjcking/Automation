using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;
using System;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ³ý·¨Ëã·¨¿é
    /// </summary>
    [Serializable]
    public class DivBlock : PIDGeneralBlock
    {
        public DivBlock()
            : base(new PIDDiv())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDiv();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_div_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}