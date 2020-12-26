using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinowyde.DOP.SamaXmlUpdate.Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textEditOld.ReadOnly = true;
            this.textEditNew.ReadOnly = true;
        }

        private void simpleButtonOld_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sama文档(*.sama)|*.sama";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.textEditOld.Text = openFileDialog.FileName;
        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "sama文档(*.sama)|*.sama";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                this.textEditNew.Text = saveFileDialog.FileName;
        }

        private void simpleButtonDo_Click(object sender, EventArgs e)
        {
            var oldFile = this.textEditOld.Text;
            var newFile = this.textEditNew.Text;
            if (!string.IsNullOrEmpty(oldFile) && !string.IsNullOrEmpty(newFile) && File.Exists(oldFile))
            {
                var flag = DoManager.Instance().Do(oldFile, newFile);
                if (flag)
                {
                    XtraMessageBox.Show("升级成功!");
                }
            }
        }
    }
}
