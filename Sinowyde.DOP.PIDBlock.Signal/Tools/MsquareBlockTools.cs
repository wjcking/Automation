using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 多段方波信号算法块（MSquare）Multi-Square Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("多段方波信号算法块", "信号源", 7, null, "signal_msquare_icon")]
    public class MsquareBlockTool : BaseTool<MsquareBlock>
    {

    }
}
