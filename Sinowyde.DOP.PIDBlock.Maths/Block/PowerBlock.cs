using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �ݺ����㷨��
    /// </summary>
    [Serializable]
    public class PowerBlock : PIDGeneralBlock
    {
        public PowerBlock()
            : base(new PIDPow())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamPower();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_power_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}
