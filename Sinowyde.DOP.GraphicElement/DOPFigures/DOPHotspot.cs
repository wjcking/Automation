using System;
using System.Collections.Generic;
using System.Drawing;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.GraphicElement.Base;
using Northwoods.Go;
using System.Windows.Forms;
using Sinowyde.Util;
using Sinowyde.DOP.Graph.Xml;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制按钮
    /// </summary>
    [Serializable]
    public class DOPHotspot : DOPGraphElement
    {
        private GoRectangle rectangle = new GoRectangle();
        public DOPHotspot()
            : base()
        {
            rectangle.Width = 44;
            rectangle.Height = 44;
            rectangle.PenColor = Color.Red;
            rectangle.BrushColor = Color.Transparent;

            Add(rectangle);

            //ActionScript = ConditionActionExtend.GetInstance(
            //    new ActionType[2] { ActionType.Meter, ActionType.ChangeColor },
            //     new LinkType[2] { LinkType.AO, LinkType.AO }, 7);


            //ActionScript.Add(new ConditionAction()
            //{
            //    IsExcutedAction = false,
            //    ActionType = ActionType.Meter,
            //    LinkType = LinkType.AO,
            //    Colors = new List<Color>() { Color.Blue, Color.Green, Color.Red, Color.Black, Color.Yellow },
            //    Expression = new List<string>() { String.Empty, String.Empty, string.Empty, string.Empty, string.Empty, String.Empty, String.Empty },
            //    Condition = new List<string>() { String.Empty, String.Empty, string.Empty, string.Empty, string.Empty, String.Empty, String.Empty },
            //    RTValue = new List<RTValue>() { new RTValue() },
            //    Variable = new List<Variable>() { new Variable() }
            //}
            //);

            //ActionScript.Add(new ConditionAction()
            //    {
            //        ActionType = ActionType.ChangeColor,
            //        LinkType = LinkType.AO,
            //        Colors = new List<Color>() { Color.Blue, Color.Green, Color.Red, Color.Black, Color.Yellow },
            //        Expression = new List<string>() { String.Empty, String.Empty, string.Empty, string.Empty, string.Empty, String.Empty, String.Empty },
            //        Condition = new List<string>() { String.Empty, String.Empty, string.Empty, string.Empty, string.Empty, String.Empty, String.Empty },
            //        RTValue = new List<RTValue>() { new RTValue() },
            //        Variable = new List<Variable>() { new Variable() }
            //    }
            //);
            GraphRunTime.Instance().DocChangeEditEvent += DOPHotspot_DocChangeEditEvent;
        }
        private GraphDocStatus status;
        /// <summary>
        /// 设置边框
        /// </summary>
        /// <param name="isEdit"></param>
        void DOPHotspot_DocChangeEditEvent(object sender, GraphEditEventArgs arg)
        {
            status = arg.Status;
            rectangle.PenColor = arg.Status == GraphDocStatus.IsEdit
                ? Color.Red : Color.Empty;
        }

        //public override void Refresh()
        //{
        //}

        public override bool OnContextClick(GoInputEventArgs evt, GoView view)
        {
            OnSingleClick(evt, view);
            return base.OnContextClick(evt, view);
        }

        /// <summary>
        /// 在运行时刻主界面调用此方法执行热区功能
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public override bool OnSingleClick(GoInputEventArgs evt, GoView view)
        {
            if (status == GraphDocStatus.IsEdit)
                return false;

            //if (string.IsNullOrEmpty(ActionScript[0].Condition[1]))
            //    return false;

            //int index = ConvertUtil.ConvertToInt(ActionScript[0].Condition[0]);

            //switch (index)
            //{
            //    case 0:
            //        var docs = GraphDocManager.Instance().GetOpenedDoc(ActionScript[0].Condition[1]);
            //        if (null == docs)
            //            break;
            //        view.Document = docs;
            //        Color tempColor = view.Document.PaperColor;
            //        view.Document.PaperColor = Color.White;
            //        view.Document.PaperColor = tempColor;
            //        break;
            //    case 1:
            //        var doc = GraphDocManager.Instance().GetDocument(ActionScript[0].Condition[1]);
            //        if (null == doc)
            //            break;
            //        frmViewDialog dlg = new frmViewDialog(doc);
            //        int left = ConvertUtil.ConvertToInt(ActionScript[0].Condition[2]);
            //        int top = ConvertUtil.ConvertToInt(ActionScript[0].Condition[3]);
            //        dlg.Location = new Point(left, top);
            //        int width = ConvertUtil.ConvertToInt(ActionScript[0].Condition[4]);
            //        int height = ConvertUtil.ConvertToInt(ActionScript[0].Condition[5]);
            //        dlg.Size = new Size(width, height);
            //        dlg.TopMost = true;
            //        dlg.ShowDialog();
            //        break;
            //    case 2:
            //        if (System.IO.File.Exists(ActionScript[0].Condition[1]))
            //            System.Diagnostics.Process.Start(ActionScript[0].Condition[1]);
            //        break;
            //}
            return base.OnSingleClick(evt, view);
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlHotspotParam(this) { Name = "热点属性" };
        }
    }
}
