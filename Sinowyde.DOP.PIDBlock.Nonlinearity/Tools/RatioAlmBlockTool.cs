using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// 速率报警算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("速率报警算法块", "非线性", 4, null, "nonlinearity_ratioalm_icon")]
    public class RatioAlmBlockTool : BaseTool<RatioAlmBlock>
    {
    }
}
