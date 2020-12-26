using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 首出
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("首出算法块", "逻辑功能", 12, null, "logic_first_icon")]
    public class FirstBlockTool : BaseTool<FirstBlock>
    {

    }
}
