using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Linearity;
using System;

namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// 7.8数字信号加法器算法块（DS）DGSUM9d8d1
/// </summary>
    [Serializable]
    public class DsBlock : PIDGeneralBlock
    {
        public DsBlock()
            : base(new PIDDs() )
        {

        }
        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDs();
        }
        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "linearity_ds_normal", Northwoods.Go.GoFigure.Rectangle, 85f, 85f);
        }
    }
}