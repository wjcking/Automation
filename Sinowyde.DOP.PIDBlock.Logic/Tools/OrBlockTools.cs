using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ���㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���㷨��", "�߼�����", 2, null, "logic_or_icon")]
    public class OrBlockTool : BaseTool<OrBlock>
    {

    }
}
