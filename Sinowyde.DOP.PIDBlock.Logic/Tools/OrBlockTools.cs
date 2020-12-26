using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 或算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("或算法块", "逻辑功能", 2, null, "logic_or_icon")]
    public class OrBlockTool : BaseTool<OrBlock>
    {

    }
}
