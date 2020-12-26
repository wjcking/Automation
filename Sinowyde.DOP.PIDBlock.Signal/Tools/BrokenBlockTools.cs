using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// �����ź��㷨�飨Broken��Broken Line Signa
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����ź��㷨��", "�ź�Դ", 6, null, "signal_broken_icon")]
    public class BrokenBlockTool : BaseTool<BrokenBlock>
    {
    }
}
