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
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.Utils.Menu;
using System.Threading;
using Sinowyde.DOP.DataModel;
using System.Xml.Linq;


namespace Sinowyde.DOP.Group.Control
{
    public partial class UserCtrlRtWigetList : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 第一次加载需要 默认已保存的点
        /// </summary>
        private bool IsFirst = true;
        /// <summary>
        /// 最大Wiget个数
        /// </summary>
        private int MaxWigetCount = 10;

        private List<string> VariableNumbers = new List<string>();
        private XElement RootXmlConfig;
        private void AddVariables(string variableNumber)
        {
            VariableNumbers.Add(variableNumber);

            Document doc = CreateDocument(variableNumber, string.Empty);
            doc.Width = 120;
            doc.Height = 70;

            widgetView.Documents.Add(doc);
        }
        public void RemoveVariables(string variableNumber)
        {
            VariableNumbers.Remove(variableNumber);

            for (int i = 0; i < widgetView.Documents.Count; i++)
            {
                if (widgetView.Documents[i].ControlName == variableNumber)
                {
                    widgetView.Documents.Remove(widgetView.Documents[i]);
                }
            }
        }
        private bool IsDefaultCheck(string variableNumber)
        {
            if (!IsFirst)
                return false;
            return VariableNumbers.Where(o => o.Equals(variableNumber)).Count() > 0;
        }
        private System.Threading.Timer WorkTimer = null;

        public void ShowConfig()
        {
            if (!groupControl.Visible)
            {
                groupControl.Location = new Point((this.Width - groupControl.Width) / 2, (this.Height - groupControl.Height) / 2);
                groupControl.BringToFront();
                groupControl.Visible = true;
            }
        }

        private void LoadDataFromDB()
        {
            new Thread(new ThreadStart(() =>
            {
                List<Variable> list = DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<Variable>();

                var varEx = from c in list select new VariableEx() { Number = c.Number, IsCheck = IsDefaultCheck(c.Number) };
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        gridControl.DataSource = varEx;
                        gridView.RefreshData();
                        IsFirst = false;
                    }));
                }
            })).Start();
        }

        public void HideConfig()
        {
            groupControl.Visible = false;
        }

        private Document CreateDocument(string ControlName, string ControlTypeName)
        {
            DevExpress.XtraBars.Docking2010.Views.Widget.Document doc = new DevExpress.XtraBars.Docking2010.Views.Widget.Document();
            doc.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            doc.Properties.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
            doc.Properties.AllowMaximize = DevExpress.Utils.DefaultBoolean.False;
            doc.ControlName = ControlName;
            doc.ControlTypeName = ControlTypeName;
            doc.Caption = ControlName;
            return doc;
        }

        public UserCtrlRtWigetList()
        {
            InitializeComponent();
            LoadDataFromDB();
        }

        private void widgetView_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            UserCtrlRtWiget uc = new UserCtrlRtWiget();
            (e.Document as Document).AppearanceCaption.BackColor = Color.Transparent;
            (e.Document as Document).AppearanceCaption.BackColor2 = Color.Transparent;
            uc.VariableName = e.Document.ControlName;
            uc.VariableValue = 0;
            e.Control = uc;
        }

        private void groupControl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            HideConfig();
        }

        private void UserCtrlRtWigetList_Load(object sender, EventArgs e)
        {
            RootXmlConfig = XElement.Load(Application.StartupPath + "\\Config.xml");
            XElement variableXmlConfig = RootXmlConfig.Element("Variables");
            if (variableXmlConfig != null)
            {
                foreach (XElement item in variableXmlConfig.Elements())
                {
                    AddVariables(item.Value);
                }
                XElement maxWiget = RootXmlConfig.Element("GroupControl");
                if (maxWiget != null)
                {
                    XElement child = maxWiget.Elements().First();
                    int count = Sinowyde.Util.ConvertUtil.ConvertToInt(child.Value);
                    MaxWigetCount = count.Equals(0) ? 10 : count;
                }
            }
            WorkTimer = new System.Threading.Timer(new TimerCallback((object obj) =>
            {
                //估计会有问题 ztz
                var variableNames = from c in this.widgetView.Documents select c.ControlName;
                if (variableNames.Count() > 0)
                {
                    IList<RTValue> realValue = DOP.DTProxy.RTValueMemCache.Instance().GetValues(variableNames.ToArray());

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            for (int i = 0; i < this.widgetView.Documents.Count; i++)
                            {
                                Document doc = this.widgetView.Documents[i] as Document;
                                var realV = realValue.Where(o => o.VarNumber.Equals(doc.ControlName));
                                if (realV.Count() > 0)
                                {
                                    UserCtrlRtWiget rtwiget = doc.Control as UserCtrlRtWiget;
                                    rtwiget.VariableValue = realV.First().Value;
                                }
                            }
                        }));
                    }
                    else
                    {
                        WorkTimer.Dispose();
                    }
                }
            }), null, 0, 1000);

        }

        private void AddXmlVariable(string value)
        {
            XElement element = RootXmlConfig.Element("Variables");
            XElement childElement = new XElement("Variable");
            childElement.Value = value;
            element.Add(childElement);
            RootXmlConfig.Save(Application.StartupPath + "\\Config.xml");
        }
        private void RemoveXmlVariable(string value) 
        {
            XElement element = RootXmlConfig.Element("Variables");
            if (element.Element("Variables") != null)
            {
                foreach (XElement item in element.Element("Variables").Elements())
                {
                    if (item.Value == value)
                    {
                        item.Remove();
                        break;
                    }
                }
                RootXmlConfig.Save(Application.StartupPath + "\\Config.xml");
            }
        }

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (VariableNumbers.Count() > MaxWigetCount - 1 && (bool)e.Value == true)
            //{
            //    return;
            //}
            Console.WriteLine("cellvalueChanging");
            if (!e.Column.Name.Equals("column_Check"))
                return;
            VariableEx model = gridView.GetRow(e.RowHandle) as VariableEx;
            string variableNumber = model.Number;
            if ((bool)e.Value)
            {
                AddVariables(variableNumber);
                AddXmlVariable(variableNumber);
                
            }
            else
            {
                RemoveVariables(variableNumber);
                RemoveXmlVariable(variableNumber);
            }
            Console.WriteLine("cellvalueChanging-added");
        }


        private void gridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            //未找到原因 

            if (VariableNumbers.Count() > MaxWigetCount - 1 && (bool)gridView.GetFocusedValue() == false)
            {
                XtraMessageBox.Show(string.Format("超过最大数量{0}",MaxWigetCount), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else { e.Cancel = false; }
            //Console.WriteLine("showingEditor");

        }

        private void gridView_ShownEditor(object sender, EventArgs e)
        {

        }

    }

    public class VariableEx : Variable
    {
        public bool IsCheck { get; set; }
    }
}
