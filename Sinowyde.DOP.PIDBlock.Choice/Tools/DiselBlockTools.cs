using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 数字量输入选择算法块（DISEL）Digital Input Selection49dae
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字量输入选择算法块", "选择功能", 3, null, "choice_disel_icon")]
    public class DiselBlockTool : BaseTool<DiselBlock>
    {
        
    }
}
