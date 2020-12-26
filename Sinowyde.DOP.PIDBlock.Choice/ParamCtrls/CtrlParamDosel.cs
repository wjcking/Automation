using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    public partial class CtrlParamDosel : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDosel()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDDosel.InputDI).Value.ToString();
            this.drpInputDC.Text = Algorithm.GetInputVar(PIDDosel.InputDC).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDDosel.InputDI);
            this.drpInputDC.Enabled = !Block.IsLinkLeftPort(PIDDosel.InputDC);        
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDDosel.InputDI,  ConvertUtil.ConvertToInt(this.drpInputDI.Text));
            Algorithm.SetInputSourceValue(PIDDosel.InputDC, ConvertUtil.ConvertToInt(this.drpInputDC.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
