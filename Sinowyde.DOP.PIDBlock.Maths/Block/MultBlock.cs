using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �˷��㷨��
    /// </summary>
    [Serializable]
    public class MultBlock : PIDGeneralBlock
    {
        public MultBlock()
            : base(new PIDMult())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMult();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_mult_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
