using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 多段方波信号算法块（MSquare）Multi-Square Signalf1cb5
    /// </summary>
    [Serializable]
    public class MsquareBlock : PIDGeneralBlock
    {
        public MsquareBlock()
            : base(new PIDMsquare())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamMsquare();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_msquare_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}