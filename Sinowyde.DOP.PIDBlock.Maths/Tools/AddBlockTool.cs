using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// 加法算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("加法算法块", "数学运算", 1, null, "math_add_icon")]
    public class AddBlockTool : BaseTool<AddBlock>
    {        
    }
}
