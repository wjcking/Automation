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
    /// 绘制多边形
    /// </summary>
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("多边形", 5, "基本图形", "Polygon")]
    public class DOPPolygonTool : GraphElementTool<DOPPolygon, GoPolygon>
    {
        public DOPPolygonTool(GoView view)
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
            if (!this.LastInput.DoubleClick)
            {
                ReCalculate();
                if (this.Shape.PointsCount == 0)
                {
                    this.Shape.Style = GoPolygonStyle.Line;
                    this.Shape.BrushColor = Color.White;
                    this.Shape.PenColor = Color.Black;
                    this.Shape.AddPoint(this.FirstInput.DocPoint);
                    this.View.Layers.Default.Add(element);
                }
                this.Shape.AddPoint(this.LastInput.DocPoint);
                this.Shape.AddPoint(this.LastInput.DocPoint);
                this.Shape.AddPoint(this.LastInput.DocPoint);
            }
        }
        /// <summary>
        /// 更正计算点
        /// </summary>
        private void ReCalculate()
        {
            int numpts = this.Shape.PointsCount;
            if (numpts >= 4)
            {
                PointF start = this.Shape.GetPoint(numpts - 4);
                PointF end = this.LastInput.DocPoint;
                this.Shape.SetPoint(numpts - 3, new PointF(2 * start.X / 3 + end.X / 3, 2 * start.Y / 3 + end.Y / 3));
                this.Shape.SetPoint(numpts - 2, new PointF(start.X / 3 + 2 * end.X / 3, start.Y / 3 + 2 * end.Y / 3));
                this.Shape.SetPoint(numpts - 1, end);
            }
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
