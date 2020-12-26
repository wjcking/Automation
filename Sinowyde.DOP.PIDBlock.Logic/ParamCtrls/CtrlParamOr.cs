using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamOr : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamOr()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI1.Text = Algorithm.GetInputVar(PIDOr.InputDI1).Value.ToString();
            this.drpInputDI2.Text = Algorithm.GetInputVar(PIDOr.InputDI2).Value.ToString();
            this.drpInputDI3.Text = Algorithm.GetInputVar(PIDOr.InputDI3).Value.ToString();
            this.drpInputDI4.Text = Algorithm.GetInputVar(PIDOr.InputDI4).Value.ToString();

            this.drpInputDI1.Enabled = !Block.IsLinkLeftPort(PIDOr.InputDI1);
            this.drpInputDI2.Enabled = !Block.IsLinkLeftPort(PIDOr.InputDI2);
            this.drpInputDI3.Enabled = !Block.IsLinkLeftPort(PIDOr.InputDI3);
            this.drpInputDI4.Enabled = !Block.IsLinkLeftPort(PIDOr.InputDI4); 
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDOr.InputDI1, ConvertUtil.ConvertToInt(this.drpInputDI1.Text));
            Algorithm.SetInputSourceValue(PIDOr.InputDI2, ConvertUtil.ConvertToInt(this.drpInputDI2.Text));
            Algorithm.SetInputSourceValue(PIDOr.InputDI3, ConvertUtil.ConvertToInt(this.drpInputDI3.Text));
            Algorithm.SetInputSourceValue(PIDOr.InputDI4, ConvertUtil.ConvertToInt(this.drpInputDI4.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
