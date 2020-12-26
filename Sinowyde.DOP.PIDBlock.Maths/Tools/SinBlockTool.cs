using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 三角函数算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("三角函数算法块", "数学运算", 10, null, "math_sin_icon")]
    public class SinBlockTool : BaseTool<SinBlock>
    {
    }
}
