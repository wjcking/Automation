using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// ���ڶ�ʱ���㷨�飨Cycle�� Timeraa2a5
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���ڶ�ʱ���㷨��", "ʱ�书��", 3, null, "math_cycle_icon")]
    public class CycleBlockTool : BaseTool<CycleBlock>
    {
         
    }
}
