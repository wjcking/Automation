using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 5.3���ڵ�����Ԫ������Ӧ�����㷨�飨Adapt��6d50f
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