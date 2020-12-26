using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// RS触发器算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("RS触发器算法块", "逻辑功能", 6, null, "logic_rstrig_icon")]
    public class RstrigBlockTool : BaseTool<RSTriggerBlock>
    {

    }
}
