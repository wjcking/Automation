using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using System.ComponentModel.Composition;
using System.Reflection;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    ///<summary>
    ///�����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "������", 5, null, "nonlinearity_dead_icon")]
    public class DeadBlockTool : BaseTool<DeadBlock>
    {
    }
}
