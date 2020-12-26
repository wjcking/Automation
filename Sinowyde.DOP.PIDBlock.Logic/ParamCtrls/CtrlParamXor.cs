using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamXor : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamXor()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDXor.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDXor.InputDI2).Value.ToString();

            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDXor.InputDI1);
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDXor.InputDI2);
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDXor.InputDI1, ConvertUtil.ConvertToInt(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDXor.InputDI2, ConvertUtil.ConvertToInt(this.drpInputDI2.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
