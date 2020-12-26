using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ����ź��㷨�飨Random��Random Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("����ź��㷨��", "�ź�Դ", 8, null, "signal_random_icon")]
    public class RandomBlockTool : BaseTool<RandomBlock>
    {

    }
}
