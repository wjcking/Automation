using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// ģ��������ѡ���㷨�飨INSEL��Input
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