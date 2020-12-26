using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 模拟量输出算法
    /// </summary>

    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("模拟量输出算法", "输入输出", 2, null, "io_anop_icon")]
    public class AOBlockTool : BaseTool<AOBlock>
    {
    }
}
