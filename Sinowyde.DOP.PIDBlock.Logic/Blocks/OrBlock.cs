using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
     ///<summary>
/// “ÏªÚÀ„∑®øÈ£®XOR£©
/// </summary>
    [Serializable]
    public class  OrBlock : PIDGeneralBlock
    {
        public OrBlock(  )
            : base(new PIDOr())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamOr();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "logic_or_normal", Northwoods.Go.GoFigure.Rectangle, 84f, 84f);
        }
    }
}