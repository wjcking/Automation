using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// ����������ѡ���㷨�飨DISEL��Digital Input 
    /// </summary>
    [Serializable]
    public class DiselBlock : PIDGeneralBlock
    {

        public DiselBlock()
            : base(new PIDDisel())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDisel();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_disel_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}