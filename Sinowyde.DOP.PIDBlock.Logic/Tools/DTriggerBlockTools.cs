using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// D�������㷨�� 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("D�������㷨��", "�߼�����", 7, null, "logic_dtrig_icon")]
    public class DTriggerBlockTool : BaseTool<DTriggerBlock>
    {

    }
}
