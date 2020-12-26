using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    /// 开关算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("开关算法块", "非线性", 6, null, "nonlinearity_switch_icon")]
    public class SwitchBlockTool : BaseTool<SwitchBlock>
    {
    }
}
