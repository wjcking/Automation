using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Control;


namespace Sinowyde.DOP.PIDBlock.Control
{
     ///<summary>
/// 5.5M/Aվ�Ż��㷨�飨MAEX��91f77
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("M/Aվ�Ż��㷨��", "���ƹ���", 5, null, "control_maex_icon")]
    public class MaexBlockTool : BaseTool<MaexBlock>
    {
         
    }
}
