using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// ����������㷨
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("����������㷨", "�������", 4, null, "io_dgop_icon")]
    public class DOBlockTool : BaseTool<DOBlock>
    {
    }
}
