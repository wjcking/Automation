using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.DOP.DataModel;
using System.Windows.Forms;


namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制矩形
    /// </summary>
    [Serializable]
    public class DOPRectangle : DOPGraphElement
    {
        public DOPRectangle()
            :base()
        {
            this.Add(new GoRectangle());
        }
        /// <summary>
        /// 获取图对象
        /// </summary>
        private GoRectangle Shape
        {
            get
            {
                return this.First as GoRectangle;
            }
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlGraphParam(this) { Name = "矩形属性" };
        }

    }
}
