using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// ���ʱ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���ʱ����㷨��", "������", 4, null, "nonlinearity_ratioalm_icon")]
    public class RatioAlmBlockTool : BaseTool<RatioAlmBlock>
    {
    }
}
