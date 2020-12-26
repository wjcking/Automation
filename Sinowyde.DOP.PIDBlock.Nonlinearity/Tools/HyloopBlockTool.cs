using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    /// �ͻ������㷨�飨HYLOOP��Hysteresis Loopa33de
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�ͻ������㷨��", "������", 8, null, "nonlinearity_hyloop_icon")]
    public class HyloopBlockTool : BaseTool<HyloopBlock>
    {

    }
}
