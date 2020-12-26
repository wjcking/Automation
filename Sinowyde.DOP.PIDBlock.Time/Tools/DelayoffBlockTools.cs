using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 6.8延时关算法块（DelayOff） 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("延时关算法块", "时间功能", 7, null, "time_delayoff_icon")]
    public class DelayoffBlockTool : BaseTool<DelayoffBlock>
    {

    }
}
