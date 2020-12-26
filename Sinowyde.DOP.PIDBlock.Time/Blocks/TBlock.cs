using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;

namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// ¶¨Ê±Æ÷Ëã·¨¿é£¨T£©Timer20ca2
/// </summary>

    public class TBlock : PIDGeneralBlock
    {
        public TBlock()
            : base(new PIDT(), new CtrlParamT())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_t_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}