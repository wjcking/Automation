using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// PID控制算法块（PID）PID2c5b1
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("PID控制算法块", "控制功能", 1, null, "math_pid_icon")]
    public class PidBlockTool : BaseTool<PidBlock>
    {
         
    }
}
