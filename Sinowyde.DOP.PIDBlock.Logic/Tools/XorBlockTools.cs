using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ����㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("����㷨��", "�߼�����", 4, null, "logic_xor_icon")]
    public class XorBlockTool : BaseTool<XorBlock>
    {

    }
}
