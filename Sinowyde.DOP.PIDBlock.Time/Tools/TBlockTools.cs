using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 定时器算法块（T）Timer20ca2
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("定时器算法块", "时间功能", 1, null, "math_t_icon")]
    public class TBlockTool : BaseTool<TBlock>
    {
         
    }
}
