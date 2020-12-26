using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 减法算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("减法算法块", "数学运算", 2, null, "math_sub_icon")]
    public class SubBlockTool : BaseTool<SubBlock>
    {
    }
}
