using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// �����㷨�飨INTEG��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����㷨��", "���Թ���", 4, null, "linearity_integ_icon")]
    public class IntegBlockTool : BaseTool<IntegBlock>
    {

    }
}
