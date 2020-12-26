using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 数字信号 3 选 2 算法块（DG）Digital Signal 2 OF 31cf8a
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字信号 3 选 2 算法块", "选择功能", 8, null, "choice_dg_icon")]
    public class DgBlockTool : BaseTool<DgBlock>
    {
        
    }
}
