using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "��ѧ����", 2, null, "math_sub_icon")]
    public class SubBlockTool : BaseTool<SubBlock>
    {
    }
}
