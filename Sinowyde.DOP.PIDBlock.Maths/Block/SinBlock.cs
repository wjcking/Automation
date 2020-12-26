using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// Èý½Çº¯ÊýËã·¨¿é
    /// </summary>
    [Serializable]
    public class SinBlock : PIDGeneralBlock
    {
        public SinBlock()
            : base(new PIDSin())
        {
            this.IconName = "math_sin_normal";
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSin();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, IconName, Northwoods.Go.GoFigure.Rectangle, 90f, 90f);

            if ((TrigonometricFunc)this.Algorithm.GetParam(PIDSin.ParamTrigonometricFunc).Value == TrigonometricFunc.Sin)
            {
                DrawBlockUtil.Draw(this, "math_sin_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
            }
            else if ((TrigonometricFunc)this.Algorithm.GetParam(PIDSin.ParamTrigonometricFunc).Value == TrigonometricFunc.Cos)
            {
                DrawBlockUtil.Draw(this, "math_cos_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
            }
            else if ((TrigonometricFunc)this.Algorithm.GetParam(PIDSin.ParamTrigonometricFunc).Value ==
                     TrigonometricFunc.Tan)
            {
                DrawBlockUtil.Draw(this, "math_tan_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
            }
        }   
    }
}
