using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 除法算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("除法算法块", "数学运算", 4, null, "math_div_icon")]
    public class DivBlockTool : BaseTool<DivBlock>
    {
    }
}
