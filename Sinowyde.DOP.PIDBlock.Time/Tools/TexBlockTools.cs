using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Time;


namespace Sinowyde.DOP.PIDBlock.Time
{
     ///<summary>
/// ��ʱ���Ż��㷨�飨TEX��Timer65cb1
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ʱ���Ż��㷨��", "ʱ�书��", 2, null, "math_tex_icon")]
    public class TexBlockTool : BaseTool<TexBlock>
    {
         
    }
}
