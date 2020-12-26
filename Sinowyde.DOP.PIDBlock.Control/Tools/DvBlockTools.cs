using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.15  设备驱动算法块（DV）DEVICE 　a3226
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.15  设备驱动算法块", "控制功能", 15, null, "math_dv_icon")]
    public class DvBlockTool : BaseTool<DvBlock>
    {
         
    }
}
