using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    /// <summary>
    /// 定时器工作方式
    /// </summary>
    public enum TMode : int
    {
        TimerBasic = 0,
        Pulse = 1,
        TDON = 2,
        TDOFF = 3,
        LSH = 4,
    }

    public class TModeText : EnumDataHelper<TMode>
    { 
        protected override void InitValue()
        {
            base.valueMap.Add("基础", TMode.TimerBasic);
            base.valueMap.Add("单脉冲", TMode.Pulse);
            base.valueMap.Add("滞后位置", TMode.TDON);
            base.valueMap.Add("滞后复位", TMode.TDOFF);
            base.valueMap.Add("滞后位置保持", TMode.LSH); 
        }
    }
    /// <summary>
    /// 累加和、取平均、取最大、取最小、梯形累加和。
    /// </summary>
    public enum TotalMode : int
    {
        Sum = 0,
        Avg = 1,
        Max = 2,
        Min = 3,
        StepSum = 4
    }

    public class TotalModeText : EnumDataHelper<TotalMode>
    { 
        protected override void InitValue()
        {
            base.valueMap.Add("累加和", TotalMode.Sum);
            base.valueMap.Add("取平均", TotalMode.Avg);
            base.valueMap.Add("取最大", TotalMode.Max);
            base.valueMap.Add("取最小", TotalMode.Min);
            base.valueMap.Add("梯形累加和", TotalMode.StepSum); 
        }
    }
}
