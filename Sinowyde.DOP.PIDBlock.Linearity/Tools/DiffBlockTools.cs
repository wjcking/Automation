using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// ΢���㷨�飨DIFF�� 
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("΢���㷨��", "���Թ���", 5, null, "linearity_diff_icon")]
    public class DiffBlockTool : BaseTool<DiffBlock>
    {

    }
}
