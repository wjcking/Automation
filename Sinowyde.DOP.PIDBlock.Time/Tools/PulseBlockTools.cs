using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.9���������㷨�飨PULSE�� 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���������㷨��", "ʱ�书��", 8, null, "time_pulse_icon")]
    public class PulseBlockTool : BaseTool<PulseBlock>
    {

    }
}
