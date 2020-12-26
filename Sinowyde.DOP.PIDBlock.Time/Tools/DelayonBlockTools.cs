using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.7延时开算法块（DelayOn）
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("延时开算法块", "时间功能", 6, null, "time_delayon_icon")]
    public class DelayonBlockTool : BaseTool<DelayonBlock>
    {

    }
}
