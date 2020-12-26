using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ¼õ·¨Ëã·¨¿é
    /// </summary>
    [Serializable]
    public class SubBlock : PIDGeneralBlock
    {
        public SubBlock()
            : base(new PIDSub())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSub();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_sub_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
