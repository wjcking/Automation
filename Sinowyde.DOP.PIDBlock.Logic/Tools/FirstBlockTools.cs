using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// �׳�
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�׳��㷨��", "�߼�����", 12, null, "logic_first_icon")]
    public class FirstBlockTool : BaseTool<FirstBlock>
    {

    }
}
