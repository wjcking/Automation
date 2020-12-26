using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 微分算法块（DIFF） 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("微分算法块", "线性功能", 5, null, "linearity_diff_icon")]
    public class DiffBlockTool : BaseTool<DiffBlock>
    {

    }
}
