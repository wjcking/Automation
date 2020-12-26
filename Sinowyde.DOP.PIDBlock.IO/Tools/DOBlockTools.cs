using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 数字量输出算法
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字量输出算法", "输入输出", 4, null, "io_dgop_icon")]
    public class DOBlockTool : BaseTool<DOBlock>
    {
    }
}
