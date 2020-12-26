using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataLogic;
using Sinowyde.RTModel;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_VariableSelect : DevExpress.XtraEditors.XtraForm
    {
        public Form_VariableSelect()
        {
            InitializeComponent();

            this.gv_Variabel.RowClick += gv_Variabel_RowClick;
        }

        private void gv_Variabel_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var id = gv_Variabel.GetRowCellValue(e.RowHandle, "ID");


            //Form_Variable form = new Form_Variable(model, flag);
            //if (DialogResult.OK == form.ShowDialog())
            //{
            //    RefreshTree(treeList_Left.FocusedNode);
            //}

        }

        private void Form_VariableSelect_Load(object sender, EventArgs e)
        {
            //groupCols.Visible = false;
            List<string> dataTypes = new VarDataTypeHelper().GetShowTexts().ToList<string>();
            dataTypes.Insert(0, "不限");
            cmb_DataType.Properties.Items.AddRange(dataTypes);
            cmb_DataType.SelectedIndex = 0;

            List<string> directionTypes = new VarDirectionTypeHelper().GetShowTexts().ToList<string>();
            directionTypes.Insert(0, "不限");
            cmb_DirectionType.Properties.Items.AddRange(directionTypes);
            cmb_DirectionType.SelectedIndex = 0;

            cmb_IsTransfer.Properties.Items.AddRange(new string[] { "不限", "否", "是" });
            cmb_IsTransfer.SelectedIndex = 0;

            List<string> variableTypes = new VariableTypeHelper().GetShowTexts().ToList<string>();
            variableTypes.Insert(0, "不限");

            cmb_VariableType.Properties.Items.AddRange(variableTypes);
            cmb_VariableType.SelectedIndex = 0;

            List<IOUnit> iounits = DOPDataLogic.Instance().GetAllBy<IOUnit>();
            iounits.Insert(0, new IOUnit() { ID = 0, Name = "不限" });
            cmb_IOUnit.SetComboxDataSource<IOUnit>(iounits);
            cmb_IOUnit.SelectedIndex = 0;

            List<Device> devices = DOPDataLogic.Instance().GetAllBy<Device>();
            devices.Insert(0, new Device() { ID = 0, Name = "不限" });
            cmb_Device.SetComboxDataSource<Device>(devices);
            cmb_Device.SelectedIndex = 0;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string variableName = txt_Name.Text.Trim();
            string variableNumber = txt_Number.Text.Trim();
            bool? isTransfer = null;
            if (cmb_IsTransfer.Text == "是") { isTransfer = true; } else if (cmb_IsTransfer.Text == "否") { isTransfer = false; }
            long deviceId = cmb_Device.GetComboxData<Device>().ID;
            long unitId = cmb_IOUnit.GetComboxData<IOUnit>().ID;

            VariableType? variableType = null;
            if (!cmb_VariableType.Text.Equals("不限"))
            {
                variableType = new VariableTypeHelper().GetSelectValue(cmb_VariableType.Text);
            }

            DataType? dataType = null;
            if (!cmb_DataType.Text.Equals("不限"))
            { dataType = new VarDataTypeHelper().GetSelectValue(cmb_DataType.Text); }

            VarDirectionType? varDirectionType = null;
            if (!cmb_DirectionType.Text.Equals("不限"))
            {
                varDirectionType = new VarDirectionTypeHelper().GetSelectValue(cmb_DirectionType.Text);
            }


            List<Variable> list = DOPDataLogic.Instance().GetVariable(variableName, variableNumber, isTransfer, deviceId, variableType, dataType, varDirectionType, unitId);
            gc_Variable.DataSource = list;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            //var list = from c in gv_Variabel.Columns select new { Name = c.Name, Caption = c.Caption };
            //cb_ColList.DisplayMember = "Caption";
            //cb_ColList.ValueMember = "Name";
            //cb_ColList.DataSource = list.ToList();
            //groupCols.Location = new Point((this.Width - groupCols.Width) / 2, (this.Height - groupCols.Height) / 2);
            //groupCols.Visible = true;
            this.btn_Panel_Export_Click(null, null);
        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                groupCols.Visible = false;
            }
        }

        private void pictureEdit1_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btn_Panel_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel文档(*.xls)|*.xls|Excel文档(*.xlsx)|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gv_Variabel.ExportToXls(saveFile.FileName);
                groupCols.Visible = false;
                MessageBox.Show("导出完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gv_Variabel_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }
        }

        private void gv_Variabel_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount == 0)
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