using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// »ý·ÖËã·¨¿é£¨INTEG£©Integral8267b
/// </summary>
    [Serializable]
    public class IntegBlock : PIDGeneralBlock
    {
        public IntegBlock()
            : base(new PIDInteg() )
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamInteg();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "linearity_integ_normal", Northwoods.Go.GoFigure.Rectangle, 85f, 65f);
        }
    }
}