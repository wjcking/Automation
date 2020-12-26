using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 反三角函数算法块
    /// </summary>
    [Serializable]
    public class AsinBlock : PIDGeneralBlock
    {
        public AsinBlock()
            : base(new PIDASin())
        {
            this.IconName = "math_asin_normal";
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAsin();
        }

        public override void DrawBackground()
        {
            if ((ATrigonometricFunc)this.Algorithm.GetParam(PIDASin.ParamATrigonometricFunc).Value == ATrigonometricFunc.ASin)
            {
                DrawBlockUtil.Draw(this, "math_asin_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
            }
            else if ((ATrigonometricFunc)this.Algorithm.GetParam(PIDASin.ParamATrigonometricFunc).Value == ATrigonometricFunc.ACos)
            {
                DrawBlockUtil.Draw(this, "math_acos_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
            }
            else if ((ATrigonometricFunc) this.Algorithm.GetParam(PIDASin.ParamATrigonometricFunc).Value ==
                     ATrigonometricFunc.ATan)
            {
                DrawBlockUtil.Draw(this, "math_atan_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
            }
        }

        public override void ShowParamDialog()
        {
            base.ShowParamDialog();
            this.InvalidateViews();
        }
    }
}
