using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;
using System;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 5.5M/AÕ¾ÓÅ»¯Ëã·¨¿é£¨MAEX£©
    /// </summary>
    [Serializable]
    public class MaexBlock : PIDGeneralBlock
    {
        public MaexBlock()
            : base(new PIDMaex())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMaex();
        }

        public override void DrawBackground()
        {
            //this.GetLeftPort(10).Visible = false;
            //this.GetLeftPort(10).Label.Text = string.Empty;

            //this.GetLeftPort(11).Visible = false;
            //this.GetLeftPort(11).Label.Text = string.Empty;

            DrawBlockUtil.Draw(this, "control_maex_normal", Northwoods.Go.GoFigure.Rectangle, 106f, 205f);
        }
    }
}