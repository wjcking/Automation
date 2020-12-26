using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    ///<summary>
    /// ���������ѡ���㷨�飨DOSEL��Digital Output
    /// </summary>
    [Serializable]
    public class DoselBlock : PIDGeneralBlock
    {
        public DoselBlock()
            : base(new PIDDosel())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDosel();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "choice_dosel_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}