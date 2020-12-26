using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.4模拟手动站算法块（MA）Analogue Man Station3b8d4
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.4模拟手动站算法块", "控制功能", 4, null, "math_ma_icon")]
    public class MaBlockTool : BaseTool<MaBlock>
    {
         
    }
}
