using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ·ûºÅÅÐ¶ÏËã·¨¿é£¨SIGN)
    /// </summary>
    [Serializable]
    public class SignBlock : PIDGeneralBlock
    {
        public SignBlock()
            : base(new PIDSign() )
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSign();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_sign_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 80f);
        }
    }
}