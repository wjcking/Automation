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

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_ServiceCfg : DevExpress.XtraEditors.XtraForm
    {
        private ServiceCfg entity = new ServiceCfg();
        public Form_ServiceCfg()
        {
            InitializeComponent();
        }

        private void Form_ServiceCfg_Load(object sender, EventArgs e)
        {
            cmb_ServiceType.Properties.Items.AddRange(new ServiceCfgTypeHelper().GetShowTexts().ToArray<string>());
            ReloadList();
            SetServiceCfg(new ServiceCfg());
        }

        private void ReloadList() 
        {
            gc_ServiceCfg.DataSource = DOPDataLogic.Instance().GetAllBy<ServiceCfg>();
        }

        private void SetServiceCfg(ServiceCfg model) 
        {
            entity = model;
            txt_Name.Text = model.Name ?? "";
            txt_Address.Text = model.Address ?? "";
            cmb_ServiceType.SelectedIndex = new ServiceCfgTypeHelper().GetIndexByValue(model.ServiceType);
        }

        private void gv_ServiceCfg_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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
                    int index = gv_ServiceCfg.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    ServiceCfg model = ((List<ServiceCfg>)gv_ServiceCfg.DataSource)[index];
                    e.Menu.Items.Add(new DXMenuItem("编辑", delegate(object obj, EventArgs es)
                    {
                        SetServiceCfg(model);

                    }));
                    e.Menu.Items.Add(new DXMenuItem("删除", delegate(object obj, EventArgs es)
                    {
                        if (DialogResult.Yes == MessageBox.Show(string.Format("是否删除?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            string sql = string.Format("DELETE FROM ServiceCfg WHERE ID = {0}", model.ID);
                            DOPDataLogic.Instance().Delete(sql);
                            ReloadList();
                        }
                    }));
                }
            }
        }

        private void gv_ServiceCfg_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "col_ServiceType")
            {
                e.DisplayText = new ServiceCfgTypeHelper().GetKeyByValue((ServiceCfgType)e.Value);
            }
        }

        private void gv_ServiceCfg_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            if (this.gv_ServiceCfg.RowCount == 0)
            {
                string str = "暂无数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                SizeF sizeF = e.Graphics.MeasureString(str, f);
                int x = (int)((e.Bounds.Width - sizeF.Width) / 2);
                Rectangle r = new Rectangle(e.Bounds.Top + 5, e.Bounds.Left + 5, e.Bounds.Right - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, x, 40);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                MessageBox.Show("名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txt_Address.Text.Trim())) 
            {
                MessageBox.Show("地址不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            entity.Address = txt_Address.Text.Trim();
            entity.Name = txt_Name.Text.Trim();
            entity.ServiceType = new ServiceCfgTypeHelper().GetSelectValue(cmb_ServiceType.Text);
            if (entity.ID > 0)
            {
                DOPDataLogic.Instance().Update(entity);
            }
            else 
            {
                DOPDataLogic.Instance().Insert(entity);
            }
            ReloadList();
            SetServiceCfg(new ServiceCfg());
        }
    }
}