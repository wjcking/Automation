using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public class HyloopBlock : PIDGeneralBlock
    {

        public HyloopBlock()
            : base(new PIDHYLoop(),new CtrlParamHyloop())
        {
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_hyloop_normal", Northwoods.Go.GoFigure.Rectangle, 100f, 60f);
        }
    }
}
