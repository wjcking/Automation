using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;


namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 与算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("与算法块", "逻辑功能", 1, null, "logic_and_icon")]
    public class AndBlockTool : BaseTool<AndBlock>
    {

    }
}
