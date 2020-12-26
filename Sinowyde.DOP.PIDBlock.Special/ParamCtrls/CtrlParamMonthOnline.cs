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
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Special;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.Special
{
    public partial class CtrlParamMonthOnline : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMonthOnline()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.comboBoxEditDI1.Text = this.comboBoxEditDI1.Enabled ? Algorithm.GetInputVar(PIDMonthOnline.InputDI1).Value.ToString() : "0";
            this.comboBoxEditDI2.Text = this.comboBoxEditDI2.Enabled ? Algorithm.GetInputVar(PIDMonthOnline.InputDI2).Value.ToString() : "0";
            this.comboBoxEditDI3.Text = this.comboBoxEditDI3.Enabled ? Algorithm.GetInputVar(PIDMonthOnline.InputDI3).Value.ToString() : "0";
            this.comboBoxEditDI4.Text = this.comboBoxEditDI4.Enabled ? Algorithm.GetInputVar(PIDMonthOnline.InputDI4).Value.ToString() : "0";

            this.comboBoxEditDI1.Enabled = !Block.IsLinkLeftPort(PIDMonthOnline.InputDI1);
            this.comboBoxEditDI2.Enabled = !Block.IsLinkLeftPort(PIDMonthOnline.InputDI2);
            this.comboBoxEditDI3.Enabled = !Block.IsLinkLeftPort(PIDMonthOnline.InputDI3);
            this.comboBoxEditDI4.Enabled = !Block.IsLinkLeftPort(PIDMonthOnline.InputDI4);
        }

        public bool SaveParam()
        {
            Algorithm.SetInputValue(PIDMonthOnline.InputDI1, ConvertUtil.ConvertToDouble(this.comboBoxEditDI1.Text));
            Algorithm.SetInputValue(PIDMonthOnline.InputDI2, ConvertUtil.ConvertToDouble(this.comboBoxEditDI2.Text));
            Algorithm.SetInputValue(PIDMonthOnline.InputDI3, ConvertUtil.ConvertToDouble(this.comboBoxEditDI3.Text));
            Algorithm.SetInputValue(PIDMonthOnline.InputDI4, ConvertUtil.ConvertToDouble(this.comboBoxEditDI4.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
        #endregion
    }
}
