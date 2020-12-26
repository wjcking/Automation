using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 2  ‰»Î∆Ω∫‚À„∑®øÈ£®2IB£©2 INPUT BALANCEfb4f2
/// </summary>

    public class C2ibBlock : PIDGeneralBlock
    {
        public C2ibBlock()
            : base(new PID2ib(), new CtrlParam2ib())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_2ib_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}