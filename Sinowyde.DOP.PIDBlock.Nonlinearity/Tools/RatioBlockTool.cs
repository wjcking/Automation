using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// �����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "������", 3, null, "nonlinearity_ratio_icon")]
    public class RatioBlockTool : BaseTool<RatioBlock>
    {
    }
}
