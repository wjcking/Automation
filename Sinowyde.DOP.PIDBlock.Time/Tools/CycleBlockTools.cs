using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 周期定时器算法块（Cycle） Timeraa2a5
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("周期定时器算法块", "时间功能", 3, null, "math_cycle_icon")]
    public class CycleBlockTool : BaseTool<CycleBlock>
    {
         
    }
}
