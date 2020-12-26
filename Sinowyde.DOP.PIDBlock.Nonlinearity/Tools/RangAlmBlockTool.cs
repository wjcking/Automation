using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// 幅值报警算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("幅值报警算法块", "非线性", 2, null, "nonlinearity_rangealm_icon")]
    public class RangAlmBlockTool : BaseTool<RangAlmBlock>
    {
    }

}