using Sinowyde.DOP.PIDAlgorithm.Math;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Math
{
    /// <summary>
    /// �����Ǻ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����Ǻ����㷨��", "��ѧ����", 11, null, "math_asin_icon")]
    public class AsinBlockTool : BaseTool<AsinBlock>
    {
        
    }
}
