using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// ÀëÉ¢´«µÝº¯ÊýËã·¨¿é£¨DTF£©Discrete Trans Functionf3c1e
/// </summary>

    public class DtfBlock : PIDGeneralBlock
    {
        public DtfBlock()
            : base(new PIDDtf(), new CtrlParamDtf())
        {

        }
        
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_dtf_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}