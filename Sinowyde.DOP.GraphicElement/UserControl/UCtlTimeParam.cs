using System;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.Util;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlTimeParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        private Font selectedFont = null;
        public UCtlTimeParam()
        {
            InitializeComponent();
        }

        public UCtlTimeParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGraphElement = generalShape;
            LoadTimeInfo();
        }

        public void LoadParam()
        {
            //this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Text).ToList()
            //   .ForEach(s =>
            //   {
            //       cboTimeType.Text = string.Format(s.Condition[0], DateTime.Now);
            //   });
            //selectedFont = (this.dopGraphElement.First as GoText).Font;
        }

        public bool SaveParam()
        {
            var goText = this.dopGraphElement.First as GoText;
            if (null != selectedFont)
                goText.Font = selectedFont;
            goText.Text = string.Format((this.cboTimeType.SelectedItem as ComboxData).TimeFormat, DateTime.Now);
            //this.dopGraphElement.ActionScript.Clear();
            //var conditionAction = new ConditionAction()
            //{
            //    ActionType = ActionType.Text,
            //    LinkType = LinkType.Text,
            //    Condition = new List<string>() { (this.cboTimeType.SelectedItem as ComboxData).TimeFormat},
            //     IsExcutedAction =true 
            //};
            //this.dopGraphElement.ActionScript.Add(conditionAction);
            return true;
        }

        public System.Windows.Forms.UserControl GetParamCtrl()
        {
            return this;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                selectedFont = fontDlg.Font;
            }
        }

        private void LoadTimeInfo()
        {
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:T}", Text = "00:00:00" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:t}", Text = "00:00" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:d}", Text = "2000-1-1" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:D}", Text = "2000年-1月-1日" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:f}", Text = "2000年-1月-1日 0:0" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:F}", Text = "2000年-1月-1日 0:0:0" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:g}", Text = "2000-11-5 14:23" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:G}", Text = "2000-11-5 14:23:23" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:M}", Text = "1月1日" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:R}", Text = "Sat, 01 Nov 2000 0:0:0 GMT" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:s}", Text = "2000-1-01T00:00:00" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:u}", Text = "2000-1-01 00:00:00Z" });
            this.cboTimeType.Properties.Items.Add(new ComboxData() { TimeFormat = "{0:Y}", Text = "2000年1月" });
        }

        public class ComboxData
        {
            public string Text { set; get; }
            public string  TimeFormat { set; get; }
            public override string ToString()
            {
                return Text;
            }
        }

    }
}
