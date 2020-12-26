using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// 异或算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("异或算法块", "逻辑功能", 4, null, "logic_xor_icon")]
    public class XorBlockTool : BaseTool<XorBlock>
    {

    }
}
