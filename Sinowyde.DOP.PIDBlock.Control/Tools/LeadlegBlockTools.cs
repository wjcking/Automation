using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// ��ǰ�ͺ��㷨�飨LEADLEG��LEADLEGaabce
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ǰ�ͺ��㷨��", "���ƹ���", 9, null, "control_leadleg_icon")]
    public class LeadlegBlockTool : BaseTool<LeadlegBlock>
    {
         
    }
}
