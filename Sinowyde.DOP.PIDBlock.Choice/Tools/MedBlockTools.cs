using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ��ֵѡ���㷨�飨MED��Median Value9f673
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ֵѡ���㷨��", "ѡ����", 5, null, "choice_med_icon")]
    public class MedBlockTool : BaseTool<MedBlock>
    {
         
    }
}
