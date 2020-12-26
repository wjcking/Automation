using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ¶ÔÊýËã·¨¿é
    /// </summary>
    [Serializable]
    public class LogBlock : PIDGeneralBlock
    {
        public LogBlock()
            : base(new PIDLog())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamLog();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_log_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
