using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;
using System;

namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.7ÑÓÊ±¿ªËã·¨¿é£¨DelayOn£©
    /// </summary>
    [Serializable]
    public class DelayonBlock : PIDGeneralBlock
    {
        public DelayonBlock()
            : base(new PIDDelayon())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDelayon();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "time_delayon_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 66f);
        }
    }
}