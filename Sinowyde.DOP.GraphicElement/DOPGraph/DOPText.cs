using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 文本显示组件
    /// </summary>
    [Serializable]
    public class DOPText : DOPGraphElement
    {
        public DOPText()
            : base()
        {
            this.Add(new GoText() {
                Text = "文本",
                Alignment = 1  
                //Wrapping =true, 
                //WrappingWidth =5, 
                //Reshapable =true, 
                //Resizable =true, 
                //AutoRescales =true, 
                //AutoResizes=true
            });
        }
        /// <summary>
        /// 获取文字对象
        /// </summary>
        private GoText DefText
        {
            get
            {
                return this.First as GoText;
            }
        }

        //public override void Refresh()
        //{
        //    this.ActionScript.Where(v => v.ActionType == ActionType.Text).ToList()
        //       .ForEach(s =>
        //       {
        //           new DOPTextAnimation(this.DefText, s).CreateAnimation();
        //       });
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlTextParam(this) { Name = "文本属性" };
        }
    }
}
