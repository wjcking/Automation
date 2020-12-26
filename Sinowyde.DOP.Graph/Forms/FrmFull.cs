using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;

namespace Sinowyde.DOP.Graph.FORMS
{
    public partial class FrmFull : Form
    {
        private GoView goView = null;

        public FrmFull(GoView goView)
        {
            InitializeComponent();
            this.goView = goView;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Controls.Remove(goView);
                this.DialogResult = DialogResult.OK;
                //this.Close();
                return false;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void FrmFull_Load(object sender, EventArgs e)
        {
            Controls.Add(goView);
            WindowState = FormWindowState.Normal;
            TopLevel = true;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
        }
    }
}
