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
using Sinowyde.DOP.PIDAlgorithm.Math;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.Math
{
    public partial class CtrlParamSin : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSin()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            cmb_ATrigonometricFunc.Properties.Items.Clear();
            cmb_ATrigonometricFunc.Properties.Items.AddRange(new PIDsinHelper().GetShowTexts().ToArray<string>());
            cmb_ATrigonometricFunc.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cmb_ATrigonometricFunc.Text = new PIDsinHelper().GetKeyByValue((PIDsins)Algorithm.GetParam(PIDSin.ParamTrigonometricFunc).Value);
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDSin.InputAI);
        }

        public bool SaveParam()
        {
            this.UpdateParams(false, Algorithm);

            PIDsins selectType = new PIDsinHelper().GetSelectValue(cmb_ATrigonometricFunc.Text);
            Algorithm.SetParamValue(PIDSin.ParamTrigonometricFunc, (double)selectType);
            ((FrmPIDBlockParam)this.ParentForm).NewImageName = string.Format("math_{0}_normal", cmb_ATrigonometricFunc.Text.ToLower());
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
        #endregion

        /// <summary>
        /// 数值合法性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_inputAI_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_ATrigonometricFunc.SelectedIndex==2 && this.txt_inputAI.Value % 90 == 0)
                this.txt_inputAI.Value = 0;
        }
    }
}
