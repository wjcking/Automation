using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ��ѧ����ʽ�㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ѧ����ʽ�㷨��", "��ѧ����", 12, null, "math_maths_icon")]
    public class MathsBlockTool : BaseTool<MathsBlock>
    {
    }
}
