using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// ģ��������㷨
    /// </summary>

    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ģ��������㷨", "�������", 2, null, "io_anop_icon")]
    public class AOBlockTool : BaseTool<AOBlock>
    {
    }
}
