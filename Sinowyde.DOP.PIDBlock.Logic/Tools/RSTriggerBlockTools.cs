using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// RS�������㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("RS�������㷨��", "�߼�����", 6, null, "logic_rstrig_icon")]
    public class RstrigBlockTool : BaseTool<RSTriggerBlock>
    {

    }
}
