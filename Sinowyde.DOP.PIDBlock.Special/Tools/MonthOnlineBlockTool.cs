using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.Special
{
    ///<summary>
    /// 月在线时长算法块
    /// </summary>
    [Export(typeof(IToolBlock))]
    [ExportBlockMetaDataAttribute("月在线时长算法块", "特殊", 2, null, "special_monthonline_icon")]
    public class MonthOnlineBlockTool : BaseTool<MonthOnlineBlock>
    {

    }
}
