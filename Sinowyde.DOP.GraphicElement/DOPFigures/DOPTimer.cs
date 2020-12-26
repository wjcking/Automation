using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.DOP.DataModel;
using Sinowyde.Util;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 文本显示组件
    /// </summary>
    [Serializable]
    public class DOPTimer : DOPGraphElement
    {
        private GoText text = new GoText();
        public DOPTimer()
            : base()
        {
            text = new GoText() { Text = string.Format("{0:d}", DateTime.Now) };
            this.Add(text);
        }

        /// <summary>
        ///  获取时间对象
        /// </summary>
        private GoText Shape
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
        //           if(s.IsExcutedAction)
        //            this.Shape.Text = string.Format(s.Condition[0], DateTime.Now);
        //       });
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlTimeParam(this) { Name = "时间属性" };
        }
    }
}
