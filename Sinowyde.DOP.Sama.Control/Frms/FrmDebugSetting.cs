using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Xml;
using Sinowyde.DOP.PIDBlock.Xml.Entitys;
using Sinowyde.Util;

namespace Sinowyde.DOP.Sama.Control.Frms
{
    public partial class FrmDebugSetting : Form
    {
        private delegate void UpdateDataSourceDelegate(DataTable dataTable);
        private bool _isLoading = false;

        public FrmDebugSetting()
        {
            InitializeComponent();
        }

        private void FrmDebugSetting_Load(object sender, EventArgs e)
        {
            DefaultUi();
        }

        private void repositoryItemToggleSwitch_EditValueChanged(object sender, EventArgs e)
        {
            var identity = gridView.GetRowCellValue(gridView.FocusedRowHandle, "Identity").ToString();
            var msg = new PIDCommmandMsg();
            msg.Guid = identity;
            msg.TakeEffect = ConvertUtil.ConvertToBool(((ToggleSwitch)sender).EditValue);
            msg.CommandType = PIDCommandType.OfflineDebug;
            PIDGeneralBlock.CommandAction(msg.ToString(), -1);
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void DefaultUi()
        {
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            //this.gridView.OptionsView.ColumnAutoWidth = false;如何显示水平滚动条？或
            //this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            //this.gridView.OptionsBehavior.Editable = false;
            //this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.BestFitColumns();//.....列表宽度自适应内容

            this.gridView.CustomDrawEmptyForeground += gridView_CustomDrawEmptyForeground;

            Task.Run(() =>
                {
                    _isLoading = true;
                    UpdateDataSource(CreateDataTable());
                    _isLoading = false;
                });
            this.repositoryItemToggleSwitch.EditValueChanged += repositoryItemToggleSwitch_EditValueChanged;
        }

        private void gridView_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            var str = _isLoading ? "请等待加载...... " : "没有可用数据！";
            var font = new Font("宋体", 10, FontStyle.Bold);
            var sizeF = e.Graphics.MeasureString(str, font);
            var x = (int)((e.Bounds.Width - sizeF.Width) / 2);
            e.Graphics.DrawString(str, font, Brushes.Black, x, 40);
        }

        private void UpdateDataSource(DataTable dataTable)
        {
            if (gridControl.InvokeRequired)
                gridControl.Invoke(new UpdateDataSourceDelegate(UpdateDataSource), dataTable);
            else
                gridControl.DataSource = dataTable;
        }

        private DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Identity", typeof(string));
            dataTable.Columns.Add("GroupIndex", typeof(string));
            dataTable.Columns.Add("IndexInGroup", typeof(string));
            dataTable.Columns.Add("Number", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("IsOpenloop", typeof(string));
            DataRow row = null;
            foreach (var entity in PIDDocManager.Instance().GetDebugSettingList())
            {
                row = dataTable.NewRow();
                row["Identity"] = entity.Identity;
                row["GroupIndex"] = entity.GroupIndex;
                row["IndexInGroup"] = entity.IndexInGroup;
                row["Number"] = entity.Number;
                row["Name"] = entity.Name;
                row["IsOpenloop"] = entity.IsOpenloop;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

    }
}
