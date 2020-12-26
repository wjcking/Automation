using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 乘法算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("乘法算法块", "数学运算", 3, null, "math_mult_icon")]
    public class MultBlockTool : BaseTool<MultBlock>
    {
    }
}

