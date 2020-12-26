using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamCounter : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamCounter()
        {
            InitializeComponent();
            ctrlEnumTimer.LoadEnum();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDCounter.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDCounter.InputDI2).Value.ToString();

            this.ctrlEnumTimer.SelectedInteger = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDCounter.ParamSense).Value);
            this.ctrlEnumCounter.SelectedItem = Algorithm.GetParam(PIDCounter.ParamUpCount).ValueToBool();
            this.spinParamMaxVal.Value = Convert.ToDecimal(Algorithm.GetParam(PIDCounter.ParamMaxVal).Value);

            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDCounter.InputDI1); 
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDCounter.InputDI2); 

        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDCounter.InputDI1, ConvertUtil.ConvertToInt(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDCounter.InputDI2, ConvertUtil.ConvertToInt(this.drpInputDI2.Text));

            Algorithm.SetParamValue(PIDCounter.ParamSense, this.ctrlEnumTimer.SelectedInteger);
            Algorithm.SetParamValue(PIDCounter.ParamMaxVal, ConvertUtil.ConvertToDouble(this.spinParamMaxVal.Value));
            Algorithm.SetParamValue(PIDCounter.ParamUpCount, ConvertUtil.ConvertToInt(ctrlEnumCounter.SelectedItem));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
