using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ģ�������ѡ���㷨�飨OPSEL��Output Selection3b6e5
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("ģ�������ѡ���㷨��", "ѡ����", 2, null, "choice_opsel_icon")]
    public class OpselBlockTool : BaseTool<OpselBlock>
    { 
    }
}
