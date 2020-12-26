using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 7.8数字信号加法器算法块（DS）DGSUMa3059
    /// </summary>

    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字信号加法器算法块", "线性功能", 9, null, "linearity_ds_icon")]
    public class DsBlockTool : BaseTool<DsBlock>
    {

    }
}
