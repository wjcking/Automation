using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 计数器算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("计数器算法块", "逻辑功能", 8, null, "logic_count_icon")]
    public class CountBlockTool : BaseTool<CountBlock>
    {

    }
}
