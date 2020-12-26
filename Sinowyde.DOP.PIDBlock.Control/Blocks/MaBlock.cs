using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.4模拟手动站算法块（MA）Analogue Man Station3b8d4
/// </summary>

    public class MaBlock : PIDGeneralBlock
    {
        public MaBlock()
            : base(new PIDMa(), new CtrlParamMa())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_ma_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}