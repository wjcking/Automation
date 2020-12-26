using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    ///<summary>
    /// 指数函数算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("指数函数算法块", "数学运算", 7, null, "math_exp_icon")]
    public class ExpBlockTool : BaseTool<ExpBlock>
    {
    }
}
