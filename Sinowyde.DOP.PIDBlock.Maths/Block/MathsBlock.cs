using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{

    /// <summary>
    /// 数学多项式算法块
    /// </summary>
    [Serializable]
    public class MathsBlock : PIDGeneralBlock
    {
        public MathsBlock()
            : base(new PIDMaths())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMaths();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_maths_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
