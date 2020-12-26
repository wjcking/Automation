using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;
using System;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 数字给定值发生器算法块（DSETPOINT）DSET0ce89
    /// </summary>
    [Serializable]
    public class DsetpointBlock : PIDGeneralBlock
    {
        public DsetpointBlock()
            : base(new PIDDsetpoint())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDsetpoint();
        }

        public override void DrawBackground()
        {
            this.GetLeftPort(1).Visible = false;
            this.GetLeftPort(1).Label.Text = string.Empty;

            DrawBlockUtil.Draw(this, "control_dsetpoint_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 64f);
        }
    }
}