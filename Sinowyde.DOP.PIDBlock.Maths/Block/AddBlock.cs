using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ¼Ó·¨Ëã·¨¿é
    /// </summary>
    [Serializable]
    public class AddBlock : PIDGeneralBlock
    {
        public AddBlock()
            : base(new PIDAdd())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAdd();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_add_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }

}