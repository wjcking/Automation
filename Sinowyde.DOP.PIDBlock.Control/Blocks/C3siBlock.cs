using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.14  三变送器整合算法块（3SI）TRANS386431
/// </summary>

    public class C3siBlock : PIDGeneralBlock
    {
        public C3siBlock()
            : base(new PID3si(), new CtrlParam3si())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_3si_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}