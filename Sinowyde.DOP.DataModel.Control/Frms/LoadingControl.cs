using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class LoadingControl : DevExpress.XtraEditors.XtraUserControl
    {
        public string Content
        {
            set 
            {
                if (lbl_content.InvokeRequired)
                {
                    Action action = () => { this.lbl_content.Text = value; };
                    this.lbl_content.Invoke(action);
                }
                else { lbl_content.Text = value; }
            }
        }

        public LoadingControl()
        {
            InitializeComponent();
        }

        private void LoadingControl_Load(object sender, EventArgs e)
        {
            this.Location = new Point((this.Parent.Width - this.Width) / 2, (this.Parent.Height - this.Height) / 2);
            this.BringToFront();
        }

    }
}
