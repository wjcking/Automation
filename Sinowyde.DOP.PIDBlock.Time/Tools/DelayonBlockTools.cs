using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.7��ʱ���㷨�飨DelayOn��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ʱ���㷨��", "ʱ�书��", 6, null, "time_delayon_icon")]
    public class DelayonBlockTool : BaseTool<DelayonBlock>
    {

    }
}
