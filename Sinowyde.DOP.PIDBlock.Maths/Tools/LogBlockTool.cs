using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "��ѧ����", 9, null, "math_log_icon")]
    public class LogBlockTool : BaseTool<LogBlock>
    {
    }
}
