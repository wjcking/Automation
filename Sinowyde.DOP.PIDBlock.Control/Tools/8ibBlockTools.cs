using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 8 输入平衡算法块（8IB）8 INPUT BALANCE66f7f
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("8 输入平衡算法块", "控制功能", 11, null, "math_8ib_icon")]
    public class C8ibBlockTool : BaseTool<C8ibBlock>
    {
         
    }
}
