using Sinowyde.DOP.PIDAlgorithm.Choice;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Choice
{
     ///<summary>
/// ���ֵ�㷨�飨MAX��Maximum2a2fc
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���ֵ�㷨��", "ѡ����", 6, null, "choice_max_icon")]
    public class MaxBlockTool : BaseTool<MaxBlock>
    {

    }
}
