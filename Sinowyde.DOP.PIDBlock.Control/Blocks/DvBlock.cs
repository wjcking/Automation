using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.15  设备驱动算法块（DV）DEVICE 　a3226
/// </summary>

    public class DvBlock : PIDGeneralBlock
    {
        public DvBlock()
            : base(new PIDDv(), new CtrlParamDv())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_dv_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}