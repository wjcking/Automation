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

namespace Sinowyde.DOP.RTData.Control
{
    public partial class UserCtrlLoadData : DevExpress.XtraEditors.XtraUserControl
    {
        private string caption = "正在加载... ...";
        /// <summary>
        /// 提示文字
        /// </summary>
        [Browsable(true)]
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                if (value != null) 
                { 
                    lbl_Caption.Text = value;
                    this.Width = label1.Width + lbl_Caption.Width + 20;
                }
            }
        }

        public UserCtrlLoadData()
        {
            InitializeComponent();
        }

        private void UserCtrlLoadData_Load(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Location = new Point((this.Parent.Width - this.Width) / 2, (this.Parent.Height - this.Height) / 2);
            }
        }
    }
}
