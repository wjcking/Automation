using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// Âß¼­Á¿Êä³ö
    /// </summary>
    [Serializable]
    public class DMBlock : IOBlock
    {
        public DMBlock()
            : base(new PIDDM())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDM();
        }

        public override void DrawBackground()
        {
            this.GetRightPort(0).Visible = false;
            DrawBlockUtil.Draw(this, "IO_DMOP_Normal", Northwoods.Go.GoFigure.Buffer, 60f, 60f, true);
        }
    }
}