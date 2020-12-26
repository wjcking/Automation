using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.9脉冲整形算法块（PULSE） 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("脉冲整形算法块", "时间功能", 8, null, "time_pulse_icon")]
    public class PulseBlockTool : BaseTool<PulseBlock>
    {

    }
}
