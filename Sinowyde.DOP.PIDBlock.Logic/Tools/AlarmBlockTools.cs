using Sinowyde.DOP.PIDAlgorithm.Logic;
using System.ComponentModel.Composition;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    ///<summary>
    /// Æ«²î±¨¾¯Ëã·¨¿é
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("Æ«²î±¨¾¯Ëã·¨¿é", "Âß¼­¹¦ÄÜ", 10, null, "logic_alm_icon")]
    public class AlarmBlockTool : BaseTool<AlarmBlock>
    {

    }
}
