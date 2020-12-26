using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 阶跃信号算法块（Step）Step Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("阶跃信号算法块", "信号源", 1, null, "signal_step_icon")]
    public class StepBlockTool : BaseTool<StepBlock>
    {

    }
}
