using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.13  两变送器整合算法块（2SI）TRANS28f134
/// </summary>

    public class C2siBlock : PIDGeneralBlock
    {
        public C2siBlock()
            : base(new PID2si(), new CtrlParam2si())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_2si_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}