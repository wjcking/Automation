using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// �����ж��㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����ж��㷨��", "�߼�����", 5, null, "logic_sign_icon")]
    public class SignBlockTool : BaseTool<SignBlock>
    {

    }
}
