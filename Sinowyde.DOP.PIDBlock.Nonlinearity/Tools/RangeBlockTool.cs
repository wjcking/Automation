using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// ��ֵ�㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ֵ�㷨��", "������", 1, null, "nonlinearity_range_icon")]
    public class RangeBlockTool : BaseTool<RangeBlock>
    {
    }
}
