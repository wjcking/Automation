using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 2 ����ƽ���㷨�飨2IB��2 INPUT BALANCEfb4f2
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("2 ����ƽ���㷨��", "���ƹ���", 12, null, "math_2ib_icon")]
    public class C2ibBlockTool : BaseTool<C2ibBlock>
    {
         
    }
}
