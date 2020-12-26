using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// ΢���㷨�飨DIFF��Differential0227c
    /// </summary>
    [Serializable]
    public class DiffBlock : PIDGeneralBlock
    {
        public DiffBlock()
            : base(new PIDDiff())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDiff();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "linearity_diff_normal", Northwoods.Go.GoFigure.Rectangle, 85f, 65f);
        }
    }
}