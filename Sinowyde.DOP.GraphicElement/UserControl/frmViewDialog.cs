using Northwoods.Go;
using Northwoods.Go.Draw;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.Graph.Xml;
using Sinowyde.DOP.GraphicElement.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class frmViewDialog : DevExpress.XtraEditors.XtraForm
    {
        private GoView view;
        public frmViewDialog()
        {

            InitializeComponent();
        }

        public frmViewDialog(GraphDocument doc)
        {
            InitializeComponent();
            view = new GoView();
            this.view.Document = doc;
            this.view.Dock = DockStyle.Fill;
            Text = doc.Name;
            panelCtlDOColor.Controls.Add(this.view);
            GraphRunTime.Instance().DocChangeEditEvent += frmViewDialog_DocChangeEditEvent;
            GraphRunTime.Instance().GraphStatus = GraphDocStatus.IsDebug;
        }

        void frmViewDialog_DocChangeEditEvent(object sender, GraphEditEventArgs arg)
        {
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            foreach (GoObject obj in this.view.Document.DefaultLayer)
            {
                var dopGraphElement = obj as DOPGraphElement;
                //foreach (var action in dopGraphElement.ActionScript)
                //{
                //    IList<string> resultList = action.GetAllVariable();
                //    if (resultList != null && resultList.Count > 0)
                //    {
                //        if (dopGraphElement.GetType() == typeof(DOPTimer))
                //        {
                //            dopGraphElement.Refresh();
                //            continue;
                //        }
                //        IList<RTValue> realResultValue = RTValueMemCache.Instance().GetValues(resultList);
                //        if (realResultValue.Count < 1)
                //            continue;
                //        action.RTValue = realResultValue;
                //        dopGraphElement.Refresh();
                //    }
                //}
            }
        }

        private void frmViewDialog_Load(object sender, System.EventArgs e)
        {
            this.timer1.Interval = 1000;
            //RTValueMemCache.Instance().StartMemCache("tcp://127.0.0.1:9003", new List<string> { IOTopic.IORead, IOTopic.IOWrite, IOTopic.IOCalc, IOTopic.IOTemp });
            //RTValueMemCache.Instance().StartMemCache();
            timer1.Start();
        }

        private void frmViewDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            //RTValueMemCache.Instance().StopMemCache();
        }
    }
}