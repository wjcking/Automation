using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    /// <summary>
    /// ��ֵ�����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ֵ�����㷨��", "������", 2, null, "nonlinearity_rangealm_icon")]
    public class RangAlmBlockTool : BaseTool<RangAlmBlock>
    {
    }

}