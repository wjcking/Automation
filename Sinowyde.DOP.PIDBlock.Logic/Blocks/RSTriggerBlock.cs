using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// RS´¥·¢Æ÷Ëã·¨¿é£¨RSTRIG£©RS Triggerc44e7
    /// </summary>
    [Serializable]
    public class RSTriggerBlock : PIDGeneralBlock
    {
        public RSTriggerBlock()
            : base(new PIDRSTrigger())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRSTrigger();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_rstrig_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 74f);
        }
    }
}