using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    /// <summary>
    /// 数字给定值发生器
    /// </summary>
    public enum DsetPulseStyle
    {
        Pulse = 0,
        UpDown = 1,
        LongSignal = 2
    }
    public class DsetPulseHelper : EnumDataHelper<DsetPulseStyle>
    {
        protected override void InitValue()
        {
            valueMap.Add("脉冲", DsetPulseStyle.Pulse);
            valueMap.Add("翻转", DsetPulseStyle.UpDown);
            valueMap.Add("长信号", DsetPulseStyle.LongSignal);
        }
    }
    public enum PidOutMode : int
    {
        Increment = 0,
        Position = 1
    }

    public class PidOutModeText : EnumDataHelper<PidOutMode>
    { 
        protected override void InitValue()
        {
            valueMap.Add("增量式", PidOutMode.Increment);
            valueMap.Add("位置式", PidOutMode.Position);
        }
    }

    /// <summary>
    /// 动作方向
    /// </summary>
    public enum PidDirect : int
    {
        Positive =0,
        Negative =1
    }

    public class PidDirectText : EnumDataHelper<PidDirect>
    {
        protected override void InitValue()
        {
            valueMap.Add("正作用", PidDirect.Positive);
            valueMap.Add("反作用", PidDirect.Negative);
        }
    }
}
