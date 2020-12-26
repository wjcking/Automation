using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 幂函数算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("幂函数算法块", "数学运算", 8, null, "math_power_icon")]
    public class PowerBlockTool : BaseTool<PowerBlock>
    {
    }
}
