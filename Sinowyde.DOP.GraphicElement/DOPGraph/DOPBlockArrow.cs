using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Serializable]
    public class DOPBlockArrow : DOPGraphElement
    {
        public DOPBlockArrow()
            : base()
        {
            var blockArrow = new DOPBlockArrowFactory() 
            {
                Selectable = true,
                Resizable = true,
                Reshapable = true, 
                ResizesRealtime =true, 
                Movable =true 
            };
            this.Add(blockArrow);
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
                for (int i = 0; i < Shape.PointsCount; i++)
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
            return new UCtlGraphParam(this) { Name = "箭头属性" };
        }
    }
}
