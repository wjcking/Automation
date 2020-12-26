using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 数值量输出
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数值量输出", "输入输出", 5, null, "io_amop_icon")]
    public class AMBlockTool : BaseTool<AMBlock>
    {
    }
}
