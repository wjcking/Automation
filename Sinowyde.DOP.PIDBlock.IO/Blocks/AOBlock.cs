using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 模拟量输出算法
    /// </summary>
    [Serializable]
    public class AOBlock : IOBlock
    {
        public AOBlock()
            : base(new PIDAO())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAO();
        }

        public override void DrawBackground()
        {
            this.GetRightPort(0).Visible = false;
            DrawBlockUtil.Draw(this, "IO_ANOP_Normal", Northwoods.Go.GoFigure.Buffer, 60f, 60f, true);
        }
    }
}