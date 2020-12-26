using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.2 PID�Ż��㷨�飨PIDEX��AI08255
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("PID�Ż��㷨��", "���ƹ���", 2, null, "control_pidex_icon")]
    public class PidexBlockTool : BaseTool<PidexBlock>
    {
         
    }
}
