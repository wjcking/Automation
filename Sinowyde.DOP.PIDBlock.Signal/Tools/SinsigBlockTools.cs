using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// �����ź��㷨�飨SinSig��Sin Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����ź��㷨��", "�ź�Դ", 3, null, "signal_sinsig_icon")]
    public class SinsigBlockTool : BaseTool<SinsigBlock>
    {

    }
}
