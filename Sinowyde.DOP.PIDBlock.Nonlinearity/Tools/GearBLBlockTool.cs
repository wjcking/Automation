using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    ///齿轮间隙算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("齿轮间隙算法块", "非线性", 7, null, "nonlinearity_gearbl_icon")]
    public class GearBLBlockTool : BaseTool<GearBLBlock>
    {
    }
}
