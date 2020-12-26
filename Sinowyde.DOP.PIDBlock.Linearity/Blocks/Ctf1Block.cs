using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// 连续传递函数 1 算法块（CTF1）ContinuousTransFunction17bdec
/// </summary>

    public class Ctf1Block : PIDGeneralBlock
    {
        public Ctf1Block()
            : base(new PIDCtf1(), new CtrlParamCtf1())
        {

        }
        
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_ctf1_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}