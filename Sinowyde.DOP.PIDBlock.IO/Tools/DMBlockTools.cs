using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// �߼������
    /// </summary>

    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�߼������", "�������", 6, null, "io_dmop_icon")]
    public class DMBlockTool : BaseTool<DMBlock>
    {
    }
}
