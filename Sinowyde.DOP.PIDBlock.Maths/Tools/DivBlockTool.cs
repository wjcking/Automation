using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "��ѧ����", 4, null, "math_div_icon")]
    public class DivBlockTool : BaseTool<DivBlock>
    {
    }
}
