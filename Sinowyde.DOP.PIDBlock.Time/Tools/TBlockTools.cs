using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// ��ʱ���㷨�飨T��Timer20ca2
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ʱ���㷨��", "ʱ�书��", 1, null, "math_t_icon")]
    public class TBlockTool : BaseTool<TBlock>
    {
         
    }
}
