using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.DOP.PIDBlock;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// Æ«²î±¨¾¯Ëã·¨¿é£¨ALM£©
    /// </summary>
    [Serializable]
    public class AlarmBlock : PIDGeneralBlock
    {
        public AlarmBlock()
            : base(new PIDAlarm())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAlarm();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_alm_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 74f);
        }
    }
}