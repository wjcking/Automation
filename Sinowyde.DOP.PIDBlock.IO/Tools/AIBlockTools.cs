using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// ģ���������㷨
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ģ���������㷨", "�������", 1, null, "io_anin_icon")]
    public class AIBlockTool : BaseTool<AIBlock>
    {
    }
}
