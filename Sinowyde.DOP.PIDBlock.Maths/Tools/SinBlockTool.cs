using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// ���Ǻ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���Ǻ����㷨��", "��ѧ����", 10, null, "math_sin_icon")]
    public class SinBlockTool : BaseTool<SinBlock>
    {
    }
}
