using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    public partial class CtrlParamOpsel : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamOpsel()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDOpsel.InputAI).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDOpsel.InputDI).Value.ToString();
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDOpsel.ParamK).Value);

            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDOpsel.InputAI);
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDOpsel.InputDI);
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDOpsel.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            Algorithm.SetInputSourceValue(PIDOpsel.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            Algorithm.SetParamValue(PIDOpsel.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
