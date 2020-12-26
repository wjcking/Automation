using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// 数字信号 3 选 2 算法块（DG）Digital Signal 2 OF
    /// </summary>
    [Serializable]
    public class DgBlock : PIDGeneralBlock
    {
        public DgBlock()
            : base(new PIDDg())
        {
        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDg();
        }
         
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_dg_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}