using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// �������㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�������㷨��", "�߼�����", 8, null, "logic_count_icon")]
    public class CountBlockTool : BaseTool<CountBlock>
    {

    }
}
