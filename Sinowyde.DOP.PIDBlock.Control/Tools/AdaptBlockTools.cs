using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.3���ڵ�����Ԫ������Ӧ�����㷨�飨Adapt��6d50f
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.3���ڵ�����Ԫ������Ӧ�����㷨��", "���ƹ���", 3, null, "math_adapt_icon")]
    public class AdaptBlockTool : BaseTool<AdaptBlock>
    {
         
    }
}
