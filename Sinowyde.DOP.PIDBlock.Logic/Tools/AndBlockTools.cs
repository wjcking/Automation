using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;


namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ���㷨��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���㷨��", "�߼�����", 1, null, "logic_and_icon")]
    public class AndBlockTool : BaseTool<AndBlock>
    {

    }
}
