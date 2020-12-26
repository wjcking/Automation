using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// �������ݺ��� 2 �㷨�飨CTF2��ContinuousTransFunction27ecfd
/// </summary>

    public class Ctf2Block : PIDGeneralBlock
    {
        public Ctf2Block()
            : base(new PIDCtf2(), new CtrlParamCtf2())
        {

        }
        
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_ctf2_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}