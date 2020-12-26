using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    public partial class CtrlParamInsel : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamInsel()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinInputAI1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDInsel.InputAI1).Value);
            this.spinInputAI2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDInsel.InputAI2).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDInsel.InputDI).Value.ToString();
            this.spinParamK1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDInsel.ParamK1).Value);
            this.spinParamK2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDInsel.ParamK2).Value);

            this.spinInputAI1.Enabled = !Block.IsLinkLeftPort(PIDInsel.InputAI1);
            this.spinInputAI2.Enabled = !Block.IsLinkLeftPort(PIDInsel.InputAI2);
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDInsel.InputDI);
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDInsel.InputAI1, ConvertUtil.ConvertToDouble(this.spinInputAI1.Value));
            Algorithm.SetInputSourceValue(PIDInsel.InputAI2, ConvertUtil.ConvertToDouble(this.spinInputAI2.Value));
            Algorithm.SetParamValue(PIDInsel.ParamK1, ConvertUtil.ConvertToDouble(this.spinParamK1.Value));
            Algorithm.SetParamValue(PIDInsel.ParamK2, ConvertUtil.ConvertToDouble(this.spinParamK2.Value));
            Algorithm.SetInputSourceValue(PIDInsel.InputDI, ConvertUtil.ConvertToInt(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
