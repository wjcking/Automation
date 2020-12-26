using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;
using System;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 模拟给定值发生器算法块
    /// </summary>
    [Serializable]
    public class AsetpointBlock : PIDGeneralBlock
    {
        public AsetpointBlock()
            : base(new PIDAsetpoint())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAsetpoint();
        }

        public override void DrawBackground()
        {
            this.GetLeftPort(0).Visible = false;
            this.GetLeftPort(0).Label.Text = string.Empty;
            
            DrawBlockUtil.Draw(this, "control_asetpoint_normal", Northwoods.Go.GoFigure.Rectangle, 104f, 64f);
        }
    }
}