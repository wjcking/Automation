using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    ///死区算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("死区算法块", "非线性", 5, null, "nonlinearity_dead_icon")]
    public class DeadBlockTool : BaseTool<DeadBlock>
    {
    }
}
