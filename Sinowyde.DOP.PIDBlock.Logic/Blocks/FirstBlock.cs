using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 首出算法块（First） 
    /// </summary>
    [Serializable]
    public class FirstBlock : PIDGeneralBlock
    {
        public FirstBlock()
            : base(new PIDFirst())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamFirst();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_first_normal", Northwoods.Go.GoFigure.Rectangle, 104f, 184f);
        }
    }
}