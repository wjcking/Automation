using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制椭圆
    /// </summary>
    [Serializable]
    public class DOPEllipse : DOPGraphElement
    {
        public DOPEllipse()
            : base()
        {
            this.Add(new GoEllipse());
        }
       
        /// <summary>
        /// 获取图对象
        /// </summary>
        private GoEllipse Shape
        {
            get
            {
                return this.First as GoEllipse;
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
            return new UCtlGraphParam(this) { Name = "圆形属性" };
        }
    }
}
