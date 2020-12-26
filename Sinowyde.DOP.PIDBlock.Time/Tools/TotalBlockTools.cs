using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 积算器算法块（TOTAL）Total
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("积算器算法块", "时间功能", 4, null, "time_total_icon")]
    public class TotalBlockTool : BaseTool<TotalBlock>
    {

    }
}
