using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// 幅值算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("幅值算法块", "非线性", 1, null, "nonlinearity_range_icon")]
    public class RangeBlockTool : BaseTool<RangeBlock>
    {
    }
}
