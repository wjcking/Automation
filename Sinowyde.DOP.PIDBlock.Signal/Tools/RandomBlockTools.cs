using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 随机信号算法块（Random）Random Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("随机信号算法块", "信号源", 8, null, "signal_random_icon")]
    public class RandomBlockTool : BaseTool<RandomBlock>
    {

    }
}
