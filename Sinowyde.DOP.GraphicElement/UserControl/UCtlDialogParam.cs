using System;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.Util;
namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlDialogParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        private OpenFileDialog ofd = new OpenFileDialog();
        private GoButton button;

        public UCtlDialogParam()
        {
            InitializeComponent();
        }

        public UCtlDialogParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGraphElement = generalShape;
        }

        public void LoadParam()
        {
            //int index = ConvertUtil.ConvertToInt(dopGraphElement.ActionScript[0].Condition[0]);
            //rbEquals.SelectedIndex = index;
            //uCtlGetVariable1.SelectedVariable = dopGraphElement.ActionScript[0].Variable[0];
            //rbEquals.SelectedIndex = ConvertUtil.ConvertToInt(dopGraphElement.ActionScript[0].Condition[0]);
            //txtFile.Text = dopGraphElement.ActionScript[0].Condition[1];
            //spinLeft.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[2]);
            //spinTop.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[3]);
            //spinWidth.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[4]);
            //spinHeight.Value = ConvertUtil.ConvertToDecimal(dopGraphElement.ActionScript[0].Condition[5]);
        }

        public bool SaveParam()
        {
            if (string.IsNullOrEmpty(uCtlGetVariable1.SelectedVariable.Number))
            {
                XtraMessageBox.Show(DOPDialog.ERROR_NullVar);
                return false;
            }
            //dopGraphElement.ActionScript[0]. Variable[0] = uCtlGetVariable1.SelectedVariable;
            //dopGraphElement.ActionScript[0].Condition[0] = rbEquals.SelectedIndex.ToString();
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
            frmOpenDialog frm = new frmOpenDialog();
            if (frm.ShowDialog() == DialogResult.OK)
                txtFile.Text = frm.GraphDoc.Name;
        }

    }
}
