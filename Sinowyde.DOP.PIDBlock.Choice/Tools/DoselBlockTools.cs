using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 数字量输出选择算法块（DOSEL）Digital Output Selection93264
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字量输出选择算法块", "选择功能", 4, null, "choice_dosel_icon")]
    public class DoselBlockTool : BaseTool<DoselBlock>
    { 
    }
}
