using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Nonlinearity;
using System.ComponentModel.Composition;
using System.Reflection;
using System;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    [Serializable]
    public class DeadBlock : PIDGeneralBlock
    {
        public DeadBlock()
            : base(new PIDDead())
        {
            
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamDead();
        }

        public override void DrawBackground()
        {
            DrawBlockUtil.Draw(this, "nonlinearity_dead_normal", Northwoods.Go.GoFigure.Rectangle, 80f, 60f);
        }
    }
}
