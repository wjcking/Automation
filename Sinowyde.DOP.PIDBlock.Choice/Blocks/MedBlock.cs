using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// ��ֵѡ���㷨�飨MED��Median 
    /// </summary>
    [Serializable]
    public class MedBlock : PIDGeneralBlock
    {
        public MedBlock()
            : base(new PIDMed())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMed();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_med_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}