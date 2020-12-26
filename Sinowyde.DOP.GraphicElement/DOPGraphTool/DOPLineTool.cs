using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制直线
    /// </summary>
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("直线", 0, "基本图形", "Line")]
    public class DOPLineTool : GraphElementTool<DOPLine, GoStroke>
    {
        public DOPLineTool(GoView view)
            : base(view)
        {
        }
        /// <summary>
        /// 启动绘制
        /// </summary>
        public override void Start()
        {
            this.View.CursorName = "cross";
        }

        public override void DoMouseDown()
        {
            ReCalculate();
            if (this.Shape.PointsCount == 0)
            {
                this.Shape.AddPoint(this.FirstInput.DocPoint);
                this.View.Layers.Default.Add(element);
            }
            this.Shape.AddPoint(this.LastInput.DocPoint);
        }

        /// <summary>
        /// 更正计算点
        /// </summary>
        private void ReCalculate()
        {
            int numpts = this.Shape.PointsCount;
            if (numpts > 1)
                this.Shape.SetPoint(numpts - 1, this.LastInput.DocPoint);
        }

        public override void DoMouseMove()
        {
            ReCalculate();
        }

        public override void DoMouseUp()
        {
            if (this.LastInput.DoubleClick)
                FinishTool();
        }
    }
}
