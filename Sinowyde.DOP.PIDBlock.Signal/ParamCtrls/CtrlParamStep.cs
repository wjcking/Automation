using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamStep : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamStep()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamInit.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStep.ParamInit).Value);
            this.spinParamStep.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStep.ParamStep).Value);
            this.spinParamTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStep.ParamTime).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDStep.InputDI).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDStep.InputDI);  
       
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDStep.ParamInit, ConvertUtil.ConvertToDouble(this.spinParamInit.Value));
            Algorithm.SetParamValue(PIDStep.ParamStep, ConvertUtil.ConvertToDouble(this.spinParamStep.Value));
            Algorithm.SetParamValue(PIDStep.ParamTime, ConvertUtil.ConvertToDouble(this.spinParamTime.Value));
            Algorithm.SetInputSourceValue(PIDStep.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
