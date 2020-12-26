using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 常系数算法块（CONST）
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("常系数算法块", "线性功能", 2, null, "linearity_const_icon")]
    public class ConstBlockTool : BaseTool<ConstBlock>
    {

    }
}
