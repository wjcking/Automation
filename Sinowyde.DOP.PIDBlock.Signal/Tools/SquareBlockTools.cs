using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 方波信号算法块（Square）Square wave Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("方波信号算法块", "信号源", 4, null, "signal_square_icon")]
    public class SquareBlockTool : BaseTool<SquareBlock>
    {

    }
}
