using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    ///���ּ�϶�㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���ּ�϶�㷨��", "������", 7, null, "nonlinearity_gearbl_icon")]
    public class GearBLBlockTool : BaseTool<GearBLBlock>
    {
    }
}
