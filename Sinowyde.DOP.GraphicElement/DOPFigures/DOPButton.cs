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
using Sinowyde.Util;
using Sinowyde.DOP.Graph.Xml;


namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制按钮
    /// </summary>
    [Serializable]
    public class DOPButton : DOPGraphElement
    {
        public DOPButton()
            : base()
        {
            var goButton = new GoButton();
            goButton.ActionEnabled = false;
            goButton.Resizable = false;
            goButton.Selectable = true;
            goButton.Reshapable = true;
            
            goButton.Label = new GoText();
            goButton.Label.FamilyName = "宋体";
            goButton.Label.FontSize = 12f;
            goButton.Label.Text = "button";
            goButton.ResizesRealtime = true;
            this.Add(goButton);
            goButton.Size = new SizeF(76f, 26f);
           
        }

        /// <summary>
        /// 获取按钮对象
        /// </summary>
        private GoButton Shape
        {
            get
            {
                return this.First as GoButton;
            }
        }

        public override bool OnSingleClick(GoInputEventArgs evt, GoView view)
        {
            if (view.Name.Equals("DrawView"))
                return base.OnSingleClick(evt, view);
            //this.ActionScript.Where(v => v.ActionType == ActionType.Button).ToList()
            //   .ForEach(s =>
            //   {
            //       switch (s.Expression[q])
            //       {
            //           case "0":  
            //               var docs = GraphDocManager.Instance().GetOpenedDoc(s.Condition[0]);
            //               if (null == docs)
            //                   break;
            //               view.Document = docs;
            //               Color tempColor = view.Document.PaperColor;
            //               view.Document.PaperColor = Color.White;
            //               view.Document.PaperColor = tempColor;
            //               break;
            //           case "1":
            //               var doc = GraphDocManager.Instance().GetDocument(s.Condition[0]);
            //               if (null == doc)
            //                   break;
            //               frmViewDialog frm = new frmViewDialog(doc);
            //               frm.Left =  ConvertUtil.ConvertToInt(s.Condition[2]);
            //               frm.Top = ConvertUtil.ConvertToInt(s.Condition[1]);
                           
            //               frm.Width =  ConvertUtil.ConvertToInt(s.Condition[3]);
            //               frm.Height = ConvertUtil.ConvertToInt(s.Condition[4]);
            //               frm.ShowDialog();
            //               break;
            //           case "2":
            //               if (System.IO.File.Exists(s.Condition[0]))
            //                   System.Diagnostics.Process.Start(s.Condition[0]);
            //               break;
            //       }
            //   });
            return base.OnSingleClick(evt, view);
        }

        //public override void Refresh()
        //{
        //    this.ActionScript.Where(v => v.ActionType == ActionType.ChangeColor).ToList()
        //       .ForEach(s =>
        //       {
        //           if (s.IsExcutedAction)
        //           {
        //               new DOPColorAnimation(this.Shape, s, ColorType.BackgroundColor).CreateAnimation();
        //           }
        //       });
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlButtonParam(this) { Name = "标准按钮属性" };
        }
    }
}
