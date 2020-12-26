using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public class GearBLBlock : PIDGeneralBlock
    {
        public GearBLBlock()
            : base(new PIDGearBL(),new CtrlParamGearbl())
        {
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_gearbl_normal", Northwoods.Go.GoFigure.Rectangle, 100f, 60f);
        }
    }
}
