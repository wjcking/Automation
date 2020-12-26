using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// б���ź��㷨�飨Ramp��Ramp Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("б���ź��㷨��", "�ź�Դ", 2, null, "signal_ramp_icon")]
    public class RampBlockTool : BaseTool<RampBlock>
    {

    }
}
