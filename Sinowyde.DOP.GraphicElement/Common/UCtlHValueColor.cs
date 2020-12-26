using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.Util;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlHValueColor : XtraUserControl
    {
        public string Expression
        {
            get
            {
                return this.txtOutputValue.Text;
            }
            set
            {
                this.txtOutputValue.Text = value;
            }
        }

        public Color color
        {
            get
            {
                return ColorOutputColo.Color;
            }
            set
            {
                ColorOutputColo.Color = value;
            }
        }

        public Color BackColor
        {
            get
            {
                return colorOutputBackColor.Color;
            }
            set
            {
                colorOutputBackColor.Color = value;
            }
        }

        public string title
        {
            get
            {
                return this.lblOutputString.Text;
            }
            set
            {
                this.lblOutputString.Text = value;
            }
        }

        public UCtlHValueColor()
        {
            InitializeComponent();
        }

        private void UCtlHValueColor_Load(object sender, EventArgs e)
        {

        }
    }
}
