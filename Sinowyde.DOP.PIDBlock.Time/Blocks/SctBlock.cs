using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;
using System;

namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 6.5系统当前时间功能块 （SCT）39fe8
/// </summary>
    [Serializable]
    public class SctBlock : PIDGeneralBlock
    {
        public SctBlock()
            : base(new PIDSct() )
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSct();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "time_sct_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 124f);
        }
    }
}