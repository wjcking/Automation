using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "��ѧ����", 5, null, "math_sqrt_icon")]
    public class SqrtBlockTool : BaseTool<SqrtBlock>
    {
    }
}
