using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// ¿ª¹ØËã·¨¿é
    /// </summary>
    [Serializable]
    public class SwitchBlock : PIDGeneralBlock
    {
        public SwitchBlock()
            : base(new PIDSwitch())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSwitch();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_switch_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}
