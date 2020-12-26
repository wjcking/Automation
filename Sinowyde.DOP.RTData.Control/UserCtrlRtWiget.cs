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
    public partial class UserCtrlRtWiget : DevExpress.XtraEditors.XtraUserControl
    {
        public UserCtrlRtWiget()
        {
            InitializeComponent();
        }
    }

    public class TextModel
    {
        public string Name { get; set; }
        public int age { get; set; }
    }
}
