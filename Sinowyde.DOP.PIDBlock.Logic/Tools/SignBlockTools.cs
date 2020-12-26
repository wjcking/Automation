using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// ·ûºÅÅÐ¶ÏËã·¨¿é
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("·ûºÅÅÐ¶ÏËã·¨¿é", "Âß¼­¹¦ÄÜ", 5, null, "logic_sign_icon")]
    public class SignBlockTool : BaseTool<SignBlock>
    {

    }
}
