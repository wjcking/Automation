using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;
using Northwoods.Go.Draw;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制多边
    /// </summary>
    [Serializable]
    public class DOPPolygon : DOPGraphElement
    {
        
        public DOPPolygon()
            : base()
        {
            this.Add(new GoPolygon());
        }

        /// <summary>
        /// 获取图对象
        /// </summary>
        private GoPolygon Shape
        {
            get
            {
                return this.First as GoPolygon;
            }
        }

        public PointF[] Points
        {
            get
            {
                IList<PointF> points = new List<PointF>();
                for(int i=0; i<Shape.PointsCount; i++)
                {
                    points.Add(Shape.GetPoint(i));
                }
                return points.ToArray<PointF>();
            }
        }

        //public override void Refresh()
        //{
        //    this.ActionScript.Where(v => v.ActionType == ActionType.ChangeColor).ToList()
        //       .ForEach(s =>
        //       {
        //           new DOPColorAnimation(this.Shape, s).CreateAnimation();
        //       });
        //    this.ActionScript.Where(v => v.ActionType == ActionType.Flash).ToList()
        //       .ForEach(s =>
        //       {
        //           new DOPFlashAnimation(this.Shape, s).CreateAnimation();
        //       });
        //    this.ActionScript.Where(v => v.ActionType == ActionType.Hide).ToList()
        //       .ForEach(s =>
        //       {
        //           new DOPHideAnimation(this.Shape, s).CreateAnimation();
        //       });
        //    this.ActionScript.Where(v => v.ActionType == ActionType.Move).ToList()
        //       .ForEach(s =>
        //       {
        //           new DOPMoveAnimation(this.Shape, s).CreateAnimation();
        //       });
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlGraphParam(this) { Name = "多边形属性" };
        }
    }
}
