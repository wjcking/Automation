using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.DataModel
{
    /// <summary>
    /// IO topic
    /// </summary>
    public class IOTopic
    {
        /// <summary>
        /// read data
        /// </summary>
        public const string IORead = "IORead";
        /// <summary>
        /// write data
        /// </summary>
        public const string IOWrite = "IOWrite";
        /// <summary>
        /// calc data
        /// </summary>
        public const string IOCalc = "IOCalc";
        /// <summary>
        /// 临时点
        /// </summary>
        public const string IOTemp = "IOTemp";
        /// <summary>
        /// alarm
        /// </summary>
        public const string IOAlarm = "IOAlarm";
        /// <summary>
        /// event
        /// </summary>
        public const string IOEvent = "IOEvent";
    }
}
