using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.14  三变送器整合算法块（3SI）TRANS386431
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.14  三变送器整合算法块", "控制功能", 14, null, "math_3si_icon")]
    public class C3siBlockTool : BaseTool<C3siBlock>
    {
         
    }
}
