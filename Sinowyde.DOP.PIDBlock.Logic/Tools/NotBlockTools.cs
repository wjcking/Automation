using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 非算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("非算法块", "逻辑功能", 3, null, "logic_not_icon")]
    public class NotBlockTool : BaseTool<NotBlock>
    {

    }
}
