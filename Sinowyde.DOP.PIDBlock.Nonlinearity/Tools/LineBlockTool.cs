using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    /// 分段线性算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("分段线性算法块", "非线性", 10, null, "nonlinearity_line_icon")]
    public class LineBlockTool : BaseTool<LineBlock>
    {
    }
}