using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �ӷ��㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�ӷ��㷨��", "��ѧ����", 1, null, "math_add_icon")]
    public class AddBlockTool : BaseTool<AddBlock>
    {        
    }
}
