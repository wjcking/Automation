using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// 速率算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("速率算法块", "非线性", 3, null, "nonlinearity_ratio_icon")]
    public class RatioBlockTool : BaseTool<RatioBlock>
    {
    }
}
