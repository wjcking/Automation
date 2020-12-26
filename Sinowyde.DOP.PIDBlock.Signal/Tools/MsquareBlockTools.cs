using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ��η����ź��㷨�飨MSquare��Multi-Square Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��η����ź��㷨��", "�ź�Դ", 7, null, "signal_msquare_icon")]
    public class MsquareBlockTool : BaseTool<MsquareBlock>
    {

    }
}
