using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// 离散传递函数算法块（DTF）Discrete Trans Function9259e
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("离散传递函数算法块", "线性功能", 8, null, "math_dtf_icon")]
    public class DtfBlockTool : BaseTool<DtfBlock>
    {
         
    }
}
