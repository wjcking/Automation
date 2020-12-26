using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Serializable]
    public class DOPDrawing : DOPGraphElement
    {
        public DOPDrawing()
            : base()
        {
            this.Add(new GoDrawing());
        }

        /// <summary>
        /// 获取图对象
        /// </summary>
        public GoDrawing Shape
        {
            get
            {
                return this.First as GoDrawing;
            }
            set
            {
                this[0] = value;
            }
        }

        //public override void Refresh()
        //{
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
            return new UCtlGraphParam(this) { Name = "图像属性" };
        }
    }
}
