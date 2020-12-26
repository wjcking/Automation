using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ·ÇËã·¨¿é£¨NOT£©
    /// </summary>
    [Serializable]
    public class NotBlock : PIDGeneralBlock
    {
        public NotBlock()
            : base(new PIDNot())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamNot();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_not_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 80f);
        }
    }
}