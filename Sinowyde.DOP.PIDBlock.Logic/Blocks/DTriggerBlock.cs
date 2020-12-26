using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// D´¥·¢Æ÷Ëã·¨¿é£¨DSTRIG£©R 
    /// </summary>
    [Serializable]
    public class DTriggerBlock : PIDGeneralBlock
    {
        public DTriggerBlock()
            : base(new PIDDTrigger())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDTrigger();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_dtrig_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 84f);
        }
    }
}