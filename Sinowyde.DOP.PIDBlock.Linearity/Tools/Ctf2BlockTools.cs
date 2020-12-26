using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// 连续传递函数 2 算法块（CTF2）ContinuousTransFunction2b96a3
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("连续传递函数 2 算法块", "线性功能", 7, null, "math_ctf2_icon")]
    public class Ctf2BlockTool : BaseTool<Ctf2Block>
    {
         
    }
}
