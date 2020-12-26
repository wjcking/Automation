using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.Special
{
    ///<summary>
    /// 天在线时长算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("天在线时长算法块", "特殊", 1, null, "special_timeonline_icon")]
    public class TimeOnlineBlockTool : BaseTool<TimeOnlineBlock>
    {

    }
}
