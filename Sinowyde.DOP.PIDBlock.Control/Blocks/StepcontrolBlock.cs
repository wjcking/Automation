using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// ²½Ðò¿ØÖÆËã·¨¿é£¨STEPCONTROL£©STEPCTL4ba56
/// </summary>

    public class StepcontrolBlock : PIDGeneralBlock
    {
        public StepcontrolBlock()
            : base(new PIDStepcontrol(), new CtrlParamStepcontrol())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_stepcontrol_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}