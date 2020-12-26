using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 数字手动站算法块（DMS）Digital Man Stationb54c9
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字手动站算法块", "控制功能", 6, null, "math_dms_icon")]
    public class DmsBlockTool : BaseTool<DmsBlock>
    {
         
    }
}
