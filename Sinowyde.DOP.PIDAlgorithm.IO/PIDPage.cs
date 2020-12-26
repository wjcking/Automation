using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.IO
{
    /// <summary>
    /// 页间引用算法块
    /// </summary>
    [Serializable]
    public class PIDPage : PIDBindAlgorithm
    {
        public PIDPage(bool isInput)
            : base()
        { 
        }
        /// <summary>
        /// 是否是输入算法块
        /// </summary>
        public bool IsInput
        {
            get;
            set;
        }
    }
}
