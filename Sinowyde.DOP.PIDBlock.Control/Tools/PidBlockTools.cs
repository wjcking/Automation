using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// PID�����㷨�飨PID��PID2c5b1
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("PID�����㷨��", "���ƹ���", 1, null, "math_pid_icon")]
    public class PidBlockTool : BaseTool<PidBlock>
    {
         
    }
}
