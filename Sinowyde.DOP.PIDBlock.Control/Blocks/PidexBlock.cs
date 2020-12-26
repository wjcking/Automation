using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 5.2 PIDÓÅ»¯Ëã·¨¿é£¨PIDEX£© 
    /// </summary> 
    [Serializable]
    public class PidexBlock : PIDGeneralBlock
    {
        public PidexBlock()
            : base(new PIDPidex())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamPidex();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "control_pidex_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 245f);
        }
    }
}