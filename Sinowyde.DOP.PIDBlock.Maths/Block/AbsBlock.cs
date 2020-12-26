using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ¾ø¶ÔÖµËã·¨¿é
    /// </summary>
    [Serializable]
    public class AbsBlock : PIDGeneralBlock
    {
        public AbsBlock()
            : base(new PIDAbs())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAbs();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_abs_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }

}