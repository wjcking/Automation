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
using Northwoods.Go.Draw;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlBrushTool : XtraUserControl
    {
        public GoDrawView drawView { get; set; }
        public UCtlBrushTool()
        {
            InitializeComponent();
        }

        private void UCtlBrushTool_Load(object sender, EventArgs e)
        {
            this.goBrushToolStrip.View = this.drawView;
        }
    }
}
