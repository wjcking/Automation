using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// ��ϵ���㷨�飨CONST��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("��ϵ���㷨��", "���Թ���", 2, null, "linearity_const_icon")]
    public class ConstBlockTool : BaseTool<ConstBlock>
    {

    }
}
