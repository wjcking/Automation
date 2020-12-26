using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// 中值选择算法块（MED）Median Value9f673
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("中值选择算法块", "选择功能", 5, null, "choice_med_icon")]
    public class MedBlockTool : BaseTool<MedBlock>
    {
         
    }
}
