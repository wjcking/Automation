using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
     ///<summary>
/// �������ݺ��� 2 �㷨�飨CTF2��ContinuousTransFunction2b96a3
/// </summary>
 
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�������ݺ��� 2 �㷨��", "���Թ���", 7, null, "math_ctf2_icon")]
    public class Ctf2BlockTool : BaseTool<Ctf2Block>
    {
         
    }
}
