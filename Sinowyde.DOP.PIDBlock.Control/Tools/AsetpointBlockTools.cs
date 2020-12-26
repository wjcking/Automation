using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// 模拟给定值发生器算法块（ASETPOINT）ASET28234
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("模拟给定值发生器算法块", "控制功能", 7, null, "control_asetpoint_icon")]
    public class AsetpointBlockTool : BaseTool<AsetpointBlock>
    {

    }
}
