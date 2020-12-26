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
    /// <summary>
    /// 绘制图像
    /// </summary>
    [Serializable]
    public class DOPImage : DOPGraphElement 
    {
        public DOPImage()
            : base()
        {
            this.Add(new GoImage() {  AutoResizes =false , Size=new SizeF(100,100)});
        }
        /// <summary>
        /// 获取图对象
        /// </summary>
        private GoImage Shape
        {
            get
            {
                return this.First as GoImage;
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
            return new UCtlImageParam(this) { Name = "图像属性" };
        }
    }
}
