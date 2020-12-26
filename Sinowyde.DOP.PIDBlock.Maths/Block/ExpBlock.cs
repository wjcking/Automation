using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 指数函数算法块
    /// </summary>
    [Serializable]
    public class ExpBlock : PIDGeneralBlock
    {
        public ExpBlock()
            : base(new PIDExp())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamExp();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_exp_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
