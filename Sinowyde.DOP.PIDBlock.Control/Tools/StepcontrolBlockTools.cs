using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// ��������㷨�飨STEPCONTROL��STEPCTL4ba56
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��������㷨��", "���ƹ���", 10, null, "math_stepcontrol_icon")]
    public class StepcontrolBlockTool : BaseTool<StepcontrolBlock>
    {
         
    }
}
