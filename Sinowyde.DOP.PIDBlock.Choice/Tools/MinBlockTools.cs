using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 最小值算法块（MIN）Minimumb68e3
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("最小值算法块", "选择功能", 7, null, "choice_min_icon")]
    public class MinBlockTool : BaseTool<MinBlock>
    {

    }
}
