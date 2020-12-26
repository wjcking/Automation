using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 纯延迟算法块（DALAY）
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("纯延迟算法块", "线性功能", 3, null, "linearity_dalay_icon")]
    public class DalayBlockTool : BaseTool<DalayBlock>
    {

    }
}
