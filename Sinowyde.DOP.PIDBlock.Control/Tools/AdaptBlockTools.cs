using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.3基于单个神经元的自适应控制算法块（Adapt）6d50f
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.3基于单个神经元的自适应控制算法块", "控制功能", 3, null, "math_adapt_icon")]
    public class AdaptBlockTool : BaseTool<AdaptBlock>
    {
         
    }
}
