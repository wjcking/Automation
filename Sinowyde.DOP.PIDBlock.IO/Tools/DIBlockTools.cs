using Sinowyde.DOP.PIDAlgorithm.IO;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.IO
{
    ///<summary>
    /// 数字量输入算法
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("数字量输入算法", "输入输出", 3, null, "io_dgin_icon")]
    public class DIBlockTool : BaseTool<DIBlock>
    {
    }
}
