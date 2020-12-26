using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// �����ź��㷨�飨Square��Square wave Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����ź��㷨��", "�ź�Դ", 4, null, "signal_square_icon")]
    public class SquareBlockTool : BaseTool<SquareBlock>
    {

    }
}
