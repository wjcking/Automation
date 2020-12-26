using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// 6.5ϵͳ��ǰʱ�书�ܿ� ��SCT��39fe8
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ϵͳ��ǰʱ�书�ܿ� ", "ʱ�书��", 5, null, "time_sct_icon")]
    public class SctBlockTool : BaseTool<SctBlock>
    {
         
    }
}
