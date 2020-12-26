using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.Sama.Control.UserControls
{
    public partial class UserControlErr : DevExpress.XtraEditors.XtraUserControl
    {
        public Action<string, string> LocateAction;

        public UserControlErr()
        {
            InitializeComponent();
        }


        private void UserControlErr_Load(object sender, EventArgs e)
        {
            DefaultUi();
            this.gridView.FocusedRowChanged += gridView_FocusedRowChanged;
            this.gridView.RowClick += gridView_RowClick;
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var groupIndex = gridView.GetRowCellValue(e.RowHandle, "GroupIndex");
            var indexInGroup = gridView.GetRowCellValue(e.RowHandle, "IndexInGroup");
            if (null != LocateAction)
                LocateAction(groupIndex.ToString(), indexInGroup.ToString());
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var groupIndex = gridView.GetRowCellValue(e.FocusedRowHandle, "GroupIndex");
            var indexInGroup = gridView.GetRowCellValue(e.FocusedRowHandle, "IndexInGroup");
            if (null != LocateAction)
                LocateAction(groupIndex.ToString(), indexInGroup.ToString());
        }


        private void DefaultUi()
        {
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            //this.gridView.OptionsView.ColumnAutoWidth = false;如何显示水平滚动条？或
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.BestFitColumns();//.....列表宽度自适应内容

            this.gridControl.DataSource = CreateDataTable();
        }

        private DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("GroupIndex", typeof(string));
            dataTable.Columns.Add("IndexInGroup", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("AlgName", typeof(string));
            DataRow row = null;
            foreach (var error in PIDCompileErrManager.Instance().Errors)
            {
                row = dataTable.NewRow();
                row["GroupIndex"] = error.GroupIndex;
                row["IndexInGroup"] = error.IndexInGroup;
                row["Description"] = error.Description;
                row["AlgName"] = error.AlgName;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
