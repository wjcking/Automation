using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
    ///<summary>
    /// ģ�����ֵ�������㷨�飨ASETPOINT��ASET28234
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ģ�����ֵ�������㷨��", "���ƹ���", 7, null, "control_asetpoint_icon")]
    public class AsetpointBlockTool : BaseTool<AsetpointBlock>
    {

    }
}
