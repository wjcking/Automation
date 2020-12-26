using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ½×Ô¾ÐÅºÅËã·¨¿é£¨Step£©Step Signale1f0f
    /// </summary>
    [Serializable]
    public class StepBlock : PIDGeneralBlock
    {
        public StepBlock()
            : base(new PIDStep())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamStep();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_step_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}