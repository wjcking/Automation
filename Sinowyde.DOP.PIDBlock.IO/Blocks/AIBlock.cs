using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Northwoods.Go;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    /// <summary>
    /// 模拟量输入算法
    /// </summary>
    [Serializable]
    public class AIBlock : IOBlock
    {
        public AIBlock()
            : base(new PIDAI())
        {
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new CtrlParamAI();
        }

        public override void DrawBackground()
        {
            this.GetLeftPort(0).Visible = false;
            DrawBlockUtil.Draw(this, "IO_ANIN_Normal", Northwoods.Go.GoFigure.Buffer, 60f, 60f,true);
        }
    }
}