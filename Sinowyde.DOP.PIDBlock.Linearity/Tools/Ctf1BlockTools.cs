using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// �������ݺ��� 1 �㷨�飨CTF1��ContinuousTransFunction1d6874
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�������ݺ��� 1 �㷨��", "���Թ���", 6, null, "math_ctf1_icon")]
    public class Ctf1BlockTool : BaseTool<Ctf1Block>
    {
         
    }
}
