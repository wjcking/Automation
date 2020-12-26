using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// æ‚≥›≤®–≈∫≈À„∑®øÈ£®Sawtooth£©Sawtooth wave Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("æ‚≥›≤®–≈∫≈À„∑®øÈ", "–≈∫≈‘¥", 5, null, "signal_sawtooth_icon")]
    public class SawtoothBlockTool : BaseTool<SawtoothBlock>
    {

    }
}
