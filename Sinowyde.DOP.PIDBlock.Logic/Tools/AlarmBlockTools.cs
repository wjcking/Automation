using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ƫ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ƫ����㷨��", "�߼�����", 10, null, "logic_alm_icon")]
    public class AlarmBlockTool : BaseTool<AlarmBlock>
    {

    }
}
