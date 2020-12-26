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
using Sinowyde.DOP.DataModel;
using System.Threading;
using Sinowyde.DOP.DataLogic;

namespace Sinowyde.DOP.Alarm.Control
{
    public partial class UserCtrlHisEvent : DevExpress.XtraEditors.XtraUserControl
    {
        public UserCtrlHisEvent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// combox默认显示的文字
        /// </summary>
        private const string ComBoxAllText = "全部";
        private bool isLoading = false;

        private DevExpress.XtraWaitForm.ProgressPanel loading = new DevExpress.XtraWaitForm.ProgressPanel()
        {
            ShowCaption = false,
            Description = "正在查询...",
            Visible = false,
            Size = new System.Drawing.Size(120, 50),
            Name = "sinowydeloading"
        };

        private void LoadData()
        {
            isLoading = true;

            loading.Visible = true;

            #region 整理查询条件

            gc_RTEvent.DataSource = null;
            string varNumber = txt_Number.Text.Trim();
            AlarmLevel? level = null;
            if (!cmb_Level.Text.Equals(ComBoxAllText))
            {
                level = new AlarmLevelHelper().GetSelectValue(cmb_Level.Text);
            }
            AlarmType? type = null;
            if (!cmb_Type.Text.Equals(ComBoxAllText))
            {
                type = new AlarmTypeHelper().GetSelectValue(cmb_Type.Text);
            }
            DateTime timestampBegin = dtxt_Timestamp_Begin.DateTime.Equals(DateTime.MinValue) ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : dtxt_Timestamp_Begin.DateTime;
            DateTime timestampEnd = dtxt_Timestamp_End.DateTime.Equals(DateTime.MinValue) ? Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString()) : dtxt_Timestamp_End.DateTime.AddDays(1);
            string eventType = txt_EventType.Text.Trim();
            #endregion

            Thread thread = new Thread(new ThreadStart(() =>
            {
                IList<RTEvent> list = DOPDataLogic.Instance().GetRtEventBy(
                    varNumber, level, type, timestampBegin, timestampEnd, eventType);
                this.Invoke(new Action(() =>
                {
                    isLoading = false;
                    loading.Visible = false;
                    gc_RTEvent.DataSource = list.ToList();
                }));
            }));
            thread.IsBackground = true;
            thread.Start();
        }

        private void UserCtrlHisEvent_Load(object sender, EventArgs e)
        {
            string[] listLevel = new AlarmLevelHelper().GetShowTexts();
            cmb_Level.Properties.Items.AddRange(listLevel);
            cmb_Level.Properties.Items.Insert(0, "全部");
            cmb_Level.SelectedIndex = 0;

            string[] listType = new AlarmTypeHelper().GetShowTexts();
            cmb_Type.Properties.Items.AddRange(listType);
            cmb_Type.Properties.Items.Insert(0, "全部");
            cmb_Type.SelectedIndex = 0;
            gv_RTEvent.CustomDrawEmptyForeground += gv_CustomDrawEmptyForeground;

            this.Controls.Add(loading);
            loading.BringToFront();
            loading.Location = new Point((this.Width - loading.Width) / 2, (this.Height - loading.Height) / 2);
            this.SizeChanged += delegate(object formSender, EventArgs ea)
            {
                loading.Location = new Point((this.Width - loading.Width) / 2, (this.Height - loading.Height) / 2);
            };

            LoadData();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gv_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount == 0 && isLoading == false)
            {
                string str = "暂无数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                SizeF sizeF = e.Graphics.MeasureString(str, f);
                int x = (int)((e.Bounds.Width - sizeF.Width) / 2);
                Rectangle r = new Rectangle(e.Bounds.Top + 5, e.Bounds.Left + 5, e.Bounds.Right - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, x, 40);
            }
        }
    }
}
