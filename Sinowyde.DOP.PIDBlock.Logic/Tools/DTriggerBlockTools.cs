using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// D触发器算法块 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("D触发器算法块", "逻辑功能", 7, null, "logic_dtrig_icon")]
    public class DTriggerBlockTool : BaseTool<DTriggerBlock>
    {

    }
}
