using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.13  两变送器整合算法块（2SI）TRANS28f134
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.13  两变送器整合算法块", "控制功能", 13, null, "math_2si_icon")]
    public class C2siBlockTool : BaseTool<C2siBlock>
    {
         
    }
}
