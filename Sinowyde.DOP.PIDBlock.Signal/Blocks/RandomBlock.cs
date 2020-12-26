using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
     ///<summary>
/// Ëæ»úÐÅºÅËã·¨¿é£¨Random£©Random Signal652e2
/// </summary>
    [Serializable]
    public class RandomBlock : PIDGeneralBlock
    {
        public RandomBlock()
            : base(new PIDRandom ())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamRandom();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_random_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}