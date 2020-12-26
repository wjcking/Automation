using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 定时器优化算法块（TEX）Timer65cb1
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("定时器优化算法块", "时间功能", 2, null, "math_tex_icon")]
    public class TexBlockTool : BaseTool<TexBlock>
    {
         
    }
}
