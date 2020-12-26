using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 积分算法块（INTEG）
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("积分算法块", "线性功能", 4, null, "linearity_integ_icon")]
    public class IntegBlockTool : BaseTool<IntegBlock>
    {

    }
}
