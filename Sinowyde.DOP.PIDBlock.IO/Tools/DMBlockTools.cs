using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 逻辑量输出
    /// </summary>

    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("逻辑量输出", "输入输出", 6, null, "io_dmop_icon")]
    public class DMBlockTool : BaseTool<DMBlock>
    {
    }
}
