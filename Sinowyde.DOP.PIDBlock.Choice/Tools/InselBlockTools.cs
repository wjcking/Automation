using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ģ��������ѡ���㷨�飨INSEL��Input Selection398f0
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ģ��������ѡ���㷨��", "ѡ����", 1, null, "choice_insel_icon")]
    public class InselBlockTool : BaseTool<InselBlock>
    {
       
    }
}
