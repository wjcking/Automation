using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;
using System;

namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 6.5系统当前时间功能块 （SCT）39fe8
/// </summary>
    [Serializable]
    public class Sct2Block : PIDGeneralBlock
    {
        public Sct2Block()
            : base(new PIDSct2() )
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSct2();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "time_sct2_normal", Northwoods.Go.GoFigure.Rectangle, 87f, 66f);
        }
    }
}