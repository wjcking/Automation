using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ���㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���㷨��", "�߼�����", 3, null, "logic_not_icon")]
    public class NotBlockTool : BaseTool<NotBlock>
    {

    }
}
