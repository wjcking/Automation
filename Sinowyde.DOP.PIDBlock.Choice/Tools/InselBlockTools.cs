using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 模拟量输入选择算法块（INSEL）Input Selection398f0
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("模拟量输入选择算法块", "选择功能", 1, null, "choice_insel_icon")]
    public class InselBlockTool : BaseTool<InselBlock>
    {
       
    }
}
