using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using Sinowyde.DOP.PIDBlock.Xml;

namespace Sinowyde.DOP.Sama.Control.Frms
{
    public partial class FrmBackup : XtraForm
    {


        public FrmBackup()
        {
            InitializeComponent();
        }

        private bool BackupCheckParams()
        {
            //IList<string> list = new List<string> { "", };

            if (textEditPeople.Text.Contains(".") || memoEdit.Text.Contains("."))
            {
                XtraMessageBox.Show("描述不可以有非法字符！");
                return false;
            }

            return true;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (BackupCheckParams())
            {
                if (XtraMessageBox.Show("确认要开始备份？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using (new WaitDialogForm("请等待", "备份数据中...", new Size(200, 50), ParentForm))
                    {
                        var flag = PIDDocManager.Instance().Backup(textEditPeople.Text, memoEdit.Text);
                        XtraMessageBox.Show(flag ? "备份成功!" : "备份失败!");
                    }
                }
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
