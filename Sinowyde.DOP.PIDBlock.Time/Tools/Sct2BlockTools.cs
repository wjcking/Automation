using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
    ///<summary>
    /// ϵͳ��ǰʱ�书�ܿ�2
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ϵͳ��ǰʱ�书�ܿ�2", "ʱ�书��", 6, null, "time_sct2_icon")]
    public class Sct2BlockTool : BaseTool<Sct2Block>
    {

    }
}
