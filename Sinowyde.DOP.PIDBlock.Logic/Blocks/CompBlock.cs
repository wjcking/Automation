using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ±È½ÏÆ÷Ëã·¨¿é£¨COMP£©
    /// </summary>
    [Serializable]
    public class CompBlock : PIDGeneralBlock
    {
        public CompBlock()
            : base(new PIDComparer())
        {
            this.IconName = "logic_comparer_bigger_normal";
        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamComparer();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, IconName, Northwoods.Go.GoFigure.Rectangle, 84f, 74f);

        }
    }
}