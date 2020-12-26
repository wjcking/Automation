using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 斜坡信号算法块（Ramp）Ramp Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("斜坡信号算法块", "信号源", 2, null, "signal_ramp_icon")]
    public class RampBlockTool : BaseTool<RampBlock>
    {

    }
}
