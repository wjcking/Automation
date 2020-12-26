using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    /// 滞环开关算法块（HYLOOP）Hysteresis Loopa33de
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("滞环开关算法块", "非线性", 8, null, "nonlinearity_hyloop_icon")]
    public class HyloopBlockTool : BaseTool<HyloopBlock>
    {

    }
}
