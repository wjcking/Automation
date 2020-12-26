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
using Sinowyde.DOP.DataLogic;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class From_IOServer : DevExpress.XtraEditors.XtraForm
    {
        private IOServer entity;
        public From_IOServer(IOServer model)
        {
            InitializeComponent();
            entity = model;
        }

        private void From_IOServer_Load(object sender, EventArgs e)
        {
            if (entity != null && entity.ID > 0)
            {
                this.Text = "修改IOServer";
                this.btn_Save.Text = "修改";
                entity = DOPDataLogic.Instance().Get<IOServer>(entity.ID);
            }
            txt_Name.Text = entity.Name == null ? "" : entity.Name.Trim();
            txt_Description.Text = entity.Description == null ? "" : entity.Description.Trim();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                MessageBox.Show("Server名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (entity.ID > 0)
            {
                if (!txt_Name.Text.Trim().Equals(entity.Name) && DOPDataLogic.Instance().IsExist<IOServer>(txt_Name.Text.Trim()))
                {
                    MessageBox.Show("Server名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else 
            {
                if (DOPDataLogic.Instance().IsExist<IOServer>(txt_Name.Text.Trim()))
                {
                    MessageBox.Show("Server名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            

            entity.Name = txt_Name.Text.Trim();
            entity.Description = txt_Description.Text.Trim();
            if (entity.ID <= 0)
            {
                DOPDataLogic.Instance().Insert(entity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DOPDataLogic.Instance().Update(entity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}