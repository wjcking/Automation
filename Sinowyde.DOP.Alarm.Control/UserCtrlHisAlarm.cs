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
using Sinowyde.DOP.DataLogic;
using System.Threading;
using DevExpress.Utils.Menu;

namespace Sinowyde.DOP.Alarm.Control
{
    public partial class UserCtrlHisAlarm : DevExpress.XtraEditors.XtraUserControl
    {
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

        public UserCtrlHisAlarm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            isLoading = true;

            loading.Visible = true;

            
            #region 整理查询条件

            gc_RTAlarm.DataSource = null;
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
            DateTime timestampBegin = dtxt_Timestamp_Begin.DateTime;
            DateTime timestampEnd = dtxt_Timestamp_End.DateTime.Equals(DateTime.MinValue) ? dtxt_Timestamp_End.DateTime : dtxt_Timestamp_End.DateTime.AddDays(1);

            DateTime confirmTimeBegin = dtxt_ConfirmTime_Begin.DateTime;
            DateTime confirmTimeEnd = dtxt_ConfirmTime_End.DateTime.Equals(DateTime.MinValue) ? dtxt_ConfirmTime_End.DateTime : dtxt_ConfirmTime_End.DateTime.AddDays(1);
            bool? isConfirm = null;
            if (cmb_IsConfirm.Text.Equals("是"))
            { isConfirm = true; }
            else if (cmb_IsConfirm.Text.Equals("否"))
            { isConfirm = false; }

            string _operator = txt_Operator.Text.Trim();

            #endregion

            Thread thread = new Thread(new ThreadStart(() =>
            {
                IList<RTAlarm> list = DOPDataLogic.Instance().GetRTAlarmBy(
                    varNumber, level, type, timestampBegin, timestampEnd, confirmTimeBegin, confirmTimeEnd, isConfirm, _operator);
                this.Invoke(new Action(() =>
                {
                    isLoading = false;
                    loading.Visible = false;
                    gc_RTAlarm.DataSource = list.ToList();
                }));
            }));
            thread.IsBackground = true;
            thread.Start();
        }
        private void UserCtrlHisAlarm_Load(object sender, EventArgs e)
        {
            cmb_IsConfirm.Properties.Items.AddRange(new string[] { "全部", "是", "否" });
            cmb_IsConfirm.SelectedIndex = 0;

            string[] listLevel = new AlarmLevelHelper().GetShowTexts();
            cmb_Level.Properties.Items.AddRange(listLevel);
            cmb_Level.Properties.Items.Insert(0, "全部");
            cmb_Level.SelectedIndex = 0;

            string[] listType = new AlarmTypeHelper().GetShowTexts();
            cmb_Type.Properties.Items.AddRange(listType);
            cmb_Type.Properties.Items.Insert(0, "全部");
            cmb_Type.SelectedIndex = 0;

            gv_RTAlarm.CustomDrawEmptyForeground += gv_CustomDrawEmptyForeground;

            this.Controls.Add(loading);
            loading.BringToFront();
            loading.Location = new Point((this.Width - loading.Width) / 2, (this.Height - loading.Height) / 2);
            this.SizeChanged += delegate(object formSender, EventArgs ea)
            {
                loading.Location = new Point((this.Width - loading.Width) / 2, (this.Height - loading.Height) / 2);
            };

            LoadData();

        }

        private void gv_RTAlarm_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name.Equals("column_isConfirm"))
            {
                e.DisplayText = e.Value == null ? "否" : "是";
            }
            else if (e.Column.Name.Equals("column_ConfirmTime"))
            {
                string txt = string.Empty;
                if (e.Value != null && (DateTime)e.Value != DateTime.MinValue)
                {
                    txt = e.Value.ToString();
                }
                e.DisplayText = txt;
            }
            else if (e.Column.Name.Equals("column_Operator"))
            {
                e.DisplayText = e.Value == null ? "" : e.Value.ToString();
            }
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

        private void gv_RTAlarm_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }

            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    e.Menu.Items.Add(new DXMenuItem("确认报警"));
                    e.Menu.Items[0].Click += delegate(object obj, EventArgs es)
                    {

                        int index = gv_RTAlarm.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                        RTAlarm model = ((List<RTAlarm>)gc_RTAlarm.DataSource)[index];
                        model.Operator = "zza";
                        model.ConfirmTime = DateTime.Now;
                        DOPDataLogic.Instance().Update(model);
                        gv_RTAlarm.UpdateCurrentRow();
                    };
                }
            }
        }
    }
}
