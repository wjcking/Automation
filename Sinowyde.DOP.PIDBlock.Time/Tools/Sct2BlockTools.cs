using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// 系统当前时间功能块2
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("系统当前时间功能块2", "时间功能", 6, null, "time_sct2_icon")]
    public class Sct2BlockTool : BaseTool<Sct2Block>
    {

    }
}
