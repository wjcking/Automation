using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 对数算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("对数算法块", "数学运算", 9, null, "math_log_icon")]
    public class LogBlockTool : BaseTool<LogBlock>
    {
    }
}
