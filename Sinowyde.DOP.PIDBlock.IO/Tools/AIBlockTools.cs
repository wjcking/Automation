using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 模拟量输入算法
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("模拟量输入算法", "输入输出", 1, null, "io_anin_icon")]
    public class AIBlockTool : BaseTool<AIBlock>
    {
    }
}
