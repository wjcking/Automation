using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.DOP.PIDBlock;
using System.ComponentModel.Composition;
using Sinowyde.DOP.PIDBlock.Linearity;


namespace Sinowyde.DOP.PIDBlock.Linearity
{
    ///<summary>
    /// ���ӳ��㷨�飨DALAY��
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("���ӳ��㷨��", "���Թ���", 3, null, "linearity_dalay_icon")]
    public class DalayBlockTool : BaseTool<DalayBlock>
    {

    }
}
