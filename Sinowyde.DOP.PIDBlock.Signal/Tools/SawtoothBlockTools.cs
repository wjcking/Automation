using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ��ݲ��ź��㷨�飨Sawtooth��Sawtooth wave Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ݲ��ź��㷨��", "�ź�Դ", 5, null, "signal_sawtooth_icon")]
    public class SawtoothBlockTool : BaseTool<SawtoothBlock>
    {

    }
}
