using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 开方算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("开方算法块", "数学运算", 5, null, "math_sqrt_icon")]
    public class SqrtBlockTool : BaseTool<SqrtBlock>
    {
    }
}
