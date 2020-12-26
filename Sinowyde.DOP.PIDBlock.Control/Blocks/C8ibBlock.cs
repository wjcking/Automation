using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 8  ‰»Î∆Ω∫‚À„∑®øÈ£®8IB£©8 INPUT BALANCE66f7f
/// </summary>

    public class C8ibBlock : PIDGeneralBlock
    {
        public C8ibBlock()
            : base(new PID8ib(), new CtrlParam8ib())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_8ib_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}