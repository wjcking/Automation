using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;

namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// ��ʱ���Ż��㷨�飨TEX��Timer65cb1
/// </summary>

    public class TexBlock : PIDGeneralBlock
    {
        public TexBlock()
            : base(new PIDTex(), new CtrlParamTex())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_tex_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}