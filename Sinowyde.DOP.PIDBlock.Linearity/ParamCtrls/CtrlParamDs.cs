using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamDs : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDs()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamK1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDs.ParamK1).Value);
            this.spinParamK2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDs.ParamK2).Value);
            this.spinParamK3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDs.ParamK3).Value);
            this.spinParamK4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDs.ParamK4).Value);
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDDs.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDDs.InputDI2).Value.ToString();
            this.drpInputDI3.Text = Algorithm.GetInputVar(PIDDs.InputDI3).Value.ToString();
            this.drpInputDI4.Text = Algorithm.GetInputVar(PIDDs.InputDI4).Value.ToString();


            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDDs.InputDI1);
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDDs.InputDI2);
            this.drpInputDI3.Enabled = !Block.IsLinkLeftPort(PIDDs.InputDI3);
            this.drpInputDI4.Enabled = !Block.IsLinkLeftPort(PIDDs.InputDI4);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDDs.ParamK1, ConvertUtil.ConvertToDouble(this.spinParamK1.Value));
            Algorithm.SetParamValue(PIDDs.ParamK2, ConvertUtil.ConvertToDouble(this.spinParamK2.Value));
            Algorithm.SetParamValue(PIDDs.ParamK3, ConvertUtil.ConvertToDouble(this.spinParamK3.Value));
            Algorithm.SetParamValue(PIDDs.ParamK4, ConvertUtil.ConvertToDouble(this.spinParamK4.Value));
            Algorithm.SetInputSourceValue(PIDDs.InputDI1, ConvertUtil.ConvertToDouble(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDDs.InputDI2, ConvertUtil.ConvertToDouble(this.drpInputDI2.Text));
            Algorithm.SetInputSourceValue(PIDDs.InputDI3, ConvertUtil.ConvertToDouble(this.drpInputDI3.Text));
            Algorithm.SetInputSourceValue(PIDDs.InputDI4, ConvertUtil.ConvertToDouble(this.drpInputDI4.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
