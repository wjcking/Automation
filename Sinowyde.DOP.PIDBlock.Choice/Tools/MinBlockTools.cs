using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ��Сֵ�㷨�飨MIN��Minimumb68e3
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��Сֵ�㷨��", "ѡ����", 7, null, "choice_min_icon")]
    public class MinBlockTool : BaseTool<MinBlock>
    {

    }
}
