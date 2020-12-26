using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// 模拟量输入选择算法块（INSEL）Input
    /// </summary> 
    [Serializable]
    public class InselBlock : PIDGeneralBlock
    {
        public InselBlock( )
            : base(new PIDInsel())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamInsel();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_insel_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}