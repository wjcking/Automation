using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ����������ѡ���㷨�飨DISEL��Digital Input Selection49dae
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("����������ѡ���㷨��", "ѡ����", 3, null, "choice_disel_icon")]
    public class DiselBlockTool : BaseTool<DiselBlock>
    {
        
    }
}
