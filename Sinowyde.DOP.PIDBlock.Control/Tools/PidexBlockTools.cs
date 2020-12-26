using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.2 PID优化算法块（PIDEX）AI08255
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("PID优化算法块", "控制功能", 2, null, "control_pidex_icon")]
    public class PidexBlockTool : BaseTool<PidexBlock>
    {
         
    }
}
