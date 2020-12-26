using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 5.3基于单个神经元的自适应控制算法块（Adapt）6d50f
    /// </summary>
    public class AdaptBlock : PIDGeneralBlock
    {
        public AdaptBlock()
            : base(new PIDSnc(), new CtrlParamSnc())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_adapt_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}