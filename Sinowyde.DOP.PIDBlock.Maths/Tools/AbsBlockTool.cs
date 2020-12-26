using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    ///<summary>
    /// 绝对值算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("绝对值算法块", "数学运算", 6, null, "math_abs_icon")]
    public class AbsBlockTool : BaseTool<AbsBlock>
    {
    }
}
