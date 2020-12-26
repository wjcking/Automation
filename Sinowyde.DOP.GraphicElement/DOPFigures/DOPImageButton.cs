using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.DOP.Graph.Xml;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.DOP.GraphicElement.Properties;
using Sinowyde.Util;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制图形按钮
    /// </summary>
    [Serializable]
    public class DOPImageButton : DOPGraphElement
    {
        public DOPImageButton()
            : base()
        {
            var goButton = new GoButton();
            goButton.Label = null;
            goButton.TopLeftMargin = new SizeF(0, 0);
            goButton.BottomRightMargin = new SizeF(0, 0);
            goButton.ActionEnabled = false;
            goButton.Editable = true;
            goButton.Movable = true;
            goButton.Resizable = true;
            goButton.ResizesRealtime = true;
            goButton.Reshapable = true;
            goButton.Selectable = true;
            GoImage buttonImage = new GoImage();
            buttonImage.Name = Path.Combine(Application.StartupPath, "ImageLibrary","button.jpg");
            goButton.Icon = buttonImage;
            this.Add(goButton);
            goButton.Size = new SizeF(100f, 100f);
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
            //       switch (s.Expression[0])
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
            //               frmViewDialog dlg = new frmViewDialog(doc);
            //               int left = ConvertUtil.ConvertToInt(s.Condition[1]);
            //               int top = ConvertUtil.ConvertToInt(s.Condition[2]);
            //               dlg.Location = new Point(left, top);
            //               dlg.Show();
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
            
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlImageButtonParam(this) { Name = "图形按钮属性" };
        }
    }
}
