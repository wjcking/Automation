using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.13  �������������㷨�飨2SI��TRANS28f134
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.13  �������������㷨��", "���ƹ���", 13, null, "math_2si_icon")]
    public class C2siBlockTool : BaseTool<C2siBlock>
    {
         
    }
}
