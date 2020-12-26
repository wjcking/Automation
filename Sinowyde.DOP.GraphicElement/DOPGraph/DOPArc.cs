using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.GraphicElement;

namespace Sinowyde.DOP.GraphicElement
{
    [Serializable]
    public class DOPArc : DOPGraphElement
    {
        public DOPArc()
            : base()
        {
            this.Add(new GoArc());
        }
        /// <summary>
        /// 获取图对象
        /// </summary>
        private GoArc Shape
        {
            get
            {
                return this.First as GoArc;
            }
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlGraphParam(this) { Name = "弧形属性" };
        }
    }
}
