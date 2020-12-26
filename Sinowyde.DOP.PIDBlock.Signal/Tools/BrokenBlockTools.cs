using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 折线信号算法块（Broken）Broken Line Signa
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("折线信号算法块", "信号源", 6, null, "signal_broken_icon")]
    public class BrokenBlockTool : BaseTool<BrokenBlock>
    {
    }
}
