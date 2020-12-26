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
using DevExpress.Utils.Menu;

namespace Sinowyde.DOP.DataModel.Control.Frms
{
    public partial class From_TempVariable : DevExpress.XtraEditors.XtraForm
    {
        private long ID = 0;

        public From_TempVariable()
        {
            InitializeComponent();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Variable model = new Variable();
           
            model.Number = txt_Number.TextTrim();
            model.Name = txt_Name.TextTrim();
            model.Unit = txt_Unit.TextTrim();
            model.Device = cmb_device.GetComboxData<Device>();
            model.IsTransfer = cmb_IsTransfer.Text.Equals("是") ? true : false;
            model.IsCompressed = cmb_IsCompressed.Text.Equals("是") ? true : false;
            model.CompressRatio = Sinowyde.Util.ConvertUtil.ConvertToFloat(txt_CompressRatio.Value);
            model.DataType = new VarDataTypeHelper().GetSelectValue(cmb_DataType.Text);
            model.VariableType = new VariableTypeHelper().GetSelectValue(cmb_VariableType.Text);
            model.DirectionType = VarDirectionType.Temp;
            model.MaxPeriod = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_MaxPeriod.Value);
            if (ID > 0)
            {
                model.ID = ID;
                DOP.DataLogic.DOPDataLogic.Instance().Update(model);
            }
            else 
            {
                DOP.DataLogic.DOPDataLogic.Instance().Insert(model);
            }
           
            Clear();
            loadData();
        }

        private void Form_CalcVariabel_Load(object sender, EventArgs e)
        {
            loadData();

            List<Device> list= DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<Device>();

            cmb_device.SetComboxDataSource<Device>(list);
            cmb_device.SelectedIndex = 0;

            #region 变量类型
            cmb_VariableType.Properties.Items.AddRange(new VariableTypeHelper().GetShowTexts().ToArray<string>());
            cmb_VariableType.SelectedIndex = 0;
            #endregion

            #region 数据类型
            cmb_DataType.Properties.Items.AddRange(new VarDataTypeHelper().GetShowTexts().ToArray<string>());
            cmb_DataType.SelectedIndex = 0;
            #endregion

        }

        private void loadData()
        {
            List<Variable> list = DOP.DataLogic.DOPDataLogic.Instance().GetCalcVariabel();
            gc_CalcVariable.DataSource = list;
        }

        private void Clear() 
        {
            txt_Number.Empty();
            txt_Name.Empty();
            txt_Unit.Empty();
            cmb_device.SelectedIndex = 0;
            cmb_IsTransfer.SelectedIndex = 0;
            cmb_IsCompressed.SelectedIndex = 0;
            txt_CompressRatio.Value = 0;
            cmb_DataType.SelectedIndex = 0;
            cmb_VariableType.SelectedIndex = 0;
            txt_MaxPeriod.Value = 0;
            ID = 0;
            btn_Save.Text = "新增";
        }

        private void SetVariable(Variable model)
        {
            txt_Number.Text = model.Number;
            txt_Name.Text = model.Name;
            txt_Unit.Text = model.Unit;
            cmb_device.SetComboxIndex<Device>(model.Device);
            cmb_IsTransfer.Text = model.IsTransfer ? "是" : "否";
            cmb_IsCompressed.Text = model.IsTransfer ? "是" : "否";
            txt_CompressRatio.Value = Sinowyde.Util.ConvertUtil.ConvertToDecimal(model.CompressRatio);
            cmb_DataType.SelectedIndex = new VarDataTypeHelper().GetIndexByValue(model.DataType);
            cmb_VariableType.SelectedIndex = new VariableTypeHelper().GetIndexByValue(model.VariableType);
            txt_MaxPeriod.Value = Sinowyde.Util.ConvertUtil.ConvertToDecimal(model.MaxPeriod);
            ID = model.ID;
            btn_Save.Text = "编辑";
        }

        private void gv_CalcVariabel_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
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

        private void gc_CalcVariable_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    Variable model = ((List<Variable>)gv_CalcVariabel.DataSource)[hInfo.RowHandle];
                    SetVariable(model);
                }
            }
        }

        private void gv_CalcVariabel_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }

            if (e.Menu == null)
            {
                e.Menu = new DevExpress.XtraGrid.Menu.GridViewMenu((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            }

            e.Menu.Items.Add(new DXMenuItem("编辑计算变量"));
            e.Menu.Items.Add(new DXMenuItem("删除计算变量"));
            e.Menu.Items.Add(new DXMenuItem("清空计算变量"));

            e.Menu.Items[0].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            Variable model = new Variable();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_CalcVariabel.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<Variable>)gv_CalcVariabel.DataSource)[index];

                    e.Menu.Items[0].Click += delegate(object obj, EventArgs es) 
                    {
                        SetVariable(model);
                    };
                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es)
                    {
                        if (MessageBox.Show(string.Format("是否删除 {0} ?",model.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sql = string.Format("Delete FROM Variable WHERE ID = {0}",model.ID);
                            DOP.DataLogic.DOPDataLogic.Instance().Delete(sql);
                            loadData();
                        }
                    };
                }
            }

            e.Menu.Items[2].Click += delegate(object obj, EventArgs es) 
            {
                if (MessageBox.Show(string.Format("是否清空所有计算变量?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = string.Format("Delete FROM Variable WHERE DirectionType = {0}", (int)VarDirectionType.Calc);
                    DOP.DataLogic.DOPDataLogic.Instance().Delete(sql);
                    loadData();
                }
            };
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Clear();
        }
    }

    public static class TextBoxEx
    {
        public static string TextTrim(this TextEdit txt) 
        {
            return txt.Text.Trim();
        }

        public static void Empty(this TextEdit txt) 
        {
            txt.Text = string.Empty;
        }
    }
}