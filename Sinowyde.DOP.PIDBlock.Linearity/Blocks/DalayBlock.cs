using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// ´¿ÑÓ³ÙËã·¨¿é£¨DALAY£©Dalay2ad38
    /// </summary>
    [Serializable]
    public class DalayBlock : PIDGeneralBlock
    {
        public DalayBlock()
            : base(new PIDDalay())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDalay();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "linearity_dalay_icon", Northwoods.Go.GoFigure.Rectangle, 85f, 65f);
        }
    }
}