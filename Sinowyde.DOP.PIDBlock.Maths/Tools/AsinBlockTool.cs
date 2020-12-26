using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 反三角函数算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("反三角函数算法块", "数学运算", 11, null, "math_asin_icon")]
    public class AsinBlockTool : BaseTool<AsinBlock>
    {
        
    }
}
