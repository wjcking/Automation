using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// �������㷨�飨TOTAL��Total
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�������㷨��", "ʱ�书��", 4, null, "time_total_icon")]
    public class TotalBlockTool : BaseTool<TotalBlock>
    {

    }
}
