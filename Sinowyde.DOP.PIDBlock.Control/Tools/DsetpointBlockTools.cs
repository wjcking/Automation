using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 数字给定值发生器算法块（DSETPOINT）DSET0ce89
    /// </summary> 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字给定值发生器算法块", "控制功能", 8, null, "control_dsetpoint_icon")]
    public class DsetpointBlockTool : BaseTool<DsetpointBlock>
    {

    }
}
