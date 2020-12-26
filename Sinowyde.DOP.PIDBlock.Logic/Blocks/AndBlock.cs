using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ”ÎÀ„∑®øÈ£®AND)
    /// </summary> 
    [Serializable]
    public class AndBlock : PIDGeneralBlock
    {
        public AndBlock()
            : base(new PIDAnd())
        {

        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAnd();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_and_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 84f);
        }
    }
}