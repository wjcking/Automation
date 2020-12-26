using System;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Signal;

namespace Sinowyde.DOP.PIDBlock.Signal
{
     ///<summary>
/// ’˝œ“–≈∫≈À„∑®øÈ£®SinSig£©Sin Signal3fea0
/// </summary>
    [Serializable]
    public class SinsigBlock : PIDGeneralBlock
    {
        public SinsigBlock()
            : base(new PIDSinsig())
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamSinsig();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "signal_sinsig_normal", Northwoods.Go.GoFigure.Rectangle, 90f, 90f);
        }
    }
}