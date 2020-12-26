using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 6.5系统当前时间功能块 （SCT）39fe8
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("系统当前时间功能块 ", "时间功能", 5, null, "time_sct_icon")]
    public class SctBlockTool : BaseTool<SctBlock>
    {
         
    }
}
