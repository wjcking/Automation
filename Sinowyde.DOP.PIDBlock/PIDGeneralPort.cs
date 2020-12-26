using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock
{
    [Serializable]
    public class PIDGeneralPort : GoGeneralNodePort
    {
        /// <summary>
        /// 相关变量
        /// </summary>
        public string RelatedVar { get; set; }

        public override float PortAndLabelHeight
        {
            get
            {
                return base.Height + 10;
            }
        }

        public override float PortAndLabelWidth
        {
            get
            {               
                return base.Width + 10;
            }
        }
    }
}
