using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ���������ѡ���㷨�飨DOSEL��Digital Output Selection93264
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���������ѡ���㷨��", "ѡ����", 4, null, "choice_dosel_icon")]
    public class DoselBlockTool : BaseTool<DoselBlock>
    { 
    }
}
