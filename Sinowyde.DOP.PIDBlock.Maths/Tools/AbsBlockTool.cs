using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    ///<summary>
    /// ����ֵ�㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("����ֵ�㷨��", "��ѧ����", 6, null, "math_abs_icon")]
    public class AbsBlockTool : BaseTool<AbsBlock>
    {
    }
}
