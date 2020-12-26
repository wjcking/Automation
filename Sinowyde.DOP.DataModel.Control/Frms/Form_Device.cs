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
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_Device : DevExpress.XtraEditors.XtraForm
    {
        private long ID = 0;

        public Form_Device()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                MessageBox.Show("请输入设备名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Device model = new Device();

            model.Name = txt_Name.Text.Trim();
            List<Device> list = (List<Device>)gc_Device.DataSource;

            if (ID > 0)
            {
                if (!model.Name.Equals(txt_Name.Text.Trim()))
                {
                    if (list.Where(o => o.Name.Equals(txt_Name.Text.Trim())).Count() > 0)
                    {
                        MessageBox.Show("设备名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                model.ID = ID;
                DOP.DataLogic.DOPDataLogic.Instance().Update(model);
            }
            else
            {
                if (list.Where(o => o.Name.Equals(txt_Name.Text.Trim())).Count() > 0)
                {
                    MessageBox.Show("设备名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DOP.DataLogic.DOPDataLogic.Instance().Insert(model);
            }

            Clear();
            loadData();
        }

        private void Form_Device_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            gc_Device.DataSource = DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<Device>(); ;
        }

        private void Clear()
        {
            txt_Name.Text = string.Empty;
            ID = 0;
            btn_Save.Text = "新增";
        }

        private void SetDevice(Device model)
        {
            txt_Name.Text = model.Name;
            ID = model.ID;
            btn_Save.Text = "编辑";
        }

        private void gv_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
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

        private void gc_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    Device model = ((List<Device>)gv_Device.DataSource)[hInfo.RowHandle];
                    SetDevice(model);
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

            e.Menu.Items.Add(new DXMenuItem("编辑设备"));
            e.Menu.Items.Add(new DXMenuItem("删除设备"));
            e.Menu.Items.Add(new DXMenuItem("清空设备"));

            e.Menu.Items[0].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            Device model = new Device();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_Device.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<Device>)gv_Device.DataSource)[index];

                    e.Menu.Items[0].Click += delegate(object obj, EventArgs es)
                    {
                        SetDevice(model);
                    };
                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es)
                    {
                        if (MessageBox.Show(string.Format("是否删除 {0} ?", model.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sql = string.Format("Delete FROM Device WHERE ID = {0}", model.ID);
                            DOP.DataLogic.DOPDataLogic.Instance().Delete(sql);
                            loadData();
                        }
                    };
                }
            }

            e.Menu.Items[2].Click += delegate(object obj, EventArgs es)
            {
                if (MessageBox.Show(string.Format("是否清空所有设备?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = string.Format("Delete FROM Device");
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
}