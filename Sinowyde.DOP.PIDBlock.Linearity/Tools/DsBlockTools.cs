using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// 7.8�����źżӷ����㷨�飨DS��DGSUMa3059
    /// </summary>

    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("�����źżӷ����㷨��", "���Թ���", 9, null, "linearity_ds_icon")]
    public class DsBlockTool : BaseTool<DsBlock>
    {

    }
}
