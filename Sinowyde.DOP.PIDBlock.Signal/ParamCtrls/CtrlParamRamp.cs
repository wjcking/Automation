using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamRamp : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamRamp()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamInit.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDRamp.ParamInit).Value);
            this.spinParamSlope.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDRamp.ParamSlope).Value);
            this.spinParamTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDRamp.ParamTime).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDRamp.InputDI).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDRamp.InputDI); 
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDRamp.ParamInit, ConvertUtil.ConvertToDouble(this.spinParamInit.Value));
            Algorithm.SetParamValue(PIDRamp.ParamSlope, ConvertUtil.ConvertToDouble(this.spinParamSlope.Value));
            Algorithm.SetParamValue(PIDRamp.ParamTime, ConvertUtil.ConvertToDouble(this.spinParamTime.Value));
            Algorithm.SetInputSourceValue(PIDRamp.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
