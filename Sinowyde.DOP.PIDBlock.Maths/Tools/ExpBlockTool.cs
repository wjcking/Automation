using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    ///<summary>
    /// ָ�������㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ָ�������㷨��", "��ѧ����", 7, null, "math_exp_icon")]
    public class ExpBlockTool : BaseTool<ExpBlock>
    {
    }
}
