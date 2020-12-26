using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamAnd : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAnd()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        { 
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDAnd.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDAnd.InputDI2).Value.ToString();
            this.drpInputDI3.Text = Algorithm.GetInputVar(PIDAnd.InputDI3).Value.ToString();
            this.drpInputDI4.Text = Algorithm.GetInputVar(PIDAnd.InputDI4).Value.ToString();

            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDAnd.InputDI1);  
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDAnd.InputDI2);  
            this.drpInputDI3.Enabled = !Block.IsLinkLeftPort(PIDAnd.InputDI3);  
            this.drpInputDI4.Enabled = !Block.IsLinkLeftPort(PIDAnd.InputDI4);  
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDAnd.InputDI1, ConvertUtil.ConvertToInt(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDAnd.InputDI2, ConvertUtil.ConvertToInt(this.drpInputDI2.Text));
            Algorithm.SetInputSourceValue(PIDAnd.InputDI3, ConvertUtil.ConvertToInt(this.drpInputDI3.Text));
            Algorithm.SetInputSourceValue(PIDAnd.InputDI4, ConvertUtil.ConvertToInt(this.drpInputDI4.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
