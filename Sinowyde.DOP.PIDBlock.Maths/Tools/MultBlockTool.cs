using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �˷��㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�˷��㷨��", "��ѧ����", 3, null, "math_mult_icon")]
    public class MultBlockTool : BaseTool<MultBlock>
    {
    }
}

