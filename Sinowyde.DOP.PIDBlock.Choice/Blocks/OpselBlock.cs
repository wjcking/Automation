using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// ģ�������ѡ���㷨�飨OPSEL��Output
    /// </summary>
    [Serializable]
    public class OpselBlock : PIDGeneralBlock
    {
        public OpselBlock()
            : base(new PIDOpsel())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamOpsel();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_opsel_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}