using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 常系数算法块（CONST）Constantbc181
    /// </summary>
    [Serializable]
    public class ConstBlock : PIDGeneralBlock
    {
        public ConstBlock()
            : base(new PIDConst())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamConst();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "linearity_const_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 64f);
        }
    }
}