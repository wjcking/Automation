using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class FrmGotoUsages : XtraForm
    {
        public string StrLocateInfo = string.Empty;
        private IList<string> list = null;

        public FrmGotoUsages(IList<string> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void FrmGotoUsages_Load(object sender, EventArgs e)
        {
            DefaultUi();
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
            if (null != list)
            {
                DataRow row = null;
                foreach (var item in list)
                {
                    row = dataTable.NewRow();
                    var strSplit = item.Split('-');
                    row["GroupIndex"] = strSplit[0];
                    row["IndexInGroup"] = strSplit[1];
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }

        private void Apply()
        {
            var handle = this.gridView.FocusedRowHandle;
            var groupIndex = gridView.GetRowCellValue(handle, "GroupIndex");
            var indexInGroup = gridView.GetRowCellValue(handle, "IndexInGroup");
            StrLocateInfo = string.Format("{0}-{1}", groupIndex, indexInGroup);
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
