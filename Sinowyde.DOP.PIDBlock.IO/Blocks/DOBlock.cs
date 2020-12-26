using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 数字量输出算法
    /// </summary>
    [Serializable]
    public class DOBlock : IOBlock
    {
        public DOBlock()
            : base(new PIDDO())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDO();
        }

        public override void DrawBackground()
        {
            this.GetRightPort(0).Visible = false;
            DrawBlockUtil.Draw(this, "IO_DGOP_Normal", Northwoods.Go.GoFigure.Buffer, 60f, 60f, true);
        }
    }
}