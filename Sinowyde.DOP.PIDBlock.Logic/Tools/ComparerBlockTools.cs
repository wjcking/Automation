using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic.Tools
{
    ///<summary>
    /// �Ƚ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�Ƚ����㷨��", "�߼�����", 9, null, "logic_comp_icon")]
    public class CompBlockTool : BaseTool<CompBlock>
    {

    }
}
