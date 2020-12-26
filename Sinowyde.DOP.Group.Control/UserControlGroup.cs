using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using System.Reflection;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;

namespace Sinowyde.DOP.Group.Control
{
    public partial class UserControlGroup : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlGroup()
        {
            InitializeComponent();
        }

        private Document CreateDocument(string ControlName, string ControlTypeName)
        {
            DevExpress.XtraBars.Docking2010.Views.Widget.Document doc = new DevExpress.XtraBars.Docking2010.Views.Widget.Document();
            doc.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            doc.Properties.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
            doc.Properties.AllowMaximize = DevExpress.Utils.DefaultBoolean.False;
            doc.ControlName = ControlName;
            doc.ControlTypeName = ControlTypeName;
            return doc;
        }

        private void UserControlGroup_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                StackGroup group = new StackGroup();
                widgetView.StackGroups.Add(group);
            }

            Document docRtGrid = CreateDocument("UserCtrlRtWigetList", "Sinowyde.DOP.Group.Control");
            docRtGrid.Width = this.Width / 2 - 2;
            docRtGrid.Height = this.Height / 2 - 2;
            CustomHeaderButton btn = new CustomHeaderButton("配置", ButtonStyle.PushButton);
            docRtGrid.CustomButtonClick += delegate(object obj,ButtonEventArgs es)
            {
                Sinowyde.DOP.Group.Control.UserCtrlRtWigetList list = (obj as DevExpress.XtraBars.Docking2010.Views.Widget.Document).Tag as Sinowyde.DOP.Group.Control.UserCtrlRtWigetList;
                if (list != null)
                {
                    list.ShowConfig();
                }
            };
            docRtGrid.CustomHeaderButtons.Add(btn);
            widgetView.Documents.Add(docRtGrid);

            Document docRTEvent = CreateDocument("UserCtrlRTEvent", "Sinowyde.DOP.Alarm.Control");
            docRTEvent.Width = this.Width / 2 - 2;
            docRTEvent.Height = this.Height / 2 - 2;
            widgetView.Documents.Add(docRTEvent);


            Document docTrend = CreateDocument("UserCtrlRtTrend", "Sinowyde.DOP.Trend.Control");
            docTrend.Width = this.Width - 2;
            docTrend.Height = this.Height / 2;
            widgetView.Documents.Add(docTrend);

            widgetView.StackGroups[0].Items.AddRange(new Document[] { widgetView.Documents[0] as Document, widgetView.Documents[1] as Document });
            widgetView.StackGroups[1].Items.Add(widgetView.Documents[2] as Document);
        }

        private void widgetView_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.XtraUserControl userCtrl = null;
                if (e.Document.Tag is DevExpress.XtraEditors.XtraUserControl)
                {
                    userCtrl = e.Document.Tag as DevExpress.XtraEditors.XtraUserControl;
                }
                else
                {
                    string dllPath = string.Format("{0}", Application.StartupPath);
                    Assembly assembly = Assembly.LoadFrom(string.Format("{0}\\{1}.dll", dllPath, e.Document.ControlTypeName));
                    object obj = assembly.CreateInstance(string.Format("{0}.{1}", e.Document.ControlTypeName, e.Document.ControlName));
                    userCtrl = (obj as DevExpress.XtraEditors.XtraUserControl);
                }
                e.Document.Tag = userCtrl;
                e.Control = userCtrl;

            }
            catch (Exception ex)
            {

            }
        }
    }
}
