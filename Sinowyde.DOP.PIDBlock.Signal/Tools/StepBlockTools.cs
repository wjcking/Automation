using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// ��Ծ�ź��㷨�飨Step��Step Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��Ծ�ź��㷨��", "�ź�Դ", 1, null, "signal_step_icon")]
    public class StepBlockTool : BaseTool<StepBlock>
    {

    }
}
