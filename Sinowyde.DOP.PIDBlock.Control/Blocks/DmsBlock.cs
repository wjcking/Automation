using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Control;

namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// �����ֶ�վ�㷨�飨DMS��Digital Man Stationb54c9
/// </summary>

    public class DmsBlock : PIDGeneralBlock
    {
        public DmsBlock()
            : base(new PIDDms(), new CtrlParamDms())
        {

        }


        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "math_dms_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}