using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 最大值算法块（MAX）Maximum2a2fc
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("最大值算法块", "选择功能", 6, null, "choice_max_icon")]
    public class MaxBlockTool : BaseTool<MaxBlock>
    {

    }
}
