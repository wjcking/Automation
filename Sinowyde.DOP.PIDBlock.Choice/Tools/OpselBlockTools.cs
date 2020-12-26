using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 模拟量输出选择算法块（OPSEL）Output Selection3b6e5
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("模拟量输出选择算法块", "选择功能", 2, null, "choice_opsel_icon")]
    public class OpselBlockTool : BaseTool<OpselBlock>
    { 
    }
}
