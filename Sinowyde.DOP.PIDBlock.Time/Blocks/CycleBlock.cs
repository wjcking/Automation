using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Time;

namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// ���ڶ�ʱ���㷨�飨Cycle�� Timeraa2a5
/// </summary>

    public class CycleBlock : PIDGeneralBlock
    {
        public CycleBlock()
            : base(new PIDCycle(), new CtrlParamCycle())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_cycle_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}