using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 数值量输出
    /// </summary>
    [Serializable]
    public class AMBlock : IOBlock
    {
        public AMBlock()
            : base(new PIDAM())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAM();
        }

        public override void DrawBackground()
        {
            this.GetRightPort(0).Visible = false;
            DrawBlockUtil.Draw(this, "IO_AMOP_Normal", Northwoods.Go.GoFigure.Buffer, 60f, 60f, true);
        }
    }
}