using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// “ÏªÚÀ„∑®øÈ£®XOR£©
    /// </summary>
    [Serializable]
    public class XorBlock : PIDGeneralBlock
    {
        public XorBlock()
            : base(new PIDXor())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamXor();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_xor_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 74f);
        }
    }
}