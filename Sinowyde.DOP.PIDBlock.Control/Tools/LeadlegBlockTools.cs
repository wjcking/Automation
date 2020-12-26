using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 超前滞后算法块（LEADLEG）LEADLEGaabce
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("超前滞后算法块", "控制功能", 9, null, "control_leadleg_icon")]
    public class LeadlegBlockTool : BaseTool<LeadlegBlock>
    {
         
    }
}
