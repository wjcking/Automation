using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic.Tools
{
    ///<summary>
    /// 比较器算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("比较器算法块", "逻辑功能", 9, null, "logic_comp_icon")]
    public class CompBlockTool : BaseTool<CompBlock>
    {

    }
}
