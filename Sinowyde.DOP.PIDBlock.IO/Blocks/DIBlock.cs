using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 数字量输入算法
    /// </summary>
    [Serializable]
    public class DIBlock : IOBlock
    {
        public DIBlock()
            : base(new PIDDI())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDI();
        }

        public override void DrawBackground()
        {
            this.GetLeftPort(0).Visible = false;
            DrawBlockUtil.Draw(this, "IO_DGIN_Normal", Northwoods.Go.GoFigure.Buffer, 60f, 60f, true);
        }
    }
}