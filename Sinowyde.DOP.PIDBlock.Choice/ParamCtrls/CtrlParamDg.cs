using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    public partial class CtrlParamDg : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDg()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDDg.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDDg.InputDI2).Value.ToString();
            this.drpInputDI3.Text = Algorithm.GetInputVar(PIDDg.InputDI3).Value.ToString();

            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDDg.InputDI1);
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDDg.InputDI2);
            this.drpInputDI3.Enabled = !Block.IsLinkLeftPort(PIDDg.InputDI3); 
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDDg.InputDI1, ConvertUtil.ConvertToInt(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDDg.InputDI2, ConvertUtil.ConvertToInt(this.drpInputDI2.Text));
            Algorithm.SetInputSourceValue(PIDDg.InputDI3, ConvertUtil.ConvertToInt(this.drpInputDI3.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
