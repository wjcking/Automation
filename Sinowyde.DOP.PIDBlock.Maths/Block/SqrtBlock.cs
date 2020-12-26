using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ¿ª·½Ëã·¨¿é
    /// </summary>
    [Serializable]
    public class SqrtBlock : PIDGeneralBlock
    {
        public SqrtBlock()
            : base(new PIDSqrt())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSqrt();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_sqrt_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
