using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDBlock.Xml;

namespace Sinowyde.DOP.Sama.Control.Frms
{
    public partial class FrmRecovery : XtraForm
    {
        private DataTable _dataTable = new DataTable();
        /// <summary>
        /// 恢复成功
        /// </summary>
        public bool FlagRecovery = false;

        public FrmRecovery()
        {
            InitializeComponent();
        }

        private void FrmRecovery_Load(object sender, EventArgs e)
        {
            InitUi();

            using (new WaitDialogForm("请等待", "加载数据中...", new Size(200, 50), ParentForm))
            {
                CreateDataTable();
                gridControl.DataSource = _dataTable;
                FillData();
                gridControl.RefreshDataSource();
            }
        }

        private void InitUi()
        {
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsCustomization.AllowColumnMoving = false; //列头禁止移动

            this.gridView.PopupMenuShowing += gridView_PopupMenuShowing;

        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    var rowHandle = e.HitInfo.RowHandle;
                    if (rowHandle < 0) return;
                    var dataRow = this.gridView.GetDataRow(rowHandle);
                    if (null == dataRow) return;
                    var fileName = dataRow["FileName"].ToString();

                    #region 右键菜单
                    e.Menu.Items.Add(new DXMenuItem("删除备份", (o1, e1) =>
                    {
                        if (XtraMessageBox.Show("确认要删除此备份？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            try
                            {
                                File.Delete(fileName);
                                _dataTable.Rows.Remove(dataRow);
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show("删除失败！");
                            }
                        }
                    }));

                    e.Menu.Items.Add(new DXMenuItem("恢复到此备份", (o1, e1) =>
                    {
                        if (XtraMessageBox.Show("确认要恢复到此备份？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            FlagRecovery = PIDDocManager.Instance().Recovery(fileName);
                        }
                    }));

                    e.Menu.Items.Add(new DXMenuItem("打开位置", (o1, e1) =>
                        {
                            var path = Path.GetDirectoryName(fileName);
                            if (Directory.Exists(path))
                                System.Diagnostics.Process.Start(path);
                            else
                                XtraMessageBox.Show("不存在此备份！");
                        }));
                    #endregion

                }
            }

        }

        private void CreateDataTable()
        {
            _dataTable.Clear();

            var dataColumnBackupTimestamp = new DataColumn("BackupTimestamp");
            dataColumnBackupTimestamp.DataType = typeof(DateTime);
            _dataTable.Columns.Add(dataColumnBackupTimestamp);

            var dataColumnPeople = new DataColumn("People");
            dataColumnPeople.DataType = typeof(string);
            _dataTable.Columns.Add(dataColumnPeople);

            var dataColumnDescription = new DataColumn("Description");
            dataColumnDescription.DataType = typeof(string);
            _dataTable.Columns.Add(dataColumnDescription);

            var dataColumnFileName = new DataColumn("FileName");
            dataColumnFileName.DataType = typeof(string);
            _dataTable.Columns.Add(dataColumnFileName);
        }

        private void FillData()
        {
            _dataTable.Rows.Clear();
            DataRow row = null;
            foreach (var item in PIDDocManager.Instance().GetBackupsInfo())
            {
                row = _dataTable.NewRow();
                row["BackupTimestamp"] = item.BackupTimestamp;
                row["People"] = item.People;
                row["Description"] = item.Description;
                row["FileName"] = item.FileName;
                _dataTable.Rows.Add(row);
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
