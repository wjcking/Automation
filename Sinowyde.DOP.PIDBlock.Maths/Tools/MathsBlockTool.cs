using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 数学多项式算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数学多项式算法块", "数学运算", 12, null, "math_maths_icon")]
    public class MathsBlockTool : BaseTool<MathsBlock>
    {
    }
}
