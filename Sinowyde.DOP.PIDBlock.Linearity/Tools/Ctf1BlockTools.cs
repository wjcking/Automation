using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// 连续传递函数 1 算法块（CTF1）ContinuousTransFunction1d6874
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("连续传递函数 1 算法块", "线性功能", 6, null, "math_ctf1_icon")]
    public class Ctf1BlockTool : BaseTool<Ctf1Block>
    {
         
    }
}
