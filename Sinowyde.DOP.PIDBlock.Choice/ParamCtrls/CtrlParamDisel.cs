using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    public partial class CtrlParamDisel : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDisel()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDDisel.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDDisel.InputDI2).Value.ToString();
            this.drpInputDC.Text = Algorithm.GetInputVar(PIDDisel.InputDC).Value.ToString();

            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDDisel.InputDI1);
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDDisel.InputDI2);
            this.drpInputDC.Enabled = !Block.IsLinkLeftPort(PIDDisel.InputDC);

        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDDisel.InputDI1, ConvertUtil.ConvertToInt(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDDisel.InputDI2, ConvertUtil.ConvertToInt(this.drpInputDI2.Text));
            Algorithm.SetInputSourceValue(PIDDisel.InputDC, ConvertUtil.ConvertToDouble(this.drpInputDC.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
