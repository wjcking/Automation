using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// ��ɢ���ݺ����㷨�飨DTF��Discrete Trans Function9259e
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ɢ���ݺ����㷨��", "���Թ���", 8, null, "math_dtf_icon")]
    public class DtfBlockTool : BaseTool<DtfBlock>
    {
         
    }
}
