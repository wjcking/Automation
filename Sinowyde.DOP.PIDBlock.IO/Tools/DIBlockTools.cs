using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// �����������㷨
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����������㷨", "�������", 3, null, "io_dgin_icon")]
    public class DIBlockTool : BaseTool<DIBlock>
    {
    }
}
