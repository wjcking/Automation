using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// ��ֵ�����
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ֵ�����", "�������", 5, null, "io_amop_icon")]
    public class AMBlockTool : BaseTool<AMBlock>
    {
    }
}
