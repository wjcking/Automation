using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �ݺ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�ݺ����㷨��", "��ѧ����", 8, null, "math_power_icon")]
    public class PowerBlockTool : BaseTool<PowerBlock>
    {
    }
}
