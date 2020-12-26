using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.8��ʱ���㷨�飨DelayOff�� 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ʱ���㷨��", "ʱ�书��", 7, null, "time_delayoff_icon")]
    public class DelayoffBlockTool : BaseTool<DelayoffBlock>
    {

    }
}
