using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.14  �������������㷨�飨3SI��TRANS386431
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("5.14  �������������㷨��", "���ƹ���", 14, null, "math_3si_icon")]
    public class C3siBlockTool : BaseTool<C3siBlock>
    {
         
    }
}
