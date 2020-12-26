using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;
using System;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// ≥¨«∞÷Õ∫ÛÀ„∑®øÈ£®LEADLEG£©LEADLEGaabce
    /// </summary> 
    [Serializable]
    public class LeadlegBlock : PIDGeneralBlock
    {
        public LeadlegBlock()
            : base(new PIDLeadleg() )
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamLeadleg();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "control_leadleg_normal", Northwoods.Go.GoFigure.Rectangle, 105f, 66f);
        }
    }
}