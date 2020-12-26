using System;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.Util;
namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlHotspotParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        private OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files (*.*)|*.*" };
        private GoRectangle button;

        public UCtlHotspotParam()
        {
            InitializeComponent();
        }

        public UCtlHotspotParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGraphElement = generalShape;
            button = dopGraphElement.First as GoRectangle;
        }

        public void LoadParam()
        {
            //cbxOperate.SelectedIndex = ConvertUtil.ConvertToInt(dopGraphElement.ActionScript[0].Condition[0]);
            //txtFile.Text = ConvertUtil.ConvertToString(dopGraphElement.ActionScript[0].Condition[1]);
            //spinLeft.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[2]);
            //spinTop.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[3]);

            //spinWidth.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[4]);
            //spinHeight.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[5]);

        }

        public bool SaveParam()
        {
            //dopGraphElement.ActionScript[0].Condition[0] = cbxOperate.SelectedIndex.ToString();
            //dopGraphElement.ActionScript[0].Condition[1] = txtFile.Text;
            //dopGraphElement.ActionScript[0].Condition[2] = spinLeft.Value.ToString();
            //dopGraphElement.ActionScript[0].Condition[3] = spinTop.Value.ToString();
            //dopGraphElement.ActionScript[0].Condition[4] = spinWidth.Value.ToString();
            //dopGraphElement.ActionScript[0].Condition[5] = spinHeight.Value.ToString();

            return true;
        }

        public System.Windows.Forms.UserControl GetParamCtrl()
        {
            return this;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cbxOperate.SelectedIndex == 2)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtFile.Text = ofd.FileName;
                return;
            }

            frmOpenDialog frm = new frmOpenDialog();
            if (frm.ShowDialog() == DialogResult.OK)
                txtFile.Text = frm.GraphDoc.Name;

        }

        private void cbxOperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ofd.Filter = cbxOperate.SelectedIndex == 0 ? "(*.wnd)|*.wnd" : ofd.Filter;
            panelCtlDOColor.Visible = cbxOperate.SelectedIndex == 1 ? true : false;
            ofd.Filter = cbxOperate.SelectedIndex == 2 ? "(*.exe)|*.exe" : ofd.Filter;
            //int index = ConvertUtil.ConvertToInt(dopGraphElement.ActionScript[0].Condition[0]);
            //txtFile.Text = cbxOperate.SelectedIndex == index ? ConvertUtil.ConvertToString(dopGraphElement.ActionScript[0].Condition[1]) : String.Empty;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            //FontDialog fd = new FontDialog();
        }

    }
}
