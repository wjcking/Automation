using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// �����ź� 3 ѡ 2 �㷨�飨DG��Digital Signal 2 OF 31cf8a
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����ź� 3 ѡ 2 �㷨��", "ѡ����", 8, null, "choice_dg_icon")]
    public class DgBlockTool : BaseTool<DgBlock>
    {
        
    }
}
