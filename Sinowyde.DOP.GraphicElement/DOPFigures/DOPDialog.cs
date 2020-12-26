using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Sinowyde.DOP.GraphicElement.Base;
using Northwoods.Go.Instruments;
using Sinowyde.DOP.DataModel;

using Sinowyde.Util;
using Sinowyde.DOP.Graph.Xml;


namespace Sinowyde.DOP.GraphicElement
{

    /// <summary>
    /// 柱形
    /// </summary>
    [Serializable]
    public class DOPDialog : DOPGraphElement
    {

        public const string ERROR_NullVar = "请选择变量";

        private GoRectangle rectangle = new GoRectangle();
        public DOPDialog()
            : base()
        {
            rectangle.Width = 44;
            rectangle.Height = 44;
            rectangle.PenColor = Color.Blue;
            rectangle.BrushColor = Color.Transparent;
            Add(rectangle);

            //ActionScript = ConditionActionExtend.GetInstance(
            //    new ActionType[1] { ActionType.Dialog },
            //     new LinkType[1] { LinkType.DO }, 8);

            //ActionScript.Add(new ConditionAction()
            //{
            //    ActionType = ActionType.Dialog,
            //    LinkType = LinkType.DO,
            //    Colors = new List<Color>() { Color.Blue, Color.Green, Color.Red, Color.Black, Color.Yellow },
            //    Expression = new List<string>() { String.Empty, String.Empty, string.Empty, string.Empty, string.Empty, String.Empty, String.Empty, String.Empty },
            //    Condition = new List<string>() { String.Empty, String.Empty, string.Empty, string.Empty, string.Empty, String.Empty, String.Empty, String.Empty },
            //    RTValue = new List<RTValue>() { new RTValue()},
            //    Variable = new List<Variable>() {new Variable() }
            //}
            //);
            GraphRunTime.Instance().DocChangeEditEvent += DOPHotspot_DocChangeEditEvent;
        }

        //public override void Refresh()
        //{
        //    foreach (var action in ActionScript)
        //    {
        //        switch (action.LinkType)
        //        {
        //            case LinkType.DO:

        //                if (action.RTValue[0].Value == ConvertUtil.ConvertToDouble(ActionScript[0].Condition[0]))
        //                {
        //                    var doc = GraphDocManager.Instance().GetDocument(ActionScript[0].Condition[1]);
        //                    if (doc == null)
        //                        break;

        //                    frmViewDialog dlg = new frmViewDialog(doc);
        //                    int left = ConvertUtil.ConvertToInt(ActionScript[0].Condition[2]);
        //                    int top = ConvertUtil.ConvertToInt(ActionScript[0].Condition[3]);
        //                    dlg.Location = new Point(left, top);
        //                    dlg.Width = ConvertUtil.ConvertToInt(ActionScript[0].Condition[4]);
        //                    dlg.Height = ConvertUtil.ConvertToInt(ActionScript[0].Condition[5]);

        //                    dlg.Show();
        //                }
        //                continue;
        //        }

        //    }
        //}

        /// <summary>
        /// 设置边框
        /// </summary>
        /// <param name="isEdit"></param>
        void DOPHotspot_DocChangeEditEvent(object sender, GraphEditEventArgs arg)
        {
            rectangle.PenColor = arg.Status == GraphDocStatus.IsEdit ? Color.Blue : Color.Empty;
        }

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlDialogParam(this) { Name = "对话框属性" };
        }
    }
}
