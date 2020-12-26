using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// PID¿ØÖÆËã·¨¿é£¨PID£©PID2c5b1
/// </summary>

    public class PidBlock : PIDGeneralBlock
    {
        public PidBlock()
            : base(new PIDPid(), new CtrlParamPid())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_pid_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}