using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Signal;


namespace Sinowyde.DOP.PIDBlock.Signal
{
    ///<summary>
    /// 正弦信号算法块（SinSig）Sin Signal
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("正弦信号算法块", "信号源", 3, null, "signal_sinsig_icon")]
    public class SinsigBlockTool : BaseTool<SinsigBlock>
    {

    }
}
