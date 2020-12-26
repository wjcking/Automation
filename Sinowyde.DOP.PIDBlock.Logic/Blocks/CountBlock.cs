using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ¼ÆÊýÆ÷Ëã·¨¿é£¨COUNT£©Counter27ff6
    /// </summary> 
    [Serializable]
    public class CountBlock : PIDGeneralBlock
    {
        public CountBlock()
            : base(new PIDCounter())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamCounter();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_count_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 74f);
        }
    }
}