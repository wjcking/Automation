using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// ���ָ���ֵ�������㷨�飨DSETPOINT��DSET0ce89
    /// </summary> 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���ָ���ֵ�������㷨��", "���ƹ���", 8, null, "control_dsetpoint_icon")]
    public class DsetpointBlockTool : BaseTool<DsetpointBlock>
    {

    }
}
